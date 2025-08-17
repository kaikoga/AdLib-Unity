using Silksprite.AdLib.Material.Access;
using UnityEngine;

namespace Silksprite.AdLib.Material.Impl
{
    public class MToonMaterialAccess
    {
        readonly IMaterialAccess _access;

        public MToonMaterialAccess(IMaterialAccess access) => _access = access;

        public IMaterialPropertyAccess<MToonEnums.RenderMode> BlendMode => _access.FloatEnum<MToonEnums.RenderMode>("_BlendMode");
        public IMaterialPropertyAccess<MToonEnums.CullMode> CullMode => _access.FloatEnum<MToonEnums.CullMode>("_CullMode");

        public IMaterialPropertyAccess<Texture2D> MainTex => _access.Texture2D("_MainTex");
        public IMaterialPropertyAccess<Color> Color => _access.Color("_Color");
        public IMaterialPropertyAccess<Texture2D> ShadeTexture => _access.Texture2D("_ShadeTexture");
        public IMaterialPropertyAccess<Color> ShadeColor => _access.Color("_ShadeColor");
        public IMaterialPropertyAccess<float> Cutoff => _access.Float("_Cutoff");
        public IMaterialPropertyAccess<Texture2D> BumpMap => _access.Texture2D("_BumpMap");
        public IMaterialPropertyAccess<float> BumpScale => _access.Float("_BumpScale");

        public IMaterialPropertyAccess<float> ShadeToony => _access.Float("_ShadeToony");
        public IMaterialPropertyAccess<float> ShadeShift => _access.Float("_ShadeShift");

        public IMaterialPropertyAccess<Texture2D> EmissionMap => _access.Texture2D("_EmissionMap");
        public IMaterialPropertyAccess<Color> EmissionColor => _access.Color("_EmissionColor");
        public IMaterialPropertyAccess<Texture2D> SphereAdd => _access.Texture2D("_SphereAdd");

        public IMaterialPropertyAccess<float> IndirectLightIntensity => _access.Float("_IndirectLightIntensity");

        public IMaterialPropertyAccess<Color> RimColor => _access.Color("_RimColor");
        public IMaterialPropertyAccess<Texture2D> RimTexture => _access.Texture2D("_RimTexture");
        public IMaterialPropertyAccess<float> RimLightingMix => _access.Float("_RimLightingMix");
        public IMaterialPropertyAccess<float> RimFresnelPower => _access.Float("_RimFresnelPower");
        public IMaterialPropertyAccess<float> RimLift => _access.Float("_RimLift");

        public IMaterialPropertyAccess<MToonEnums.OutlineWidthMode> OutlineWidthMode => _access.FloatEnum<MToonEnums.OutlineWidthMode>("_OutlineWidthMode");
        public IMaterialPropertyAccess<float> OutlineWidth => _access.Float("_OutlineWidth");
        public IMaterialPropertyAccess<Color> OutlineColor => _access.Color("_OutlineColor");
        public IMaterialPropertyAccess<float> OutlineLightingMix => _access.Float("_OutlineLightingMix");
        public IMaterialPropertyAccess<Texture2D> OutlineWidthTexture => _access.Texture2D("_OutlineWidthTexture");

        public IMaterialPropertyAccess<Texture2D> UvAnimMaskTexture => _access.Texture2D("_UvAnimMaskTexture");
        public IMaterialPropertyAccess<float> UvAnimScrollX => _access.Float("_UvAnimScrollX");
        public IMaterialPropertyAccess<float> UvAnimScrollY => _access.Float("_UvAnimScrollY");
        public IMaterialPropertyAccess<float> UvAnimRotation => _access.Float("_UvAnimRotation");
    }
}
