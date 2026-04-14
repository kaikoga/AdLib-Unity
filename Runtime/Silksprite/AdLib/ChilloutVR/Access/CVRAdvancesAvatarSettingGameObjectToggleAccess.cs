using System;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CVRAdvancesAvatarSettingGameObjectToggleAccess : CVRAdvancesAvatarSettingBaseAccess
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancesAvatarSettingGameObjectToggle");
        public new static Type ActualType => CachedType.ActualType;

        public CVRAdvancesAvatarSettingGameObjectToggleAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancesAvatarSettingGameObjectToggleAccess(object baseObject) : base(baseObject) { }

        public bool defaultValue
        {
            get => DynamicObject.defaultValue;
            set => DynamicObject.defaultValue = value;
        }
    }
}
