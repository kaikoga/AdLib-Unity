using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;
using UnityEngine;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class AnimatorDriverAccess : ObjectAccessBase<StateMachineBehaviour>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.AnimatorDriver");
        public static Type ActualType => CachedType.ActualType;

        public AnimatorDriverAccess(object baseObject) : base(baseObject) { }

        public bool localOnly
        {
            get => DynamicObject.localOnly;
            set => DynamicObject.localOnly = value;
        }

        public List<AnimatorDriverTaskAccess?>? EnterTasks
        {
            get => ((object)DynamicObject.EnterTasks).ToAccessList(AnimatorDriverTaskAccess.Nullable);
            set => DynamicObject.EnterTasks = value?.ToDynamicList(AnimatorDriverTaskAccess.ActualType);
        }
    }
}
