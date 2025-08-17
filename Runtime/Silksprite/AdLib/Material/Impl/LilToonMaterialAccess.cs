using System.Linq;
using Silksprite.AdLib.Material.Access;
using UnityEngine;

namespace Silksprite.AdLib.Material.Impl
{
    public class LilToonMaterialAccess : ShaderMaterialAccessBase
    {
        public LilToonMaterialAccess(IMaterialAccess access) : base(access)
        {
        }

        // Basic Properties
        public IMaterialPropertyAccess<Color> MainColor => MaterialAccess.Color("_Color");
        public IMaterialTexturePropertyAccess<Texture2D> MainTex => MaterialAccess.Texture2D("_MainTex");
        public IMaterialPropertyAccess<Vector4> MainTexScrollRotate => MaterialAccess.Vector4("_MainTex_ScrollRotate");
        public IMaterialPropertyAccess<LilToonEnums.CullMode> Cull => MaterialAccess.FloatEnum<LilToonEnums.CullMode>("_Cull");

        // Shadow Properties
        public IMaterialPropertyAccess<bool> UseShadow => MaterialAccess.FloatBool("_UseShadow");
        public IMaterialPropertyAccess<Color> ShadowColor => MaterialAccess.Color("_ShadowColor");
        public IMaterialTexturePropertyAccess<Texture2D> ShadowColorTex => MaterialAccess.Texture2D("_ShadowColorTex");
        public IMaterialPropertyAccess<float> ShadowStrength => MaterialAccess.Float("_ShadowStrength");
        public IMaterialTexturePropertyAccess<Texture2D> ShadowStrengthMask => MaterialAccess.Texture2D("_ShadowStrengthMask");
        public IMaterialPropertyAccess<float> ShadowMainStrength => MaterialAccess.Float("_ShadowMainStrength");
        public IMaterialPropertyAccess<float> ShadowBorder => MaterialAccess.Float("_ShadowBorder");
        public IMaterialPropertyAccess<float> ShadowBlur => MaterialAccess.Float("_ShadowBlur");
        public IMaterialTexturePropertyAccess<Texture2D> ShadowBorderMask => MaterialAccess.Texture2D("_ShadowBorderMask");

        // Bump Map Properties
        public IMaterialPropertyAccess<bool> UseBumpMap => MaterialAccess.FloatBool("_UseBumpMap");
        public IMaterialTexturePropertyAccess<Texture2D> BumpMap => MaterialAccess.Texture2D("_BumpMap");
        public IMaterialPropertyAccess<float> BumpScale => MaterialAccess.Float("_BumpScale");

        // Emission Properties
        public IMaterialPropertyAccess<bool> UseEmission => MaterialAccess.FloatBool("_UseEmission");
        public IMaterialPropertyAccess<Color> EmissionColor => MaterialAccess.Color("_EmissionColor");
        public IMaterialTexturePropertyAccess<Texture2D> EmissionMap => MaterialAccess.Texture2D("_EmissionMap");

        // Rim Properties
        public IMaterialPropertyAccess<bool> UseRim => MaterialAccess.FloatBool("_UseRim");
        public IMaterialPropertyAccess<Color> RimColor => MaterialAccess.Color("_RimColor");
        public IMaterialTexturePropertyAccess<Texture2D> RimColorTex => MaterialAccess.Texture2D("_RimColorTex");
        public IMaterialPropertyAccess<float> RimEnableLighting => MaterialAccess.Float("_RimEnableLighting");
        public IMaterialPropertyAccess<float> RimFresnelPower => MaterialAccess.Float("_RimFresnelPower");
        public IMaterialPropertyAccess<float> RimBlur => MaterialAccess.Float("_RimBlur");
        public IMaterialPropertyAccess<float> RimBorder => MaterialAccess.Float("_RimBorder");

        // MatCap Properties
        public IMaterialPropertyAccess<bool> UseMatCap => MaterialAccess.FloatBool("_UseMatCap");
        public IMaterialTexturePropertyAccess<Texture2D> MatCapTex => MaterialAccess.Texture2D("_MatCapTex");
        public IMaterialPropertyAccess<LilToonEnums.BlendMode> MatCapBlendMode => MaterialAccess.FloatEnum<LilToonEnums.BlendMode>("_MatCapBlendMode");

        // Outline Properties
        public IMaterialTexturePropertyAccess<Texture2D> OutlineWidthMask => MaterialAccess.Texture2D("_OutlineWidthMask");
        public IMaterialPropertyAccess<float> OutlineWidth => MaterialAccess.Float("_OutlineWidth");
        public IMaterialPropertyAccess<Color> OutlineColor => MaterialAccess.Color("_OutlineColor");

        // Rendering Properties
        public IMaterialPropertyAccess<float> Cutoff => MaterialAccess.Float("_Cutoff");
        public IMaterialPropertyAccess<bool> ZWrite => MaterialAccess.FloatBool("_ZWrite");
        
        // Shader Variants Accessor
        public bool IsMultiVariants => MaterialAccess.Targets.All(m => m.shader != MaterialAccess.Target.shader);

        public bool IsCutout => MaterialAccess.Target.shader.name.Contains("Cutout");
        public bool IsTransparent => MaterialAccess.Target.shader.name.Contains("Transparent") || MaterialAccess.Target.shader.name.Contains("Overlay");
        public bool IsOutl => !IsMultiVariants && MaterialAccess.Target.shader.name.Contains("Outline");
    }
}
