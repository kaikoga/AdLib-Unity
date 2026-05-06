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
    [ReflectionAccess("ABI.CCK.Scripts.CVRAdvancesAvatarSettingGameObjectDropdown", "Assembly-CSharp")]
    public class CVRAdvancesAvatarSettingGameObjectDropdownAccess : CVRAdvancesAvatarSettingBaseAccess
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancesAvatarSettingGameObjectDropdown");
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public CVRAdvancesAvatarSettingGameObjectDropdownAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancesAvatarSettingGameObjectDropdownAccess(object baseObject) : base(baseObject) { }
        public static CVRAdvancesAvatarSettingGameObjectDropdownAccess? Nullable(object? baseObject) => baseObject != null ? new CVRAdvancesAvatarSettingGameObjectDropdownAccess(baseObject) : null;
        
        // Direct Field
        public int defaultValue
        {
            get => (int)CachedType.GetFieldValueOf(BaseObject, nameof(defaultValue));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(defaultValue), value);
        }
        
        // AccessList Field
        public List<CVRAdvancedSettingsDropDownEntryAccess?>? options
        {
            get => CachedType.GetFieldValueOf(BaseObject, nameof(options)).ToAccessList(CVRAdvancedSettingsDropDownEntryAccess.Nullable);
            set => CachedType.SetFieldValueOf(BaseObject, nameof(options), value?.ToDynamicList(CVRAdvancedSettingsDropDownEntryAccess.ActualType));
        }
        
        // ReorderableList reorderableList
        
        // Direct Property
        public string?[]? optionNames
        {
            get => (string[])CachedType.GetPropertyValueOf(BaseObject, nameof(optionNames));
        }
    }
}
