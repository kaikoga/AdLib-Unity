using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ReflectionAccess("ABI.CCK.Scripts.Editor.PreWorldBundleEvent", "Assembly-CSharp-Editor")]
    public class PreWorldBundleEventAccess : ObjectAccessBase<UnityEvent<Scene>>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetEditorType("ABI.CCK.Scripts.Editor.PreWorldBundleEvent");
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public PreWorldBundleEventAccess() : base(CachedType.CreateInstance()) { }
        public PreWorldBundleEventAccess(object baseObject) : base(baseObject) { }
        public static PreWorldBundleEventAccess? Nullable(object? baseObject) => baseObject != null ? new PreWorldBundleEventAccess(baseObject) : null;
    }
}
