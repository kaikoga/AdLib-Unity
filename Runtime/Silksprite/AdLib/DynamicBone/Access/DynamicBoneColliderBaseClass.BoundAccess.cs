using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;

public static partial class DynamicBoneColliderBaseClass
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ReflectionAccess("DynamicBoneColliderBase+Bound", "Assembly-CSharp")]
    public class BoundAccess : EnumAccessBase<BoundAccess.EnumValues>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("DynamicBoneColliderBase+Bound");
        static CachedType CachedType___ => CachedType;
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public static readonly BoundAccess Shared = new BoundAccess();
        BoundAccess() : base(CachedType) { }
        
        public enum EnumValues
        {
            Outside = 0,
            Inside = 1,
        }
    }
}
