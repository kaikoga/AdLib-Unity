using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;
using UnityEngine;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[ReflectionAccess("DynamicBoneColliderBase", "Assembly-CSharp")]
public class DynamicBoneColliderBaseAccess : ObjectAccessBase<MonoBehaviour>
{
    static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("DynamicBoneColliderBase");
    static CachedType CachedType___ => CachedType;
    public static Type ActualType => CachedType.ActualType;
    public static bool IsImplemented => CachedType.IsImplemented;
    
    public DynamicBoneColliderBaseAccess() : base(CachedType.CreateInstance()) { }
    public DynamicBoneColliderBaseAccess(object baseObject) : base(baseObject) { }
    public static DynamicBoneColliderBaseAccess? Nullable(object? baseObject) => baseObject != null ? new DynamicBoneColliderBaseAccess(baseObject) : null;
    
    // EnumAccess Field
    public DynamicBoneColliderBaseClass.DirectionAccess.EnumValues m_Direction
    {
        get => DynamicBoneColliderBaseClass.DirectionAccess.Shared.ToAccess(CachedType___.GetFieldValueOf(BaseObject, nameof(m_Direction)));
        set => CachedType___.SetFieldValueOf(BaseObject, nameof(m_Direction), DynamicBoneColliderBaseClass.DirectionAccess.Shared.ToActual___(value));
    }
    
    // Direct Field
    public Vector3 m_Center
    {
        get => (Vector3)CachedType___.GetFieldValueOf(BaseObject, nameof(m_Center));
        set => CachedType___.SetFieldValueOf(BaseObject, nameof(m_Center), value);
    }
    
    // EnumAccess Field
    public DynamicBoneColliderBaseClass.BoundAccess.EnumValues m_Bound
    {
        get => DynamicBoneColliderBaseClass.BoundAccess.Shared.ToAccess(CachedType___.GetFieldValueOf(BaseObject, nameof(m_Bound)));
        set => CachedType___.SetFieldValueOf(BaseObject, nameof(m_Bound), DynamicBoneColliderBaseClass.BoundAccess.Shared.ToActual___(value));
    }
}
