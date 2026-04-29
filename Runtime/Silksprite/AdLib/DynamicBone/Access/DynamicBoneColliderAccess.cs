using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[ReflectionAccess("DynamicBoneCollider", "Assembly-CSharp")]
public class DynamicBoneColliderAccess : DynamicBoneColliderBaseAccess
{
    static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("DynamicBoneCollider");
    public static Type ActualType => CachedType.ActualType;
    public static bool IsImplemented => CachedType.IsImplemented;
    
    public DynamicBoneColliderAccess() : base(CachedType.CreateInstance()) { }
    public DynamicBoneColliderAccess(object baseObject) : base(baseObject) { }
    public static DynamicBoneColliderAccess? Nullable(object? baseObject) => baseObject != null ? new DynamicBoneColliderAccess(baseObject) : null;
    
    // Direct Field
    public float m_Radius
    {
        get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(m_Radius));
        set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Radius), value);
    }
    
    // Direct Field
    public float m_Height
    {
        get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(m_Height));
        set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Height), value);
    }
}
