using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Extensions;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CVRAdvancesAvatarSettingSliderAccess : CVRAdvancesAvatarSettingBaseAccess
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancesAvatarSettingSlider");
        public new static Type ActualType => CachedType.ActualType;

        public CVRAdvancesAvatarSettingSliderAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancesAvatarSettingSliderAccess(object baseObject) : base(baseObject) { }

        public float defaultValue
        {
            get => DynamicObject.defaultValue;
            set => DynamicObject.defaultValue = value;
        }

        public List<CVRAdvancedSettingsTargetEntryMaterialPropertyAccess?>? materialPropertyTargets
        {
            get => ((object)DynamicObject.materialPropertyTargets).ToAccessList(CVRAdvancedSettingsTargetEntryMaterialPropertyAccess.Nullable);
            set => DynamicObject.materialPropertyTargets = value?.ToDynamicList(CVRAdvancedSettingsTargetEntryMaterialPropertyAccess.ActualType);
        }
    }
}
