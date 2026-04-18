using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;

[ReflectionAccess("DynamicBonePlaneCollider", "Assembly-CSharp")]
public class DynamicBonePlaneColliderAccess : ObjectAccessBase<object>
{
    static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("DynamicBonePlaneCollider");
    public static Type ActualType => CachedType.ActualType;
    public static bool IsImplemented => CachedType.IsImplemented;
    
    public DynamicBonePlaneColliderAccess() : base(CachedType.CreateInstance()) { }
    public DynamicBonePlaneColliderAccess(object baseObject) : base(baseObject) { }
    public static DynamicBonePlaneColliderAccess? Nullable(object? baseObject) => baseObject != null ? new DynamicBonePlaneColliderAccess(baseObject) : null;
}
