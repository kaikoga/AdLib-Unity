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
    [ReflectionAccess("ABI.CCK.Scripts.Editor.PreAvatarBundleEvent", "Assembly-CSharp-Editor")]
    public class PreAvatarBundleEventAccess : ObjectAccessBase<UnityEvent<GameObject>>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetEditorType("ABI.CCK.Scripts.Editor.PreAvatarBundleEvent");
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public PreAvatarBundleEventAccess() : base(CachedType.CreateInstance()) { }
        public PreAvatarBundleEventAccess(object baseObject) : base(baseObject) { }
        public static PreAvatarBundleEventAccess? Nullable(object? baseObject) => baseObject != null ? new PreAvatarBundleEventAccess(baseObject) : null;
    }
}
