using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;
using UnityEngine;

[ReflectionAccess("DynamicBoneColliderBase", "Assembly-CSharp")]
public class DynamicBoneColliderBaseAccess : ObjectAccessBase<MonoBehaviour>
{
    static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("DynamicBoneColliderBase");
    public static Type ActualType => CachedType.ActualType;
    public static bool IsImplemented => CachedType.IsImplemented;
    
    public DynamicBoneColliderBaseAccess() : base(CachedType.CreateInstance()) { }
    public DynamicBoneColliderBaseAccess(object baseObject) : base(baseObject) { }
    public static DynamicBoneColliderBaseAccess? Nullable(object? baseObject) => baseObject != null ? new DynamicBoneColliderBaseAccess(baseObject) : null;
    
    public DynamicBoneColliderBaseClass.DirectionAccess.EnumValues m_Direction
    {
        get => DynamicBoneColliderBaseClass.DirectionAccess.Shared.ToAccess(DynamicObject.m_Direction);
        set => DynamicObject.m_Direction = DynamicBoneColliderBaseClass.DirectionAccess.Shared.ToActual(value);
    }
    
    public Vector3 m_Center
    {
        get => DynamicObject.m_Center;
        set => DynamicObject.m_Center = value;
    }
    
    public DynamicBoneColliderBaseClass.BoundAccess.EnumValues m_Bound
    {
        get => DynamicBoneColliderBaseClass.BoundAccess.Shared.ToAccess(DynamicObject.m_Bound);
        set => DynamicObject.m_Bound = DynamicBoneColliderBaseClass.BoundAccess.Shared.ToActual(value);
    }
}
