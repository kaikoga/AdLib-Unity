using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Silksprite.AdLib.Mesh.Extensions
{
    public static class MutableMeshExtension
    {
        public static void BakeBlendShapes(this MutableMesh<Transform, Material> mesh, Dictionary<string, float> values)
        {
            var blendShapes = mesh.BlendShapes;
            foreach (var kv in values)
            {
                var shapeName = kv.Key;
                var shapeValue = kv.Value;
                var blendShape = blendShapes.Where(bs => bs.BlendShapeName == shapeName)
                    .OrderByDescending(bs => bs.FrameWeight).First(); // TODO: multiple blend shape frames support
                var weight = shapeValue / blendShape.FrameWeight;
                for (var i = 0; i < mesh.Vertices.Count; i++)
                {
                    mesh.Vertices[i] += blendShape.DeltaVertices[i] * weight;
                    mesh.Normals[i] += blendShape.DeltaNormals[i] * weight;
                    mesh.Tangents[i] += (Vector4)blendShape.DeltaTangents[i] * weight;
                }
            }
            mesh.ModifyBlendShapes(blendShape => values.ContainsKey(blendShape.BlendShapeName) ? null : blendShape);
        }

        public static void ModifyBlendShapes(this MutableMesh<Transform, Material> mesh, Func<MutableBlendShape, MutableBlendShape> modifier)
        {
            var blendShapes = mesh.BlendShapes.ToArray();
            mesh.BlendShapes.Clear();
            mesh.BlendShapes.AddRange(blendShapes.Select(modifier).Where(blendShape => blendShape != null));
        }

        public static MutableMesh<Transform, Material> ToMutableMesh(this SkinnedMeshRenderer source)
        {
            return new MutableMesh<Transform, Material>(source.sharedMesh, MutableBoneMapping.From(source), source.sharedMaterials);
        }

        public static void Add(this MutableMesh<Transform, Material> mutableMesh, SkinnedMeshRenderer skinnedMeshRenderer)
        {
            mutableMesh.Add(skinnedMeshRenderer.sharedMesh, MutableBoneMapping.From(skinnedMeshRenderer), skinnedMeshRenderer.sharedMaterials);
        }
    }
}