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
    [ReflectionAccess("DynamicBoneColliderBase+Direction", "Assembly-CSharp")]
    public class DirectionAccess : EnumAccessBase<DirectionAccess.EnumValues>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("DynamicBoneColliderBase+Direction");
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public static readonly DirectionAccess Shared = new DirectionAccess();
        DirectionAccess() : base(CachedType) { }
        
        public enum EnumValues
        {
            X = 0,
            Y = 1,
            Z = 2,
        }
    }
}
