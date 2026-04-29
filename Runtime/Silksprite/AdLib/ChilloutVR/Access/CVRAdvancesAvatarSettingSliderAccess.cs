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
    [ReflectionAccess("ABI.CCK.Scripts.CVRAdvancesAvatarSettingSlider", "Assembly-CSharp")]
    public class CVRAdvancesAvatarSettingSliderAccess : CVRAdvancesAvatarSettingBaseAccess
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancesAvatarSettingSlider");
        static CachedType CachedType___ => CachedType;
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public CVRAdvancesAvatarSettingSliderAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancesAvatarSettingSliderAccess(object baseObject) : base(baseObject) { }
        public static CVRAdvancesAvatarSettingSliderAccess? Nullable(object? baseObject) => baseObject != null ? new CVRAdvancesAvatarSettingSliderAccess(baseObject) : null;
        
        // Direct Field
        public float defaultValue
        {
            get => (float)CachedType___.GetFieldValueOf(BaseObject, nameof(defaultValue));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(defaultValue), value);
        }
        
        // AccessList Field
        public List<CVRAdvancedSettingsTargetEntryMaterialPropertyAccess?>? materialPropertyTargets
        {
            get => CachedType___.GetFieldValueOf(BaseObject, nameof(materialPropertyTargets)).ToAccessList(CVRAdvancedSettingsTargetEntryMaterialPropertyAccess.Nullable);
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(materialPropertyTargets), value?.ToDynamicList(CVRAdvancedSettingsTargetEntryMaterialPropertyAccess.ActualType));
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
        public AnimationClip? minAnimationClip
        {
            get => (AnimationClip)CachedType___.GetFieldValueOf(BaseObject, nameof(minAnimationClip));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(minAnimationClip), value);
        }
        
        // Direct Field
        public AnimationClip? maxAnimationClip
        {
            get => (AnimationClip)CachedType___.GetFieldValueOf(BaseObject, nameof(maxAnimationClip));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(maxAnimationClip), value);
        }
    }
}
