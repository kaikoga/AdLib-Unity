using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;
using UnityEditorInternal;
using UnityEngine;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ReflectionAccess("ABI.CCK.Scripts.CVRAdvancesAvatarSettingGameObjectToggle", "Assembly-CSharp")]
    public class CVRAdvancesAvatarSettingGameObjectToggleAccess : CVRAdvancesAvatarSettingBaseAccess
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancesAvatarSettingGameObjectToggle");
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public CVRAdvancesAvatarSettingGameObjectToggleAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancesAvatarSettingGameObjectToggleAccess(object baseObject) : base(baseObject) { }
        public static CVRAdvancesAvatarSettingGameObjectToggleAccess? Nullable(object? baseObject) => baseObject != null ? new CVRAdvancesAvatarSettingGameObjectToggleAccess(baseObject) : null;
        
        // Direct Field
        public bool defaultValue
        {
            get => (bool)CachedType.GetFieldValueOf(BaseObject, nameof(defaultValue));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(defaultValue), value);
        }
        
        // Direct Field
        public ReorderableList? reorderableList
        {
            get => (ReorderableList)CachedType.GetFieldValueOf(BaseObject, nameof(reorderableList));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(reorderableList), value);
        }
        
        // Direct Field
        public bool useAnimationClip
        {
            get => (bool)CachedType.GetFieldValueOf(BaseObject, nameof(useAnimationClip));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(useAnimationClip), value);
        }
        
        // Direct Field
        public AnimationClip? animationClip
        {
            get => (AnimationClip)CachedType.GetFieldValueOf(BaseObject, nameof(animationClip));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(animationClip), value);
        }
        
        // Direct Field
        public AnimationClip? offAnimationClip
        {
            get => (AnimationClip)CachedType.GetFieldValueOf(BaseObject, nameof(offAnimationClip));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(offAnimationClip), value);
        }
        
        // List<CVRAdvancedSettingsTargetEntryGameObject> gameObjectTargets
    }
}
