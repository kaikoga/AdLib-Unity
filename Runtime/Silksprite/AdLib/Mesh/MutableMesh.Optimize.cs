using System;
using System.Collections.Generic;
using System.Linq;

namespace Silksprite.AdLib.Mesh
{
    public partial class MutableMesh
    {
        public void MergeSubMeshes(int[][] subMeshMapping)
        {
            var oldSubMeshes = SubMeshes.ToArray();
            SubMeshes.Clear();
            SubMeshes.AddRange(subMeshMapping.Select(indices =>
            {
                return indices.SelectMany(i => oldSubMeshes[i].Indices);
            }).Select(indices => new MutableSubMesh(indices)));
        }

        public void RemapBones(Func<MutableBone, MutableBone> remapFunc)
        {
            foreach (var boneWeights in BoneWeights)
            {
                for (var i = 0; i < boneWeights.BoneWeights.Count; i++)
                {
                    var bw = boneWeights.BoneWeights[i];
                    bw.bone = remapFunc(bw.bone);
                    boneWeights.BoneWeights[i] = bw;
                }
            }
        }

        public void RemoveUnusedVertices()
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
            foreach (var frame in BlendShapes.SelectMany(blendShape => blendShape.SingleFrames))
            {
                FilterVertices(frame.DeltaVertices);
                FilterVertices(frame.DeltaNormals);
                FilterVertices(frame.DeltaTangents);
            }
            
            foreach (var subMesh in SubMeshes) MapIndices(subMesh.Indices);
        }

        public void GCInPlace()
        {
            RemoveUnusedVertices();
        }
    }
}