using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;
using UnityEngine;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CVRAdvancedAvatarSettingsAccess : ObjectAccessBase<object>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancedAvatarSettings");
        public static Type ActualType => CachedType.ActualType;

        public CVRAdvancedAvatarSettingsAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancedAvatarSettingsAccess(object baseObject) : base(baseObject) { }
        public static CVRAdvancedAvatarSettingsAccess? Nullable(object? baseObject) => baseObject != null ? new CVRAdvancedAvatarSettingsAccess(baseObject) : null;

        public List<CVRAdvancedSettingsEntryAccess?>? settings
        {
            get => ((object)DynamicObject.settings).ToAccessList(CVRAdvancedSettingsEntryAccess.Nullable);
            set => DynamicObject.settings = value?.ToDynamicList(CVRAdvancedSettingsEntryAccess.ActualType);
        }
        
#if UNITY_EDITOR

        public bool initialized
        {
            get => DynamicObject.initialized;
            set => DynamicObject.initialized = value;
        }

        public RuntimeAnimatorController? baseController
        {
            get => DynamicObject.baseController;
            set => DynamicObject.baseController = value;
        }

        public RuntimeAnimatorController? baseOverrideController
        {
            get => DynamicObject.baseOverrideController;
            set => DynamicObject.baseOverrideController = value;
        }

#endif

    }
}
