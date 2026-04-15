using System;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CVRAdvancesAvatarSettingInputSingleAccess : CVRAdvancesAvatarSettingBaseAccess
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancesAvatarSettingInputSingle");
        public new static Type ActualType => CachedType.ActualType;

        public CVRAdvancesAvatarSettingInputSingleAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancesAvatarSettingInputSingleAccess(object baseObject) : base(baseObject) { }

        public float defaultValue
        {
            get => DynamicObject.defaultValue;
            set => DynamicObject.defaultValue = value;
        }
    }
}
