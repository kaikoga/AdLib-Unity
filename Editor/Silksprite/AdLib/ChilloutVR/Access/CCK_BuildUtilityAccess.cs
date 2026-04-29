using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ReflectionAccess("ABI.CCK.Scripts.Editor.CCK_BuildUtility", "Assembly-CSharp-Editor")]
    public class CCK_BuildUtilityAccess : ObjectAccessBase<object>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetEditorType("ABI.CCK.Scripts.Editor.CCK_BuildUtility");
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public CCK_BuildUtilityAccess() : base(CachedType.CreateInstance()) { }
        public CCK_BuildUtilityAccess(object baseObject) : base(baseObject) { }
        public static CCK_BuildUtilityAccess? Nullable(object? baseObject) => baseObject != null ? new CCK_BuildUtilityAccess(baseObject) : null;
        
        public static PreAvatarBundleEventAccess? PreAvatarBundleEvent
        {
            get => PreAvatarBundleEventAccess.Nullable(CachedType.GetFieldValue(nameof(PreAvatarBundleEvent)));
            set => CachedType.SetFieldValue(nameof(PreAvatarBundleEvent), value?.BaseObject);
        }
        
        public static PrePropBundleEventAccess? PrePropBundleEvent
        {
            get => PrePropBundleEventAccess.Nullable(CachedType.GetFieldValue(nameof(PrePropBundleEvent)));
            set => CachedType.SetFieldValue(nameof(PrePropBundleEvent), value?.BaseObject);
        }
        
        public static PreWorldBundleEventAccess? PreWorldBundleEvent
        {
            get => PreWorldBundleEventAccess.Nullable(CachedType.GetFieldValue(nameof(PreWorldBundleEvent)));
            set => CachedType.SetFieldValue(nameof(PreWorldBundleEvent), value?.BaseObject);
        }
    }
}
