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
        
        public Transform m_Root
        {
            get => DynamicObject.m_Root;
            set => DynamicObject.m_Root = value;
        }
        
        public float m_UpdateRate
        {
            get => DynamicObject.m_UpdateRate;
            set => DynamicObject.m_UpdateRate = value;
        }
        
        public DynamicBoneClass.UpdateModeAccess.EnumValues m_UpdateMode
        {
            get => DynamicBoneClass.UpdateModeAccess.Shared.ToAccess(DynamicObject.m_UpdateMode);
            set => DynamicObject.m_UpdateMode = DynamicBoneClass.UpdateModeAccess.Shared.ToActual(value);
        }
        
        public float m_Damping
        {
            get => DynamicObject.m_Damping;
            set => DynamicObject.m_Damping = value;
        }
        
        public AnimationCurve m_DampingDistrib
        {
            get => DynamicObject.m_DampingDistrib;
            set => DynamicObject.m_DampingDistrib = value;
        }
        
        public float m_Elasticity
        {
            get => DynamicObject.m_Elasticity;
            set => DynamicObject.m_Elasticity = value;
        }
        
        public AnimationCurve m_ElasticityDistrib
        {
            get => DynamicObject.m_ElasticityDistrib;
            set => DynamicObject.m_ElasticityDistrib = value;
        }
        
        public float m_Stiffness
        {
            get => DynamicObject.m_Stiffness;
            set => DynamicObject.m_Stiffness = value;
        }
        
        public AnimationCurve m_StiffnessDistrib
        {
            get => DynamicObject.m_StiffnessDistrib;
            set => DynamicObject.m_StiffnessDistrib = value;
        }
        
        public float m_Inert
        {
            get => DynamicObject.m_Inert;
            set => DynamicObject.m_Inert = value;
        }
        
        public AnimationCurve m_InertDistrib
        {
            get => DynamicObject.m_InertDistrib;
            set => DynamicObject.m_InertDistrib = value;
        }
        
        public float m_Friction
        {
            get => DynamicObject.m_Friction;
            set => DynamicObject.m_Friction = value;
        }
        
        public AnimationCurve m_FrictionDistrib
        {
            get => DynamicObject.m_FrictionDistrib;
            set => DynamicObject.m_FrictionDistrib = value;
        }
        
        public float m_Radius
        {
            get => DynamicObject.m_Radius;
            set => DynamicObject.m_Radius = value;
        }
        
        public AnimationCurve m_RadiusDistrib
        {
            get => DynamicObject.m_RadiusDistrib;
            set => DynamicObject.m_RadiusDistrib = value;
        }
        
        public float m_EndLength
        {
            get => DynamicObject.m_EndLength;
            set => DynamicObject.m_EndLength = value;
        }
        
        public Vector3 m_EndOffset
        {
            get => DynamicObject.m_EndOffset;
            set => DynamicObject.m_EndOffset = value;
        }
        
        public Vector3 m_Gravity
        {
            get => DynamicObject.m_Gravity;
            set => DynamicObject.m_Gravity = value;
        }
        
        public Vector3 m_Force
        {
            get => DynamicObject.m_Force;
            set => DynamicObject.m_Force = value;
        }
        
        public List<DynamicBoneColliderBaseAccess?>? m_Colliders
        {
            get => ((object)DynamicObject.m_Colliders).ToAccessList(DynamicBoneColliderBaseAccess.Nullable);
            set => DynamicObject.m_Colliders = value?.ToDynamicList(DynamicBoneColliderBaseAccess.ActualType);
        }
        
        public List<Transform> m_Exclusions
        {
            get => DynamicObject.m_Exclusions;
            set => DynamicObject.m_Exclusions = value;
        }
        
        public DynamicBoneClass.FreezeAxisAccess.EnumValues m_FreezeAxis
        {
            get => DynamicBoneClass.FreezeAxisAccess.Shared.ToAccess(DynamicObject.m_FreezeAxis);
            set => DynamicObject.m_FreezeAxis = DynamicBoneClass.FreezeAxisAccess.Shared.ToActual(value);
        }
        
        public bool m_DistantDisable
        {
            get => DynamicObject.m_DistantDisable;
            set => DynamicObject.m_DistantDisable = value;
        }
        
        public Transform m_ReferenceObject
        {
            get => DynamicObject.m_ReferenceObject;
            set => DynamicObject.m_ReferenceObject = value;
        }
        
        public float m_DistanceToObject
        {
            get => DynamicObject.m_DistanceToObject;
            set => DynamicObject.m_DistanceToObject = value;
        }
    }
}
