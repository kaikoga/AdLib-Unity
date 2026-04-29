using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    public static partial class CVRAvatarClass
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        [ReflectionAccess("ABI.CCK.Components.CVRAvatar+CVRAvatarEyeBlinkMode", "Assembly-CSharp")]
        public class CVRAvatarEyeBlinkModeAccess : EnumAccessBase<CVRAvatarEyeBlinkModeAccess.EnumValues>
        {
            static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.CVRAvatar+CVRAvatarEyeBlinkMode");
            public static Type ActualType => CachedType.ActualType;
            public static bool IsImplemented => CachedType.IsImplemented;
            
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
