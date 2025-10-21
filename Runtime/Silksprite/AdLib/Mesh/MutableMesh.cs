using System.Collections.Generic;
using System.Linq;
using Silksprite.AdLib.Mesh.Extensions;
using UnityEngine;

namespace Silksprite.AdLib.Mesh
{
    public partial class MutableMesh
    {
        public readonly string Name;

        public readonly MutableBoneList BoneList = new MutableBoneList();

        public readonly List<Vector3> Vertices = new List<Vector3>();
        public readonly List<MutableBoneWeight> BoneWeights = new List<MutableBoneWeight>();
        public readonly List<Vector3> Normals = new List<Vector3>();
        public readonly List<Vector4> Tangents = new List<Vector4>();
        public readonly List<Color32> Colors = new List<Color32>();

        public readonly List<Vector2>[] Uvs = Enumerable.Range(0, 8).Select(i => new List<Vector2>()).ToArray();

        public readonly List<MutableSubMesh> SubMeshes = new List<MutableSubMesh>();

        public readonly List<MutableBlendShape> BlendShapes = new List<MutableBlendShape>();

        const int UvChannels = 8;

        public MutableMesh(string name)
        {
            Name = name;
        }

        public MutableMesh(UnityEngine.Mesh mesh, MutableBoneList boneList) : this(mesh.name)
        {
            BoneList.AddRange(boneList);

            mesh.GetVertices(Vertices);
            BoneWeights.AddRange(mesh.GetMutableBoneWeights(BoneList));
            mesh.GetNormals(Normals);
            mesh.GetTangents(Tangents);
            mesh.GetColors(Colors);

            for (var uvChannel = 0; uvChannel < UvChannels; uvChannel++)
            {
                mesh.GetUVs(uvChannel, Uvs[uvChannel]);
            }

            SubMeshes.AddRange(Enumerable.Range(0, mesh.subMeshCount)
                .Select(subMeshIndex =>
                {
                    var indices = new List<int>();
                    mesh.GetIndices(indices, subMeshIndex);
                    return new MutableSubMesh(indices);
                }));

            BlendShapes.AddRange(mesh.GetMutableBlendShapes());
        }

        public void Add(UnityEngine.Mesh mesh, MutableBoneList boneList)
        {
            BoneList.AddRange(boneList);

            var myVertexCount = Vertices.Count;

            Vertices.AddRange(mesh.vertices);
            BoneWeights.AddRange(mesh.GetMutableBoneWeights(boneList));
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
                .Select(subMeshIndex =>
                {
                    mesh.GetIndices(workIndices, subMeshIndex);
                    return new MutableSubMesh(workIndices.Select(i => i + myVertexCount));
                }));

            var blendShapes = new List<MutableBlendShape>();
            var meshBlendShapes = mesh.GetMutableBlendShapes().ToArray();

            foreach (var blendShape in BlendShapes)
            {
                var meshBlendShape = meshBlendShapes.FirstOrDefault(bs => bs.BlendShapeName == blendShape.BlendShapeName);
                blendShape.Add(meshBlendShape);
                blendShapes.Add(blendShape);
            }
            foreach (var meshBlendShape in meshBlendShapes)
            {
                if (BlendShapes.Any(bs => bs.BlendShapeName == meshBlendShape.BlendShapeName)) continue;
                var blendShape = new MutableBlendShape(meshBlendShape.BlendShapeName);
                blendShape.AddZeros(myVertexCount);
                blendShape.Add(meshBlendShape);
                blendShapes.Add(blendShape);
            }
            BlendShapes.Clear();
            BlendShapes.AddRange(blendShapes);
        }

        public void ExportTo(UnityEngine.Mesh mesh)
        {
            mesh.bindposes = BoneList.Bones.Select(bone => bone.BindPose).ToArray();

            mesh.SetVertices(Vertices);
            mesh.SetBoneWeights(BoneList, BoneWeights);
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
                foreach (var frame in blendShape.SingleFrames)
                {
                    mesh.AddBlendShapeFrame(blendShape.BlendShapeName,
                        frame.FrameWeight,
                        frame.DeltaVertices.ToArray(),
                        frame.DeltaNormals.ToArray(),
                        frame.DeltaTangents.ToArray());
                }
            }
        }
    }
}