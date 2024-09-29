using System.Collections.Generic;
using System.Linq;

namespace Silksprite.AdLib.Mesh
{
    public partial class MutableMesh<TBone, TMaterial>
    {
        void MergeSubMeshes()
        {
            var subMeshes = SubMeshes.GroupBy(subMesh => subMesh.Material)
                .Select(subMeshGroup =>
                {
                    return new MutableSubMesh<TMaterial>(subMeshGroup.SelectMany(subMesh => subMesh.Indices), subMeshGroup.Key);
                }).ToArray();
            SubMeshes.Clear();
            SubMeshes.AddRange(subMeshes);
        }

        void RemoveUnusedBones()
        {
            var boneObjects = BoneWeights.SelectMany(boneWeight => boneWeight.Bones.Select(bone => bone.BoneObject)).Distinct().ToArray();
            Bones.Filter(boneObjects);
        }

        void RemoveDuplicateBones()
        {
            Bones.Distinct();
        }

        void RemoveUnusedVertices()
        {
            var oldIndices = new List<int>(Vertices.Count);
            var newIndices = new List<int>(Vertices.Count);
            for (var i = 0; i < Vertices.Count; i++)
            {
                newIndices.Add(oldIndices.Count);
                if (SubMeshes.Any(subMesh => subMesh.Indices.Contains(i)))
                {
                    oldIndices.Add(i);
                }
            }

            void FilterVertices<T>(List<T> target)
            {
                if (target == null || target.Count == 0) return;
                var newList = oldIndices.Select(i => target[i]).ToArray();
                target.Clear();
                target.AddRange(newList);
            }

            void MapIndices(List<int> target)
            {
                var newList = target.Select(i => newIndices[i]).ToArray();
                target.Clear();
                target.AddRange(newList);
            }

            FilterVertices(Vertices);
            FilterVertices(BoneWeights);
            FilterVertices(Normals);
            FilterVertices(Tangents);
            FilterVertices(Colors);
            foreach (var uv in Uvs) FilterVertices(uv);
            foreach (var blendShape in BlendShapes)
            {
                FilterVertices(blendShape.DeltaVertices);
                FilterVertices(blendShape.DeltaNormals);
                FilterVertices(blendShape.DeltaTangents);
            }
            
            foreach (var subMesh in SubMeshes) MapIndices(subMesh.Indices);
        }

        public void GC()
        {
            MergeSubMeshes();
            RemoveUnusedBones();
            RemoveDuplicateBones();
            RemoveUnusedVertices();
        }

        public void GCInPlace()
        {
            RemoveUnusedVertices();
        }
    }
}