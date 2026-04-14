using System;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Base;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class CVRAdvancesAvatarSettingBaseClass
    {
        public class ParameterTypeAccess : EnumAccessBase<ParameterTypeAccess.EnumValues>
        {
            static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancesAvatarSettingBase+ParameterType");
            public static Type ActualType => CachedType.ActualType;

            public static readonly ParameterTypeAccess Shared = new ParameterTypeAccess();
            ParameterTypeAccess() : base(CachedType) { }

            public enum EnumValues
            {
                Float = 1,
                Int = 2,
                Bool = 3
            }
        }
    }
}
