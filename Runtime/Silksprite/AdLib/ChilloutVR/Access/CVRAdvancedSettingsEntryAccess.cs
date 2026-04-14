using System;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Base;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CVRAdvancedSettingsEntryAccess : ObjectAccessBase<object>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancedSettingsEntry");
        public static Type ActualType => CachedType.ActualType;

        public CVRAdvancedSettingsEntryAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancedSettingsEntryAccess(object baseObject) : base(baseObject) { }
        public static CVRAdvancedSettingsEntryAccess? Nullable(object? baseObject) => baseObject != null ? new CVRAdvancedSettingsEntryAccess(baseObject) : null;
        
        public CVRAdvancedSettingsEntryClass.SettingsTypeAccess.EnumValues type
        {
            get => CVRAdvancedSettingsEntryClass.SettingsTypeAccess.Shared.ToAccess(DynamicObject.type);
            set => DynamicObject.type = CVRAdvancedSettingsEntryClass.SettingsTypeAccess.Shared.ToActual(value);
        }

        public CVRAdvancesAvatarSettingBaseAccess setting
        {
            get => new CVRAdvancesAvatarSettingBaseAccess(DynamicObject.setting);
            set => DynamicObject.setting = value.DynamicObject;
        }

        public string name
        {
            get => DynamicObject.name;
            set => DynamicObject.name = value;
        }

        public string machineName
        {
            get => DynamicObject.machineName;
            set => DynamicObject.machineName = value;
        }

    }
}
