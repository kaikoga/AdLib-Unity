using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

namespace Silksprite.AdLib.Mesh.Extensions
{
    internal static class MeshExtension
    {
        internal static IEnumerable<MutableBlendShape> MutableBlendShapes(this UnityEngine.Mesh mesh)
        {
            var blendShapes = Enumerable.Range(0, mesh.blendShapeCount)
                .SelectMany(blendShapeIndex => Enumerable.Range(0, mesh.GetBlendShapeFrameCount(blendShapeIndex)).Select(blendShapeFrameIndex => (blendShapeIndex, blendShapeFrameIndex)))
                .Select(ic =>
                {
                    var (blendShapeIndex, blendShapeFrameIndex) = ic;
                    var blendShapeName = mesh.GetBlendShapeName(blendShapeIndex);
                    var frameWeight = mesh.GetBlendShapeFrameWeight(blendShapeIndex, blendShapeFrameIndex);
                    var deltaVertices = new Vector3[mesh.vertexCount];
                    var deltaNormals = new Vector3[mesh.vertexCount];
                    var deltaTangents = new Vector3[mesh.vertexCount];
                    mesh.GetBlendShapeFrameVertices(blendShapeIndex, blendShapeFrameIndex, deltaVertices, deltaNormals, deltaTangents);
                    return new MutableBlendShape(blendShapeName, frameWeight, deltaVertices, deltaNormals, deltaTangents);
                });
            return blendShapes;
        }

        internal static IEnumerable<MutableBoneWeight<TBone>> GetBoneWeights<TBone>(this UnityEngine.Mesh mesh, MutableBoneMapping<TBone> bones)
        {
            var nativeBoneCounts = mesh.GetBonesPerVertex();
            var nativeBoneWeights = mesh.GetAllBoneWeights();
            var weights = new List<(MutableBone<TBone> bone, float weight)>();
            var p = 0;
            foreach (var c in nativeBoneCounts)
            {
                weights.Clear();
                for (var i = 0; i < c; i++)
                {
                    var weight = nativeBoneWeights[p++];
                    weights.Add((bones.Bone(weight.boneIndex), weight.weight));
                }
                yield return new MutableBoneWeight<TBone>(weights);
            }
        }

        
        internal static void SetBoneWeights<TBone>(this UnityEngine.Mesh mesh, MutableBoneMapping<TBone> bones, ICollection<MutableBoneWeight<TBone>> boneWeights)
        {
            var nativeBoneCounts = new NativeArray<byte>(boneWeights.Count, Allocator.Temp);
            var nativeBoneWeights = new NativeArray<BoneWeight1>(boneWeights.Sum(bw => bw.Length), Allocator.Temp);

            var i = 0;
            var p = 0;
            foreach (var bw in boneWeights)
            {
                nativeBoneCounts[i++] = (byte) bw.Length;
                foreach (var bw1 in bw.ToBoneWeights(bones)) nativeBoneWeights[p++] = bw1;
            }
            mesh.SetBoneWeights(nativeBoneCounts, nativeBoneWeights);
        }
    }
}
