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
    [ReflectionAccess("DynamicBone+UpdateMode", "Assembly-CSharp")]
    public class UpdateModeAccess : EnumAccessBase<UpdateModeAccess.EnumValues>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("DynamicBone+UpdateMode");
        static CachedType CachedType___ => CachedType;
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public static readonly UpdateModeAccess Shared = new UpdateModeAccess();
        UpdateModeAccess() : base(CachedType) { }
        
        public enum EnumValues
        {
            Normal = 0,
            AnimatePhysics = 1,
            UnscaledTime = 2,
            Default = 3,
        }
    }
}
