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
    [ReflectionAccess("ABI.CCK.Components.BodyControl", "ABI.CCK.Components")]
    public class BodyControlAccess : ObjectAccessBase<StateMachineBehaviour>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.BodyControl");
        public static Type ActualType => CachedType.ActualType;

        public BodyControlAccess(object baseObject) : base(baseObject) { }
        
        public List<BodyControlTaskAccess?>? EnterTasks
        {
            get => ((object)DynamicObject.EnterTasks).ToAccessList(BodyControlTaskAccess.Nullable);
            set => DynamicObject.EnterTasks = value?.ToDynamicList(BodyControlTaskAccess.ActualType);
        }
    }
}
