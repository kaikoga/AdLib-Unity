using Silksprite.AdLib.Material.Access;
using UnityEngine;

namespace Silksprite.AdLib.Material.Impl
{
    public class MToonMaterialAccess : ShaderMaterialAccessBase
    {
        public MToonMaterialAccess(IMaterialAccess access) : base(access)
        {
        }

        // System Properties 
        public IMaterialPropertyAccess<float> MToonVersion => MaterialAccess.Float("_MToonVersion");
        public IMaterialPropertyAccess<float> DebugMode => MaterialAccess.Float("_DebugMode");

        // Rendering Properties
        public IMaterialPropertyAccess<MToonEnums.RenderMode> BlendMode => MaterialAccess.FloatEnum<MToonEnums.RenderMode>("_BlendMode");
        public IMaterialPropertyAccess<MToonEnums.CullMode> CullMode => MaterialAccess.FloatEnum<MToonEnums.CullMode>("_CullMode");
        public IMaterialPropertyAccess<float> SrcBlend => MaterialAccess.Float("_SrcBlend");
        public IMaterialPropertyAccess<float> DstBlend => MaterialAccess.Float("_DstBlend");
        public IMaterialPropertyAccess<float> ZWrite => MaterialAccess.Float("_ZWrite");
        public IMaterialPropertyAccess<float> AlphaToMask => MaterialAccess.Float("_AlphaToMask");

        // Main Properties
        public IMaterialTexturePropertyAccess<Texture2D> MainTex => MaterialAccess.Texture2D("_MainTex");
        public IMaterialPropertyAccess<Color> Color => MaterialAccess.Color("_Color");
        public IMaterialTexturePropertyAccess<Texture2D> ShadeTexture => MaterialAccess.Texture2D("_ShadeTexture");
        public IMaterialPropertyAccess<Color> ShadeColor => MaterialAccess.Color("_ShadeColor");
        public IMaterialPropertyAccess<float> Cutoff => MaterialAccess.Float("_Cutoff");
        public IMaterialPropertyAccess<Texture2D> BumpMap => MaterialAccess.Texture2D("_BumpMap");
        public IMaterialPropertyAccess<float> BumpScale => MaterialAccess.Float("_BumpScale");

        // Shading Properties
        public IMaterialPropertyAccess<float> ShadeToony => MaterialAccess.Float("_ShadeToony");
        public IMaterialPropertyAccess<float> ShadeShift => MaterialAccess.Float("_ShadeShift");
        public IMaterialPropertyAccess<float> LightColorAttenuation => MaterialAccess.Float("_LightColorAttenuation");
        public IMaterialPropertyAccess<float> IndirectLightIntensity => MaterialAccess.Float("_IndirectLightIntensity");

        // Shadow Properties
        public IMaterialPropertyAccess<float> ReceiveShadowRate => MaterialAccess.Float("_ReceiveShadowRate");
        public IMaterialTexturePropertyAccess<Texture2D> ReceiveShadowTexture => MaterialAccess.Texture2D("_ReceiveShadowTexture");
        public IMaterialPropertyAccess<float> ShadingGradeRate => MaterialAccess.Float("_ShadingGradeRate");
        public IMaterialTexturePropertyAccess<Texture2D> ShadingGradeTexture => MaterialAccess.Texture2D("_ShadingGradeTexture");

        // Emission Properties
        public IMaterialTexturePropertyAccess<Texture2D> EmissionMap => MaterialAccess.Texture2D("_EmissionMap");
        public IMaterialPropertyAccess<Color> EmissionColor => MaterialAccess.Color("_EmissionColor");
        public IMaterialTexturePropertyAccess<Texture2D> SphereAdd => MaterialAccess.Texture2D("_SphereAdd");

        // Rim Properties
        public IMaterialPropertyAccess<Color> RimColor => MaterialAccess.Color("_RimColor");
        public IMaterialTexturePropertyAccess<Texture2D> RimTexture => MaterialAccess.Texture2D("_RimTexture");
        public IMaterialPropertyAccess<float> RimLightingMix => MaterialAccess.Float("_RimLightingMix");
        public IMaterialPropertyAccess<float> RimFresnelPower => MaterialAccess.Float("_RimFresnelPower");
        public IMaterialPropertyAccess<float> RimLift => MaterialAccess.Float("_RimLift");

        // Outline Properties
        public IMaterialPropertyAccess<MToonEnums.OutlineWidthMode> OutlineWidthMode => MaterialAccess.FloatEnum<MToonEnums.OutlineWidthMode>("_OutlineWidthMode");
        public IMaterialPropertyAccess<float> OutlineWidth => MaterialAccess.Float("_OutlineWidth");
        public IMaterialPropertyAccess<Color> OutlineColor => MaterialAccess.Color("_OutlineColor");
        public IMaterialPropertyAccess<float> OutlineLightingMix => MaterialAccess.Float("_OutlineLightingMix");
        public IMaterialTexturePropertyAccess<Texture2D> OutlineWidthTexture => MaterialAccess.Texture2D("_OutlineWidthTexture");
        public IMaterialPropertyAccess<float> OutlineColorMode => MaterialAccess.Float("_OutlineColorMode");
        public IMaterialPropertyAccess<float> OutlineCullMode => MaterialAccess.Float("_OutlineCullMode");

        // UV Animation Properties
        public IMaterialTexturePropertyAccess<Texture2D> UvAnimMaskTexture => MaterialAccess.Texture2D("_UvAnimMaskTexture");
        public IMaterialPropertyAccess<float> UvAnimScrollX => MaterialAccess.Float("_UvAnimScrollX");
        public IMaterialPropertyAccess<float> UvAnimScrollY => MaterialAccess.Float("_UvAnimScrollY");
        public IMaterialPropertyAccess<float> UvAnimRotation => MaterialAccess.Float("_UvAnimRotation");
        
        // ReSharper disable InconsistentNaming
        // Keywords
        public IMaterialPropertyAccess<bool> ALPHATEST_ON => MaterialAccess.Keyword("_ALPHATEST_ON");
        public IMaterialPropertyAccess<bool> ALPHABLEND_ON => MaterialAccess.Keyword("_ALPHABLEND_ON");
        public IMaterialPropertyAccess<bool> MTOON_OUTLINE_WIDTH_WORLD => MaterialAccess.Keyword("_MTOON_OUTLINE_WIDTH_WORLD");
        public IMaterialPropertyAccess<bool> MTOON_OUTLINE_COLOR_MIXED => MaterialAccess.Keyword("_MTOON_OUTLINE_COLOR_MIXED");
        // ReSharper restore InconsistentNaming
    }
}
