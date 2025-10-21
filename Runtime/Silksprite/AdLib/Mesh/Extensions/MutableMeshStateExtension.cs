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