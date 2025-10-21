using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Silksprite.AdLib.Mesh.Extensions
{
    public static class MutableMeshExtension
    {
        public static void BakeBlendShapes(this MutableMesh mesh, Dictionary<string, float> values)
        {
            var blendShapes = mesh.BlendShapes;
            foreach (var (shapeName, shapeValue) in values)
            {
                if (blendShapes.FirstOrDefault(bs => bs.BlendShapeName == shapeName) is not { } blendShape)
                {
                    continue;
                }
                if (blendShape.SingleFrames.FirstOrDefault() is not { } frame)
                {
                    continue;
                }
                var weight = shapeValue / frame.FrameWeight;
                for (var i = 0; i < mesh.Vertices.Count; i++)
                {
                    mesh.Vertices[i] += frame.DeltaVertices[i] * weight;
                    mesh.Normals[i] += frame.DeltaNormals[i] * weight;
                    mesh.Tangents[i] += (Vector4)frame.DeltaTangents[i] * weight;
                }
            }
            mesh.ModifyBlendShapes(blendShape => values.ContainsKey(blendShape.BlendShapeName) ? null : blendShape);
        }

        public static void ModifyBlendShapes(this MutableMesh mesh, Func<MutableBlendShape, MutableBlendShape> modifier)
        {
            var blendShapes = mesh.BlendShapes.ToArray();
            mesh.BlendShapes.Clear();
            mesh.BlendShapes.AddRange(blendShapes.Select(modifier).Where(blendShape => blendShape != null));
        }

        public static MutableMeshState<Transform, UnityEngine.Material> ToMutableMeshState(this SkinnedMeshRenderer source)
        {
            return new MutableMeshState<Transform, UnityEngine.Material>(
                source.sharedMesh,
                Enumerable.Range(0, source.sharedMesh.blendShapeCount).Select(source.GetBlendShapeWeight),
                MutableBoneMapping.From(source),
                source.sharedMaterials);
        }

        public static void Add(this MutableMeshState<Transform, UnityEngine.Material> mutableMeshState, SkinnedMeshRenderer skinnedMeshRenderer)
        {
            mutableMeshState.Add(skinnedMeshRenderer.sharedMesh, MutableBoneMapping.From(skinnedMeshRenderer), skinnedMeshRenderer.sharedMaterials);
        }
    }
}