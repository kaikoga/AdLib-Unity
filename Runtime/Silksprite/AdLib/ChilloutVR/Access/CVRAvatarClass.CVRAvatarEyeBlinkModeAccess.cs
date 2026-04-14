using System;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class CVRAvatarClass
    {
        [ReflectionAccess("ABI.CCK.Components.CVRAvatar+CVRAvatarEyeBlinkMode", "ABI.CCK.Components")]
        public class CVRAvatarEyeBlinkModeAccess : EnumAccessBase<CVRAvatarEyeBlinkModeAccess.EnumValues>
        {
            static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.CVRAvatar+CVRAvatarEyeBlinkMode");
            public static Type ActualType => CachedType.ActualType;

            public static readonly CVRAvatarEyeBlinkModeAccess Shared = new CVRAvatarEyeBlinkModeAccess();
            CVRAvatarEyeBlinkModeAccess() : base(CachedType) { }

            public enum EnumValues
            {
                Combined = 0,
                Separate = 1,
            }
        }
    }
}
