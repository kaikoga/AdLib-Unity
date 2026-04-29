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
    [ReflectionAccess("ABI.CCK.Components.BodyControl", "Assembly-CSharp")]
    public class BodyControlAccess : ObjectAccessBase<StateMachineBehaviour>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.BodyControl");
        static CachedType CachedType___ => CachedType;
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public BodyControlAccess() : base(CachedType.CreateInstance()) { }
        public BodyControlAccess(object baseObject) : base(baseObject) { }
        public static BodyControlAccess? Nullable(object? baseObject) => baseObject != null ? new BodyControlAccess(baseObject) : null;
        
        // AccessList Field
        public List<BodyControlTaskAccess?>? EnterTasks
        {
            get => CachedType___.GetFieldValueOf(BaseObject, nameof(EnterTasks)).ToAccessList(BodyControlTaskAccess.Nullable);
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(EnterTasks), value?.ToDynamicList(BodyControlTaskAccess.ActualType));
        }
        
        // AccessList Field
        public List<BodyControlTaskAccess?>? ExitTasks
        {
            get => CachedType___.GetFieldValueOf(BaseObject, nameof(ExitTasks)).ToAccessList(BodyControlTaskAccess.Nullable);
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(ExitTasks), value?.ToDynamicList(BodyControlTaskAccess.ActualType));
        }
        
        // static UnityEvent<Animator,BodyControl> OnInitialized
        
        // static UnityEvent<Animator,BodyControlTask> OnExecuteEnterTask
        
        // static UnityEvent<Animator,BodyControlTask> OnExecuteExitTask
    }
}
