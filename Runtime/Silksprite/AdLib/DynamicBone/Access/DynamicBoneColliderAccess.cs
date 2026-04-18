using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;

[ReflectionAccess("DynamicBoneCollider", "Assembly-CSharp")]
public class DynamicBoneColliderAccess : ObjectAccessBase<object>
{
    static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("DynamicBoneCollider");
    public static Type ActualType => CachedType.ActualType;
    public static bool IsImplemented => CachedType.IsImplemented;
    
    public DynamicBoneColliderAccess() : base(CachedType.CreateInstance()) { }
    public DynamicBoneColliderAccess(object baseObject) : base(baseObject) { }
    public static DynamicBoneColliderAccess? Nullable(object? baseObject) => baseObject != null ? new DynamicBoneColliderAccess(baseObject) : null;
    
    public float m_Radius
    {
        get => DynamicObject.m_Radius;
        set => DynamicObject.m_Radius = value;
    }
    
    public float m_Height
    {
        get => DynamicObject.m_Height;
        set => DynamicObject.m_Height = value;
    }
}
