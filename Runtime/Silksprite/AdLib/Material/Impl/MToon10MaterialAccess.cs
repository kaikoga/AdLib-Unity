using Silksprite.AdLib.Material.Access;
using UnityEngine;

namespace Silksprite.AdLib.Material.Impl
{
    public class MToon10MaterialAccess : ShaderMaterialAccessBase
    {
        public MToon10MaterialAccess(IMaterialAccess access) : base(access)
        {
        }

        public IMaterialPropertyAccess<MToon10Enums.MToon10AlphaMode> AlphaMode => MaterialAccess.FloatEnum<MToon10Enums.MToon10AlphaMode>("_AlphaMode");
        public IMaterialPropertyAccess<MToon10Enums.MToon10TransparentWithZWriteMode> TransparentWithZWrite => MaterialAccess.FloatEnum<MToon10Enums.MToon10TransparentWithZWriteMode>("_TransparentWithZWrite");
        public IMaterialPropertyAccess<float> AlphaCutoff => MaterialAccess.Float("_Cutoff");
        public IMaterialPropertyAccess<float> RenderQueueOffsetNumber => MaterialAccess.Float("_RenderQueueOffset");
        public IMaterialPropertyAccess<MToon10Enums.MToon10DoubleSidedMode> DoubleSided => MaterialAccess.FloatEnum<MToon10Enums.MToon10DoubleSidedMode>("_DoubleSided");
        
        public IMaterialTexturePropertyAccess<Texture2D> MainTex => MaterialAccess.Texture2D("_MainTex");
        public IMaterialPropertyAccess<Color> Color => MaterialAccess.Color("_Color");
        public IMaterialTexturePropertyAccess<Texture2D> ShadeTex => MaterialAccess.Texture2D("_ShadeTex");
        public IMaterialPropertyAccess<Color> ShadeColor => MaterialAccess.Color("_ShadeColor");
        public IMaterialTexturePropertyAccess<Texture2D> BumpMap => MaterialAccess.Texture2D("_BumpMap");
        public IMaterialPropertyAccess<float> BumpScale => MaterialAccess.Float("_BumpScale");

        public IMaterialPropertyAccess<float> ShadingToonyFactor => MaterialAccess.Float("_ShadingToonyFactor");
        public IMaterialPropertyAccess<float> ShadingShiftFactor => MaterialAccess.Float("_ShadingShiftFactor");

        public IMaterialTexturePropertyAccess<Texture2D> EmissionMap => MaterialAccess.Texture2D("_EmissionMap");
        public IMaterialPropertyAccess<Color> EmissionColor => MaterialAccess.Color("_EmissionColor");
        public IMaterialTexturePropertyAccess<Texture2D> MatcapTex => MaterialAccess.Texture2D("_MatcapTex");

        public IMaterialPropertyAccess<float> GiEqualization => MaterialAccess.Float("_GiEqualization");

        public IMaterialPropertyAccess<Color> RimColor => MaterialAccess.Color("_RimColor");
        public IMaterialPropertyAccess<float> RimFresnelPower => MaterialAccess.Float("_RimFresnelPower");
        public IMaterialPropertyAccess<float> RimLift => MaterialAccess.Float("_RimLift");
        public IMaterialTexturePropertyAccess<Texture2D> RimTex => MaterialAccess.Texture2D("_RimTex");
        public IMaterialPropertyAccess<float> RimLightingMix => MaterialAccess.Float("_RimLightingMix");

        public IMaterialPropertyAccess<MToon10Enums.MToon10OutlineMode> OutlineWidthMode => MaterialAccess.FloatEnum<MToon10Enums.MToon10OutlineMode>("_OutlineWidthMode");
        public IMaterialPropertyAccess<float> OutlineWidth => MaterialAccess.Float("_OutlineWidth");
        public IMaterialPropertyAccess<Color> OutlineColor => MaterialAccess.Color("_OutlineColor");
        public IMaterialPropertyAccess<float> OutlineLightingMix => MaterialAccess.Float("_OutlineLightingMix");
        public IMaterialTexturePropertyAccess<Texture2D> OutlineWidthTex => MaterialAccess.Texture2D("_OutlineWidthTex");

        public IMaterialTexturePropertyAccess<Texture2D> UvAnimMaskTex => MaterialAccess.Texture2D("_UvAnimMaskTex");
        public IMaterialPropertyAccess<float> UvAnimScrollXSpeed => MaterialAccess.Float("_UvAnimScrollXSpeed");
        public IMaterialPropertyAccess<float> UvAnimScrollYSpeed => MaterialAccess.Float("_UvAnimScrollYSpeed");
        public IMaterialPropertyAccess<float> UvAnimRotationSpeed => MaterialAccess.Float("_UvAnimRotationSpeed");
    }
}
