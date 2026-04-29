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
        static CachedType CachedType___ => CachedType;
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public CVRAdvancesAvatarSettingGameObjectToggleAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancesAvatarSettingGameObjectToggleAccess(object baseObject) : base(baseObject) { }
        public static CVRAdvancesAvatarSettingGameObjectToggleAccess? Nullable(object? baseObject) => baseObject != null ? new CVRAdvancesAvatarSettingGameObjectToggleAccess(baseObject) : null;
        
        // Direct Field
        public bool defaultValue
        {
            get => (bool)CachedType___.GetFieldValueOf(BaseObject, nameof(defaultValue));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(defaultValue), value);
        }
        
        // Direct Field
        public ReorderableList? reorderableList
        {
            get => (ReorderableList)CachedType___.GetFieldValueOf(BaseObject, nameof(reorderableList));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(reorderableList), value);
        }
        
        // Direct Field
        public bool useAnimationClip
        {
            get => (bool)CachedType___.GetFieldValueOf(BaseObject, nameof(useAnimationClip));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(useAnimationClip), value);
        }
        
        // Direct Field
        public AnimationClip? animationClip
        {
            get => (AnimationClip)CachedType___.GetFieldValueOf(BaseObject, nameof(animationClip));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(animationClip), value);
        }
        
        // Direct Field
        public AnimationClip? offAnimationClip
        {
            get => (AnimationClip)CachedType___.GetFieldValueOf(BaseObject, nameof(offAnimationClip));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(offAnimationClip), value);
        }
        
        // List<CVRAdvancedSettingsTargetEntryGameObject> gameObjectTargets
    }
}
