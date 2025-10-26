using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Silksprite.AdLib.Mesh.Extensions
{
    public static class MutableMeshExtension
    {
        public static Dictionary<int, float> GetBlendShapeWeightsByIndex(this MutableMesh mesh, Dictionary<string, float> values) =>
            values.Select(kv => (Key: mesh.GetBlendShapeIndex(kv.Key), kv.Value))
                .Where(kv => kv.Key >= 0)
                .ToDictionary(kv => kv.Key, kv => kv.Value);

        public static void BakeBlendShapes(this MutableMesh mesh, Dictionary<string, float> values, BlendShapeCompactMode compactMode)
        {
            mesh.BakeBlendShapes(mesh.GetBlendShapeWeightsByIndex(values), compactMode);
        }

        public static void BakeBlendShapes(this MutableMesh mesh, Dictionary<int, float> values, BlendShapeCompactMode compactMode)
        {
            var blendShapes = mesh.BlendShapes.ToArray();
            foreach (var (shapeIndex, shapeValue) in values)
            {
                var blendShape = blendShapes[shapeIndex];
                var frame = blendShape.GetState(shapeValue).BakeToFrame(0f);
                for (var i = 0; i < mesh.Vertices.Count; i++)
                {
                    mesh.Vertices[i] += frame.DeltaVertices[i];
                    mesh.Normals[i] += frame.DeltaNormals[i];
                    mesh.Tangents[i] += (Vector4)frame.DeltaTangents[i];
                }
            }
            mesh.BlendShapes.Clear();
            switch (compactMode)
            {
                case BlendShapeCompactMode.None:
                    break;
                case BlendShapeCompactMode.Zero:
                    mesh.BlendShapes.AddRange( blendShapes
                        .Select((bs, i) => values.ContainsKey(i) ? bs.ToZero() : bs));
                    break;
                case BlendShapeCompactMode.Compact:
                    mesh.BlendShapes.AddRange( blendShapes
                        .Select((bs, i) => (bs, i))
                        .Where(r => !values.ContainsKey(r.i))
                        .Select(r => r.bs));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(compactMode), compactMode, null);
            }
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