using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ReflectionAccess("ABI.CCK.Scripts.CVRAdvancesAvatarSettingBase", "Assembly-CSharp")]
    public class CVRAdvancesAvatarSettingBaseAccess : ObjectAccessBase<object>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancesAvatarSettingBase");
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public CVRAdvancesAvatarSettingBaseAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancesAvatarSettingBaseAccess(object baseObject) : base(baseObject) { }
        public static CVRAdvancesAvatarSettingBaseAccess? Nullable(object? baseObject) => baseObject != null ? new CVRAdvancesAvatarSettingBaseAccess(baseObject) : null;
        
        // EnumAccess Field
        public CVRAdvancesAvatarSettingBaseClass.ParameterTypeAccess.EnumValues usedType
        {
            get => CVRAdvancesAvatarSettingBaseClass.ParameterTypeAccess.Shared.ToAccess(CachedType.GetFieldValueOf(BaseObject, nameof(usedType)));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(usedType), CVRAdvancesAvatarSettingBaseClass.ParameterTypeAccess.Shared.ToActual(value));
        }
        
        // Direct Field
        public int currentEntryIndex
        {
            get => (int)CachedType.GetFieldValueOf(BaseObject, nameof(currentEntryIndex));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(currentEntryIndex), value);
        }
    }
}
