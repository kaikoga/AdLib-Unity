using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;
using UnityEngine;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ReflectionAccess("ABI.CCK.Scripts.CVRAdvancedSettingsDropDownEntry", "Assembly-CSharp")]
    public class CVRAdvancedSettingsDropDownEntryAccess : ObjectAccessBase<object>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancedSettingsDropDownEntry");
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public CVRAdvancedSettingsDropDownEntryAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancedSettingsDropDownEntryAccess(object baseObject) : base(baseObject) { }
        public static CVRAdvancedSettingsDropDownEntryAccess? Nullable(object? baseObject) => baseObject != null ? new CVRAdvancedSettingsDropDownEntryAccess(baseObject) : null;
        
        // Direct Field
        public string? name
        {
            get => (string)CachedType.GetFieldValueOf(BaseObject, nameof(name));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(name), value);
        }
        
        // ReorderableList reorderableList
        
        // Direct Field
        public bool isAutogenCollapsed
        {
            get => (bool)CachedType.GetFieldValueOf(BaseObject, nameof(isAutogenCollapsed));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(isAutogenCollapsed), value);
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
        
        // List<CVRAdvancedSettingsTargetEntryGameObject> gameObjectTargets
    }
}
