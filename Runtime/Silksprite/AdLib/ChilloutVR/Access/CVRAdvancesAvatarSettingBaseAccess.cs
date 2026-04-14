using System;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Base;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CVRAdvancesAvatarSettingBaseAccess : ObjectAccessBase<object>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancesAvatarSettingBase");
        public static Type ActualType => CachedType.ActualType;

        public CVRAdvancesAvatarSettingBaseAccess(object baseObject) : base(baseObject) { }

        public CVRAdvancesAvatarSettingBaseClass.ParameterTypeAccess.EnumValues usedType
        {
            get => CVRAdvancesAvatarSettingBaseClass.ParameterTypeAccess.Shared.ToAccess(DynamicObject.usedType);
            set => DynamicObject.usedType = CVRAdvancesAvatarSettingBaseClass.ParameterTypeAccess.Shared.ToActual(value);
        }
    }
}
