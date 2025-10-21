using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

namespace Silksprite.AdLib.Mesh.Extensions
{
    static class MeshExtension
    {
        internal static IEnumerable<MutableBlendShape> GetMutableBlendShapes(this UnityEngine.Mesh mesh)
        {
            return Enumerable.Range(0, mesh.blendShapeCount)
                .Select(blendShapeIndex =>
                {
                    var blendShape = new MutableBlendShape(mesh.GetBlendShapeName(blendShapeIndex));
                    blendShape.SingleFrames.AddRange(Enumerable.Range(mesh.GetBlendShapeFrameCount(blendShapeIndex) - 1, 1)
                        .Select(blendShapeFrameIndex =>
                        {
                            var frameWeight = mesh.GetBlendShapeFrameWeight(blendShapeIndex, blendShapeFrameIndex);
                            var deltaVertices = new Vector3[mesh.vertexCount];
                            var deltaNormals = new Vector3[mesh.vertexCount];
                            var deltaTangents = new Vector3[mesh.vertexCount];
                            mesh.GetBlendShapeFrameVertices(blendShapeIndex, blendShapeFrameIndex, deltaVertices, deltaNormals, deltaTangents);
                            return new MutableBlendShapeFrame(frameWeight, deltaVertices, deltaNormals, deltaTangents);
                        }));
                    return blendShape;
                });
        }

        internal static IEnumerable<MutableBoneWeight> GetMutableBoneWeights(this UnityEngine.Mesh mesh, MutableBoneList boneList)
        {
            var nativeBoneCounts = mesh.GetBonesPerVertex();
            var nativeBoneWeights = mesh.GetAllBoneWeights();
            var weights = new List<(MutableBone bone, float weight)>();
            var p = 0;
            foreach (var c in nativeBoneCounts)
            {
                weights.Clear();
                for (var i = 0; i < c; i++)
                {
                    var weight = nativeBoneWeights[p++];
                    // FIXME: bounds check
                    weights.Add((boneList.Bone(weight.boneIndex), weight.weight));
                }
                yield return new MutableBoneWeight(weights);
            }
        }

        internal static void SetBoneWeights(this UnityEngine.Mesh mesh, MutableBoneList boneList, ICollection<MutableBoneWeight> boneWeights)
        {
            var nativeBoneCounts = new NativeArray<byte>(boneWeights.Count, Allocator.Temp);
            var nativeBoneWeights = new NativeArray<BoneWeight1>(boneWeights.Sum(bw => bw.Length), Allocator.Temp);

            var i = 0;
            var p = 0;
            foreach (var bw in boneWeights)
            {
                nativeBoneCounts[i++] = (byte) bw.Length;
                foreach (var bw1 in bw.ToBoneWeights(boneList)) nativeBoneWeights[p++] = bw1;
            }
            mesh.SetBoneWeights(nativeBoneCounts, nativeBoneWeights);
        }
    }
}
