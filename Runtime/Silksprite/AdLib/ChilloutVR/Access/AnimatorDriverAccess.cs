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
    [ReflectionAccess("ABI.CCK.Components.AnimatorDriver", "Assembly-CSharp")]
    public class AnimatorDriverAccess : ObjectAccessBase<StateMachineBehaviour>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.AnimatorDriver");
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public AnimatorDriverAccess() : base(CachedType.CreateInstance()) { }
        public AnimatorDriverAccess(object baseObject) : base(baseObject) { }
        public static AnimatorDriverAccess? Nullable(object? baseObject) => baseObject != null ? new AnimatorDriverAccess(baseObject) : null;
        
        // AccessList Field
        public List<AnimatorDriverTaskAccess?>? EnterTasks
        {
            get => CachedType.GetFieldValueOf(BaseObject, nameof(EnterTasks)).ToAccessList(AnimatorDriverTaskAccess.Nullable);
            set => CachedType.SetFieldValueOf(BaseObject, nameof(EnterTasks), value?.ToDynamicList(AnimatorDriverTaskAccess.ActualType));
        }
        
        // AccessList Field
        public List<AnimatorDriverTaskAccess?>? ExitTasks
        {
            get => CachedType.GetFieldValueOf(BaseObject, nameof(ExitTasks)).ToAccessList(AnimatorDriverTaskAccess.Nullable);
            set => CachedType.SetFieldValueOf(BaseObject, nameof(ExitTasks), value?.ToDynamicList(AnimatorDriverTaskAccess.ActualType));
        }
        
        // Direct Field
        public bool localOnly
        {
            get => (bool)CachedType.GetFieldValueOf(BaseObject, nameof(localOnly));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(localOnly), value);
        }
    }
}
