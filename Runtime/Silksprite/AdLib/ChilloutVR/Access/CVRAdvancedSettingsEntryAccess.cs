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
        static CachedType CachedType___ => CachedType;
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public CVRAdvancedSettingsEntryAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancedSettingsEntryAccess(object baseObject) : base(baseObject) { }
        public static CVRAdvancedSettingsEntryAccess? Nullable(object? baseObject) => baseObject != null ? new CVRAdvancedSettingsEntryAccess(baseObject) : null;
        
        // Direct Field
        public bool isCollapsed
        {
            get => (bool)CachedType___.GetFieldValueOf(BaseObject, nameof(isCollapsed));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(isCollapsed), value);
        }
        
        // Direct Field
        public bool unlinkNameFromMachineName
        {
            get => (bool)CachedType___.GetFieldValueOf(BaseObject, nameof(unlinkNameFromMachineName));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(unlinkNameFromMachineName), value);
        }
        
        // Direct Field
        public bool isAutogenCollapsed
        {
            get => (bool)CachedType___.GetFieldValueOf(BaseObject, nameof(isAutogenCollapsed));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(isAutogenCollapsed), value);
        }
        
        // EnumAccess Field
        public CVRAdvancedSettingsEntryClass.SettingsTypeAccess.EnumValues type
        {
            get => CVRAdvancedSettingsEntryClass.SettingsTypeAccess.Shared.ToAccess(CachedType___.GetFieldValueOf(BaseObject, nameof(type)));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(type), CVRAdvancedSettingsEntryClass.SettingsTypeAccess.Shared.ToActual___(value));
        }
        
        // Access Field
        public CVRAdvancesAvatarSettingGameObjectToggleAccess? toggleSettings
        {
            get => CVRAdvancesAvatarSettingGameObjectToggleAccess.Nullable(CachedType___.GetFieldValueOf(BaseObject, nameof(toggleSettings)));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(toggleSettings), value?.BaseObject);
        }
        
        // CVRAdvancedAvatarSettingMaterialColor materialColorSettings
        
        // CVRAdvancesAvatarSettingGameObjectDropdown dropDownSettings
        
        // Access Field
        public CVRAdvancesAvatarSettingSliderAccess? sliderSettings
        {
            get => CVRAdvancesAvatarSettingSliderAccess.Nullable(CachedType___.GetFieldValueOf(BaseObject, nameof(sliderSettings)));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(sliderSettings), value?.BaseObject);
        }
        
        // Access Field
        public CVRAdvancesAvatarSettingJoystick2DAccess? joystick2DSetting
        {
            get => CVRAdvancesAvatarSettingJoystick2DAccess.Nullable(CachedType___.GetFieldValueOf(BaseObject, nameof(joystick2DSetting)));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(joystick2DSetting), value?.BaseObject);
        }
        
        // CVRAdvancesAvatarSettingJoystick3D joystick3DSetting
        
        // Access Field
        public CVRAdvancesAvatarSettingInputSingleAccess? inputSingleSettings
        {
            get => CVRAdvancesAvatarSettingInputSingleAccess.Nullable(CachedType___.GetFieldValueOf(BaseObject, nameof(inputSingleSettings)));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(inputSingleSettings), value?.BaseObject);
        }
        
        // CVRAdvancesAvatarSettingInputVector2 inputVector2Settings
        
        // CVRAdvancesAvatarSettingInputVector3 inputVector3Settings
        
        // Direct Field
        public string? name
        {
            get => (string)CachedType___.GetFieldValueOf(BaseObject, nameof(name));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(name), value);
        }
        
        // Direct Field
        public string? machineName
        {
            get => (string)CachedType___.GetFieldValueOf(BaseObject, nameof(machineName));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(machineName), value);
        }
        
        // Access Property
        public CVRAdvancesAvatarSettingBaseAccess? setting
        {
            get => CVRAdvancesAvatarSettingBaseAccess.Nullable(CachedType___.GetPropertyValueOf(BaseObject, nameof(setting)));
            set => CachedType___.SetPropertyValueOf(BaseObject, nameof(setting), value?.BaseObject);
        }
    }
}
