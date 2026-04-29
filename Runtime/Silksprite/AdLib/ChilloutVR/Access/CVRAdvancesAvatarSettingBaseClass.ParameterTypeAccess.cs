using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    public static partial class CVRAdvancesAvatarSettingBaseClass
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        [ReflectionAccess("ABI.CCK.Scripts.CVRAdvancesAvatarSettingBase+ParameterType", "Assembly-CSharp")]
        public class ParameterTypeAccess : EnumAccessBase<ParameterTypeAccess.EnumValues>
        {
            static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancesAvatarSettingBase+ParameterType");
            static CachedType CachedType___ => CachedType;
            public static Type ActualType => CachedType.ActualType;
            public static bool IsImplemented => CachedType.IsImplemented;
            
            public static readonly ParameterTypeAccess Shared = new ParameterTypeAccess();
            ParameterTypeAccess() : base(CachedType) { }
            
            public enum EnumValues
            {
                Float = 1,
                Int = 2,
                Bool = 3,
            }
        }
    }
}
