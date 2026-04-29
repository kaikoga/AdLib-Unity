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
    [ReflectionAccess("ABI.CCK.Scripts.CVRAdvancesAvatarSettingInputSingle", "Assembly-CSharp")]
    public class CVRAdvancesAvatarSettingInputSingleAccess : CVRAdvancesAvatarSettingBaseAccess
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancesAvatarSettingInputSingle");
        static CachedType CachedType___ => CachedType;
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public CVRAdvancesAvatarSettingInputSingleAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancesAvatarSettingInputSingleAccess(object baseObject) : base(baseObject) { }
        public static CVRAdvancesAvatarSettingInputSingleAccess? Nullable(object? baseObject) => baseObject != null ? new CVRAdvancesAvatarSettingInputSingleAccess(baseObject) : null;
        
        // Direct Field
        public float defaultValue
        {
            get => (float)CachedType___.GetFieldValueOf(BaseObject, nameof(defaultValue));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(defaultValue), value);
        }
    }
}
