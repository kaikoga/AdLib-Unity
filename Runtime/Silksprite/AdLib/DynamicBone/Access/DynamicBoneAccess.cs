using System;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Base;
using UnityEngine;

namespace Silksprite.AdLib.DynamicBone.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class DynamicBoneAccess : ObjectAccessBase<Component>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("DynamicBone");
        public static Type ActualType => CachedType.ActualType;

        public DynamicBoneAccess(object baseObject) : base(baseObject) { }
    }
}
