using System;
using System.Collections.Generic;
using System.Linq;
using Silksprite.AdLib.Mesh.View;
using UnityEngine;

namespace Silksprite.AdLib.Mesh.Extensions
{
    public static class MutableMeshStateExtension
    {
        public static MutableMeshStateView<TBone, TMaterial> View<TBone, TMaterial>(this MutableMeshState<TBone, TMaterial> meshState)
        {
            return new MutableMeshStateView<TBone, TMaterial>(meshState);
        }

        public static void BakeBlendShapes<TBone, TMaterial>(this MutableMeshState<TBone, TMaterial> meshState, Dictionary<string, float> values, BlendShapeCompactMode compactMode)
        {
            meshState.BakeBlendShapes(meshState.Mesh.GetBlendShapeWeightsByIndex(values), compactMode);
        }

        public static void BakeBlendShapes<TBone, TMaterial>(this MutableMeshState<TBone, TMaterial> meshState, Dictionary<int, float> values, BlendShapeCompactMode compactMode)
        {
            meshState.Mesh.BakeBlendShapes(values, compactMode);
            var blendShapeWeights = meshState.BlendShapeWeights.ToArray();
            meshState.BlendShapeWeights.Clear();
            switch (compactMode)
            {
                case BlendShapeCompactMode.None:
                    break;
                case BlendShapeCompactMode.Zero:
                    meshState.BlendShapeWeights.AddRange( blendShapeWeights
                        .Select((weight, i) => values.ContainsKey(i) ? 0f : weight));
                    break;
                case BlendShapeCompactMode.Compact:
                    meshState.BlendShapeWeights.AddRange( blendShapeWeights
                        .Select((bs, i) => (bs, i))
                        .Where(r => !values.ContainsKey(r.i))
                        .Select(r => r.bs));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(compactMode), compactMode, null);
            }
        }

        public static void ExportTo(this MutableMeshState<Transform, UnityEngine.Material> meshState, SkinnedMeshRenderer skinnedMeshRenderer, UnityEngine.Mesh mesh)
        {
            meshState.Mesh.ExportTo(mesh);
            skinnedMeshRenderer.sharedMesh = mesh;
            skinnedMeshRenderer.bones = meshState.Mesh.BoneList.Bones.Select(bone => meshState.BoneMapping.BoneObject(bone)).ToArray();
            var blendShapeWeights = meshState.BlendShapeWeights;
            for (var i = 0; i < blendShapeWeights.Count; i++)
            {
                skinnedMeshRenderer.SetBlendShapeWeight(i, blendShapeWeights[i]);
            }
            skinnedMeshRenderer.sharedMaterials = meshState.Materials.ToArray();
        }
    }
}