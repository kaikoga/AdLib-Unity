using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;
using UnityEngine;
using UnityEngine.Events;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ReflectionAccess("ABI.CCK.Scripts.Editor.PrePropBundleEvent", "Assembly-CSharp-Editor")]
    public class PrePropBundleEventAccess : ObjectAccessBase<UnityEvent<GameObject>>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetEditorType("ABI.CCK.Scripts.Editor.PrePropBundleEvent");
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public PrePropBundleEventAccess() : base(CachedType.CreateInstance()) { }
        public PrePropBundleEventAccess(object baseObject) : base(baseObject) { }
        public static PrePropBundleEventAccess? Nullable(object? baseObject) => baseObject != null ? new PrePropBundleEventAccess(baseObject) : null;
    }
}
