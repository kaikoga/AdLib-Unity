using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;
using UnityEditor.Animations;
using UnityEngine;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ReflectionAccess("ABI.CCK.Scripts.CVRAdvancedAvatarSettings", "Assembly-CSharp")]
    public class CVRAdvancedAvatarSettingsAccess : ObjectAccessBase<object>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancedAvatarSettings");
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public CVRAdvancedAvatarSettingsAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancedAvatarSettingsAccess(object baseObject) : base(baseObject) { }
        public static CVRAdvancedAvatarSettingsAccess? Nullable(object? baseObject) => baseObject != null ? new CVRAdvancedAvatarSettingsAccess(baseObject) : null;
        
        // AccessList Field
        public List<CVRAdvancedSettingsEntryAccess?>? settings
        {
            get => CachedType.GetFieldValueOf(BaseObject, nameof(settings)).ToAccessList(CVRAdvancedSettingsEntryAccess.Nullable);
            set => CachedType.SetFieldValueOf(BaseObject, nameof(settings), value?.ToDynamicList(CVRAdvancedSettingsEntryAccess.ActualType));
        }
        
        // Direct Field
        public bool initialized
        {
            get => (bool)CachedType.GetFieldValueOf(BaseObject, nameof(initialized));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(initialized), value);
        }
        
        // Direct Field
        public RuntimeAnimatorController? baseController
        {
            get => (RuntimeAnimatorController)CachedType.GetFieldValueOf(BaseObject, nameof(baseController));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(baseController), value);
        }
        
        // Direct Field
        public RuntimeAnimatorController? baseOverrideController
        {
            get => (RuntimeAnimatorController)CachedType.GetFieldValueOf(BaseObject, nameof(baseOverrideController));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(baseOverrideController), value);
        }
        
        // Direct Field
        public AnimatorController? animator
        {
            get => (AnimatorController)CachedType.GetFieldValueOf(BaseObject, nameof(animator));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(animator), value);
        }
        
        // Direct Field
        public AnimatorOverrideController? overrides
        {
            get => (AnimatorOverrideController)CachedType.GetFieldValueOf(BaseObject, nameof(overrides));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(overrides), value);
        }
    }
}
