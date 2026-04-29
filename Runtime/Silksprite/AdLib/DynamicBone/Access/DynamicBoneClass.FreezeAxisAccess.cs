using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;

public static partial class DynamicBoneClass
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ReflectionAccess("DynamicBone+FreezeAxis", "Assembly-CSharp")]
    public class FreezeAxisAccess : EnumAccessBase<FreezeAxisAccess.EnumValues>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("DynamicBone+FreezeAxis");
        static CachedType CachedType___ => CachedType;
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public static readonly FreezeAxisAccess Shared = new FreezeAxisAccess();
        FreezeAxisAccess() : base(CachedType) { }
        
        public enum EnumValues
        {
            None = 0,
            X = 1,
            Y = 2,
            Z = 3,
        }
    }
}
