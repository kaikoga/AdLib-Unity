using System;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Base;
using UnityEngine;
using UnityEngine.Events;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class CCKBuildUtilityAccess : ObjectAccessBase<object>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetEditorType("ABI.CCK.Scripts.Editor.CCK_BuildUtility");
        public static Type ActualType => CachedType.ActualType;

        public CCKBuildUtilityAccess(object baseObject) : base(baseObject) { }

        public static UnityEvent<GameObject>? PreAvatarBundleEvent
        {
            get => CachedType.GetFieldValue(nameof(PreAvatarBundleEvent));
            set => CachedType.SetFieldValue(nameof(PreAvatarBundleEvent), value);
        }
    }
}
