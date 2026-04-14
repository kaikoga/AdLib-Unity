using System;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Base;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CVRAdvancedSettingsTargetEntryMaterialPropertyAccess : ObjectAccessBase<object>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancedSettingsTargetEntryMaterialProperty");
        public static Type ActualType => CachedType.ActualType;

        public CVRAdvancedSettingsTargetEntryMaterialPropertyAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancedSettingsTargetEntryMaterialPropertyAccess(object baseObject) : base(baseObject) { }
        public static CVRAdvancedSettingsTargetEntryMaterialPropertyAccess? Nullable(object? baseObject) => baseObject != null ? new CVRAdvancedSettingsTargetEntryMaterialPropertyAccess(baseObject) : null;
        
        public float minValue
        {
            get => DynamicObject.minValue;
            set => DynamicObject.minValue = value;
        }

        public float maxValue
        {
            get => DynamicObject.maxValue;
            set => DynamicObject.maxValue = value;
        }
    }
}
