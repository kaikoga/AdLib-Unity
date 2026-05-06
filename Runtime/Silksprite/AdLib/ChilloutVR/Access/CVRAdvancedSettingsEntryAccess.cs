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
    [ReflectionAccess("ABI.CCK.Scripts.CVRAdvancedSettingsEntry", "Assembly-CSharp")]
    public class CVRAdvancedSettingsEntryAccess : ObjectAccessBase<object>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancedSettingsEntry");
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public CVRAdvancedSettingsEntryAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancedSettingsEntryAccess(object baseObject) : base(baseObject) { }
        public static CVRAdvancedSettingsEntryAccess? Nullable(object? baseObject) => baseObject != null ? new CVRAdvancedSettingsEntryAccess(baseObject) : null;
        
        // Direct Field
        public bool isCollapsed
        {
            get => (bool)CachedType.GetFieldValueOf(BaseObject, nameof(isCollapsed));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(isCollapsed), value);
        }
        
        // Direct Field
        public bool unlinkNameFromMachineName
        {
            get => (bool)CachedType.GetFieldValueOf(BaseObject, nameof(unlinkNameFromMachineName));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(unlinkNameFromMachineName), value);
        }
        
        // Direct Field
        public bool isAutogenCollapsed
        {
            get => (bool)CachedType.GetFieldValueOf(BaseObject, nameof(isAutogenCollapsed));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(isAutogenCollapsed), value);
        }
        
        // EnumAccess Field
        public CVRAdvancedSettingsEntryClass.SettingsTypeAccess.EnumValues type
        {
            get => CVRAdvancedSettingsEntryClass.SettingsTypeAccess.Shared.ToAccess(CachedType.GetFieldValueOf(BaseObject, nameof(type)));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(type), CVRAdvancedSettingsEntryClass.SettingsTypeAccess.Shared.ToActual(value));
        }
        
        // Access Field
        public CVRAdvancesAvatarSettingGameObjectToggleAccess? toggleSettings
        {
            get => CVRAdvancesAvatarSettingGameObjectToggleAccess.Nullable(CachedType.GetFieldValueOf(BaseObject, nameof(toggleSettings)));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(toggleSettings), value?.BaseObject);
        }
        
        // CVRAdvancedAvatarSettingMaterialColor materialColorSettings
        
        // Access Field
        public CVRAdvancesAvatarSettingGameObjectDropdownAccess? dropDownSettings
        {
            get => CVRAdvancesAvatarSettingGameObjectDropdownAccess.Nullable(CachedType.GetFieldValueOf(BaseObject, nameof(dropDownSettings)));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(dropDownSettings), value?.BaseObject);
        }
        
        // Access Field
        public CVRAdvancesAvatarSettingSliderAccess? sliderSettings
        {
            get => CVRAdvancesAvatarSettingSliderAccess.Nullable(CachedType.GetFieldValueOf(BaseObject, nameof(sliderSettings)));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(sliderSettings), value?.BaseObject);
        }
        
        // Access Field
        public CVRAdvancesAvatarSettingJoystick2DAccess? joystick2DSetting
        {
            get => CVRAdvancesAvatarSettingJoystick2DAccess.Nullable(CachedType.GetFieldValueOf(BaseObject, nameof(joystick2DSetting)));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(joystick2DSetting), value?.BaseObject);
        }
        
        // CVRAdvancesAvatarSettingJoystick3D joystick3DSetting
        
        // Access Field
        public CVRAdvancesAvatarSettingInputSingleAccess? inputSingleSettings
        {
            get => CVRAdvancesAvatarSettingInputSingleAccess.Nullable(CachedType.GetFieldValueOf(BaseObject, nameof(inputSingleSettings)));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(inputSingleSettings), value?.BaseObject);
        }
        
        // CVRAdvancesAvatarSettingInputVector2 inputVector2Settings
        
        // CVRAdvancesAvatarSettingInputVector3 inputVector3Settings
        
        // Direct Field
        public string? name
        {
            get => (string)CachedType.GetFieldValueOf(BaseObject, nameof(name));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(name), value);
        }
        
        // Direct Field
        public string? machineName
        {
            get => (string)CachedType.GetFieldValueOf(BaseObject, nameof(machineName));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(machineName), value);
        }
        
        // Access Property
        public CVRAdvancesAvatarSettingBaseAccess? setting
        {
            get => CVRAdvancesAvatarSettingBaseAccess.Nullable(CachedType.GetPropertyValueOf(BaseObject, nameof(setting)));
            set => CachedType.SetPropertyValueOf(BaseObject, nameof(setting), value?.BaseObject);
        }
    }
}
