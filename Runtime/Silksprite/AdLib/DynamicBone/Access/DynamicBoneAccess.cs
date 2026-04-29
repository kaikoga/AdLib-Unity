using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;
using UnityEngine;

namespace Silksprite.AdLib.DynamicBone.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ReflectionAccess("DynamicBone", "Assembly-CSharp")]
    public class DynamicBoneAccess : ObjectAccessBase<MonoBehaviour>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("DynamicBone");
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public DynamicBoneAccess() : base(CachedType.CreateInstance()) { }
        public DynamicBoneAccess(object baseObject) : base(baseObject) { }
        public static DynamicBoneAccess? Nullable(object? baseObject) => baseObject != null ? new DynamicBoneAccess(baseObject) : null;
        
        // Direct Field
        public Transform? m_Root
        {
            get => (Transform)CachedType.GetFieldValueOf(BaseObject, nameof(m_Root));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Root), value);
        }
        
        // Direct Field
        public float m_UpdateRate
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(m_UpdateRate));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_UpdateRate), value);
        }
        
        // EnumAccess Field
        public DynamicBoneClass.UpdateModeAccess.EnumValues m_UpdateMode
        {
            get => DynamicBoneClass.UpdateModeAccess.Shared.ToAccess(CachedType.GetFieldValueOf(BaseObject, nameof(m_UpdateMode)));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_UpdateMode), DynamicBoneClass.UpdateModeAccess.Shared.ToActual(value));
        }
        
        // Direct Field
        public float m_Damping
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(m_Damping));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Damping), value);
        }
        
        // Direct Field
        public AnimationCurve? m_DampingDistrib
        {
            get => (AnimationCurve)CachedType.GetFieldValueOf(BaseObject, nameof(m_DampingDistrib));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_DampingDistrib), value);
        }
        
        // Direct Field
        public float m_Elasticity
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(m_Elasticity));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Elasticity), value);
        }
        
        // Direct Field
        public AnimationCurve? m_ElasticityDistrib
        {
            get => (AnimationCurve)CachedType.GetFieldValueOf(BaseObject, nameof(m_ElasticityDistrib));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_ElasticityDistrib), value);
        }
        
        // Direct Field
        public float m_Stiffness
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(m_Stiffness));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Stiffness), value);
        }
        
        // Direct Field
        public AnimationCurve? m_StiffnessDistrib
        {
            get => (AnimationCurve)CachedType.GetFieldValueOf(BaseObject, nameof(m_StiffnessDistrib));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_StiffnessDistrib), value);
        }
        
        // Direct Field
        public float m_Inert
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(m_Inert));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Inert), value);
        }
        
        // Direct Field
        public AnimationCurve? m_InertDistrib
        {
            get => (AnimationCurve)CachedType.GetFieldValueOf(BaseObject, nameof(m_InertDistrib));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_InertDistrib), value);
        }
        
        // Direct Field
        public float m_Friction
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(m_Friction));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Friction), value);
        }
        
        // Direct Field
        public AnimationCurve? m_FrictionDistrib
        {
            get => (AnimationCurve)CachedType.GetFieldValueOf(BaseObject, nameof(m_FrictionDistrib));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_FrictionDistrib), value);
        }
        
        // Direct Field
        public float m_Radius
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(m_Radius));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Radius), value);
        }
        
        // Direct Field
        public AnimationCurve? m_RadiusDistrib
        {
            get => (AnimationCurve)CachedType.GetFieldValueOf(BaseObject, nameof(m_RadiusDistrib));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_RadiusDistrib), value);
        }
        
        // Direct Field
        public float m_EndLength
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(m_EndLength));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_EndLength), value);
        }
        
        // Direct Field
        public Vector3 m_EndOffset
        {
            get => (Vector3)CachedType.GetFieldValueOf(BaseObject, nameof(m_EndOffset));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_EndOffset), value);
        }
        
        // Direct Field
        public Vector3 m_Gravity
        {
            get => (Vector3)CachedType.GetFieldValueOf(BaseObject, nameof(m_Gravity));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Gravity), value);
        }
        
        // Direct Field
        public Vector3 m_Force
        {
            get => (Vector3)CachedType.GetFieldValueOf(BaseObject, nameof(m_Force));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Force), value);
        }
        
        // AccessList Field
        public List<DynamicBoneColliderBaseAccess?>? m_Colliders
        {
            get => CachedType.GetFieldValueOf(BaseObject, nameof(m_Colliders)).ToAccessList(DynamicBoneColliderBaseAccess.Nullable);
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Colliders), value?.ToDynamicList(DynamicBoneColliderBaseAccess.ActualType));
        }
        
        // Direct Field
        public List<Transform?>? m_Exclusions
        {
            get => (List<Transform>)CachedType.GetFieldValueOf(BaseObject, nameof(m_Exclusions));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Exclusions), value);
        }
        
        // EnumAccess Field
        public DynamicBoneClass.FreezeAxisAccess.EnumValues m_FreezeAxis
        {
            get => DynamicBoneClass.FreezeAxisAccess.Shared.ToAccess(CachedType.GetFieldValueOf(BaseObject, nameof(m_FreezeAxis)));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_FreezeAxis), DynamicBoneClass.FreezeAxisAccess.Shared.ToActual(value));
        }
        
        // Direct Field
        public bool m_DistantDisable
        {
            get => (bool)CachedType.GetFieldValueOf(BaseObject, nameof(m_DistantDisable));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_DistantDisable), value);
        }
        
        // Direct Field
        public Transform? m_ReferenceObject
        {
            get => (Transform)CachedType.GetFieldValueOf(BaseObject, nameof(m_ReferenceObject));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_ReferenceObject), value);
        }
        
        // Direct Field
        public float m_DistanceToObject
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(m_DistanceToObject));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_DistanceToObject), value);
        }
    }
}
