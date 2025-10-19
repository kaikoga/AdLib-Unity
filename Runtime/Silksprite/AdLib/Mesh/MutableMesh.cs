using System.Collections.Generic;
using System.Linq;
using Silksprite.AdLib.Mesh.Extensions;
using Silksprite.AdLib.Mesh.View;
using UnityEngine;

namespace Silksprite.AdLib.Mesh
{
    public partial class MutableMesh<TBone, TMaterial>
    {
        public readonly string Name;

        public readonly MutableBoneMapping<TBone> Bones = new MutableBoneMapping<TBone>();

        public readonly List<Vector3> Vertices = new List<Vector3>();
        public readonly List<MutableBoneWeight<TBone>> BoneWeights = new List<MutableBoneWeight<TBone>>();
        public readonly List<Vector3> Normals = new List<Vector3>();
        public readonly List<Vector4> Tangents = new List<Vector4>();
        public readonly List<Color32> Colors = new List<Color32>();

        public readonly List<Vector2>[] Uvs = Enumerable.Range(0, 8).Select(i => new List<Vector2>()).ToArray();

        public readonly List<MutableSubMesh<TMaterial>> SubMeshes = new List<MutableSubMesh<TMaterial>>();

        public readonly List<MutableBlendShape> BlendShapes = new List<MutableBlendShape>();
        public readonly List<float> BlendShapeWeights = new List<float>();

        public IEnumerable<TMaterial> Materials => SubMeshes.Select(subMesh => subMesh.Material);

        const int UvChannels = 8;

        public MutableMesh(string name)
        {
            Name = name;
        }

        public MutableMesh(UnityEngine.Mesh mesh, IEnumerable<float> blendShapeWeights, MutableBoneMapping<TBone> bones, IEnumerable<TMaterial> materials) : this(mesh.name)
        {
            Bones.AddRange(bones);

            mesh.GetVertices(Vertices);
            // BoneWeights.AddRange(mesh.boneWeights.Select(boneWeight => MutableBoneWeight<TBone>.FromBoneWeight(boneWeight, Bones)));
            BoneWeights.AddRange(mesh.GetBoneWeights(bones));
            mesh.GetNormals(Normals);
            mesh.GetTangents(Tangents);
            mesh.GetColors(Colors);

            for (var uvChannel = 0; uvChannel < UvChannels; uvChannel++)
            {
                mesh.GetUVs(uvChannel, Uvs[uvChannel]);
            }

            SubMeshes.AddRange(Enumerable.Range(0, mesh.subMeshCount)
                .Zip(materials.Concat(Enumerable.Repeat<TMaterial>(default, mesh.subMeshCount)),
                    (subMeshIndex, material) =>
                    {
                        var indices = new List<int>();
                        mesh.GetIndices(indices, subMeshIndex);
                        return new MutableSubMesh<TMaterial>(indices, material);
                    }));

            BlendShapes.AddRange(mesh.MutableBlendShapes());
            BlendShapeWeights.AddRange(blendShapeWeights);
        }

        public void Add(UnityEngine.Mesh mesh, MutableBoneMapping<TBone> bones, IEnumerable<TMaterial> materials)
        {
            Bones.AddRange(bones);

            var myVertexCount = Vertices.Count;

            Vertices.AddRange(mesh.vertices);
            // BoneWeights.AddRange(mesh.boneWeights.Select(boneWeight => MutableBoneWeight<TBone>.FromBoneWeight(boneWeight, Bones)));
            BoneWeights.AddRange(mesh.GetBoneWeights(Bones));
            Normals.AddRange(mesh.normals);
            Tangents.AddRange(mesh.tangents);
            Colors.AddRange(mesh.colors32);

            for (var uvChannel = 0; uvChannel < UvChannels; uvChannel++)
            {
                if (Uvs[uvChannel].Count <= 0) continue;
                var uvs = new List<Vector2>();
                mesh.GetUVs(uvChannel, uvs);
                Uvs[uvChannel].AddRange(uvs);
            }

            var workIndices = new List<int>();
            SubMeshes.AddRange(Enumerable.Range(0, mesh.subMeshCount)
                .Zip(materials.Concat(Enumerable.Repeat<TMaterial>(default, mesh.subMeshCount)),
                    (subMeshIndex, material) =>
                    {
                        mesh.GetIndices(workIndices, subMeshIndex);
                        return new MutableSubMesh<TMaterial>(workIndices.Select(i => i + myVertexCount), material);
                    }));

            // TODO deal with frame weights
            var vertexCount = mesh.vertexCount;
            var blendShapes = new List<MutableBlendShape>();
            var meshBlendShapes = mesh.MutableBlendShapes().ToArray();

            foreach (var blendShape in BlendShapes)
            {
                var meshBlendShape = meshBlendShapes.FirstOrDefault(bs => bs.BlendShapeName == blendShape.BlendShapeName);
                blendShape.Add(meshBlendShape ?? new MutableBlendShape(blendShape.BlendShapeName, blendShape.FrameWeight, vertexCount));
                blendShapes.Add(blendShape);
            }
            foreach (var meshBlendShape in meshBlendShapes)
            {
                if (BlendShapes.Any(bs => bs.BlendShapeName == meshBlendShape.BlendShapeName)) continue;
                var blendShape = new MutableBlendShape(meshBlendShape.BlendShapeName, meshBlendShape.FrameWeight, myVertexCount);
                blendShape.Add(meshBlendShape);
                blendShapes.Add(blendShape);
            }
            BlendShapes.Clear();
            BlendShapes.AddRange(blendShapes);
        }

        public void ExportTo(UnityEngine.Mesh mesh)
        {
            mesh.bindposes = Bones.BindPoses.ToArray();

            mesh.SetVertices(Vertices);
            // mesh.boneWeights = BoneWeights.Select(mutableBoneWeight => mutableBoneWeight.ToBoneWeight(Bones)).ToArray();
            mesh.SetBoneWeights(Bones, BoneWeights);
            mesh.SetNormals(Normals);
            mesh.SetTangents(Tangents);
            mesh.SetColors(Colors);

            for (var uvChannel = 0; uvChannel < UvChannels; uvChannel++)
            {
                mesh.SetUVs(uvChannel, Uvs[uvChannel]);
            }

            mesh.subMeshCount = SubMeshes.Count;
            for (var subMeshIndex = 0; subMeshIndex < SubMeshes.Count; subMeshIndex++)
            {
                mesh.SetIndices(SubMeshes[subMeshIndex].Indices, MeshTopology.Triangles, subMeshIndex);
            }

            mesh.ClearBlendShapes();
            foreach (var blendShape in BlendShapes)
            {
                mesh.AddBlendShapeFrame(blendShape.BlendShapeName,
                    blendShape.FrameWeight,
                    blendShape.DeltaVertices.ToArray(),
                    blendShape.DeltaNormals.ToArray(),
                    blendShape.DeltaTangents.ToArray());
            }
        }
        
        public MutableMeshView<TBone, TMaterial> View() => new MutableMeshView<TBone,TMaterial>(this);
    }
}