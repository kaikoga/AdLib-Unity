using Silksprite.AdLib.Material.Access;
using UnityEngine;

namespace Silksprite.AdLib.Material.Impl
{
    public class MToon10MaterialAccess
    {
        readonly IMaterialAccess _access;

        public MToon10MaterialAccess(IMaterialAccess access) => _access = access;
        
        public IMaterialPropertyAccess<MToon10Enums.MToon10AlphaMode> AlphaMode => _access.FloatEnum<MToon10Enums.MToon10AlphaMode>("_AlphaMode");
        public IMaterialPropertyAccess<MToon10Enums.MToon10TransparentWithZWriteMode> TransparentWithZWrite => _access.FloatEnum<MToon10Enums.MToon10TransparentWithZWriteMode>("_TransparentWithZWrite");
        public IMaterialPropertyAccess<float> AlphaCutoff => _access.Float("_Cutoff");
        public IMaterialPropertyAccess<float> RenderQueueOffsetNumber => _access.Float("_RenderQueueOffset");
        public IMaterialPropertyAccess<MToon10Enums.MToon10DoubleSidedMode> DoubleSided => _access.FloatEnum<MToon10Enums.MToon10DoubleSidedMode>("_DoubleSided");
        
        public IMaterialPropertyAccess<Texture2D> MainTex => _access.Texture2D("_MainTex");
        public IMaterialPropertyAccess<Color> Color => _access.Color("_Color");
        public IMaterialPropertyAccess<Texture2D> ShadeTex => _access.Texture2D("_ShadeTex");
        public IMaterialPropertyAccess<Color> ShadeColor => _access.Color("_ShadeColor");
        public IMaterialPropertyAccess<Texture2D> BumpMap => _access.Texture2D("_BumpMap");
        public IMaterialPropertyAccess<float> BumpScale => _access.Float("_BumpScale");

        public IMaterialPropertyAccess<float> ShadingToonyFactor => _access.Float("_ShadingToonyFactor");
        public IMaterialPropertyAccess<float> ShadingShiftFactor => _access.Float("_ShadingShiftFactor");

        public IMaterialPropertyAccess<Texture2D> EmissionMap => _access.Texture2D("_EmissionMap");
        public IMaterialPropertyAccess<Color> EmissionColor => _access.Color("_EmissionColor");
        public IMaterialPropertyAccess<Texture2D> MatcapTex => _access.Texture2D("_MatcapTex");

        public IMaterialPropertyAccess<float> GiEqualization => _access.Float("_GiEqualization");

        public IMaterialPropertyAccess<Color> RimColor => _access.Color("_RimColor");
        public IMaterialPropertyAccess<float> RimFresnelPower => _access.Float("_RimFresnelPower");
        public IMaterialPropertyAccess<float> RimLift => _access.Float("_RimLift");
        public IMaterialPropertyAccess<Texture2D> RimTex => _access.Texture2D("_RimTex");
        public IMaterialPropertyAccess<float> RimLightingMix => _access.Float("_RimLightingMix");

        public IMaterialPropertyAccess<MToon10Enums.MToon10OutlineMode> OutlineWidthMode => _access.FloatEnum<MToon10Enums.MToon10OutlineMode>("_OutlineWidthMode");
        public IMaterialPropertyAccess<float> OutlineWidth => _access.Float("_OutlineWidth");
        public IMaterialPropertyAccess<Color> OutlineColor => _access.Color("_OutlineColor");
        public IMaterialPropertyAccess<float> OutlineLightingMix => _access.Float("_OutlineLightingMix");
        public IMaterialPropertyAccess<Texture2D> OutlineWidthTex => _access.Texture2D("_OutlineWidthTex");

        public IMaterialPropertyAccess<Texture2D> UvAnimMaskTex => _access.Texture2D("_UvAnimMaskTex");
        public IMaterialPropertyAccess<float> UvAnimScrollXSpeed => _access.Float("_UvAnimScrollXSpeed");
        public IMaterialPropertyAccess<float> UvAnimScrollYSpeed => _access.Float("_UvAnimScrollYSpeed");
        public IMaterialPropertyAccess<float> UvAnimRotationSpeed => _access.Float("_UvAnimRotationSpeed");
    }
}
