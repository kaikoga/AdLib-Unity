using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;
using UnityEngine;

public static partial class DynamicBoneClass
{
    [ReflectionAccess("DynamicBone+Particle", "Assembly-CSharp")]
    public class ParticleAccess : ObjectAccessBase<object>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("DynamicBone+Particle");
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public ParticleAccess() : base(CachedType.CreateInstance()) { }
        public ParticleAccess(object baseObject) : base(baseObject) { }
        public static ParticleAccess? Nullable(object? baseObject) => baseObject != null ? new ParticleAccess(baseObject) : null;
        
        public Transform m_Transform
        {
            get => DynamicObject.m_Transform;
            set => DynamicObject.m_Transform = value;
        }
        
        public int m_ParentIndex
        {
            get => DynamicObject.m_ParentIndex;
            set => DynamicObject.m_ParentIndex = value;
        }
        
        public float m_Damping
        {
            get => DynamicObject.m_Damping;
            set => DynamicObject.m_Damping = value;
        }
        
        public float m_Elasticity
        {
            get => DynamicObject.m_Elasticity;
            set => DynamicObject.m_Elasticity = value;
        }
        
        public float m_Stiffness
        {
            get => DynamicObject.m_Stiffness;
            set => DynamicObject.m_Stiffness = value;
        }
        
        public float m_Inert
        {
            get => DynamicObject.m_Inert;
            set => DynamicObject.m_Inert = value;
        }
        
        public float m_Friction
        {
            get => DynamicObject.m_Friction;
            set => DynamicObject.m_Friction = value;
        }
        
        public float m_Radius
        {
            get => DynamicObject.m_Radius;
            set => DynamicObject.m_Radius = value;
        }
        
        public float m_BoneLength
        {
            get => DynamicObject.m_BoneLength;
            set => DynamicObject.m_BoneLength = value;
        }
        
        public bool m_isCollide
        {
            get => DynamicObject.m_isCollide;
            set => DynamicObject.m_isCollide = value;
        }
        
        public Vector3 m_Position
        {
            get => DynamicObject.m_Position;
            set => DynamicObject.m_Position = value;
        }
        
        public Vector3 m_PrevPosition
        {
            get => DynamicObject.m_PrevPosition;
            set => DynamicObject.m_PrevPosition = value;
        }
        
        public Vector3 m_EndOffset
        {
            get => DynamicObject.m_EndOffset;
            set => DynamicObject.m_EndOffset = value;
        }
        
        public Vector3 m_InitLocalPosition
        {
            get => DynamicObject.m_InitLocalPosition;
            set => DynamicObject.m_InitLocalPosition = value;
        }
        
        public Quaternion m_InitLocalRotation
        {
            get => DynamicObject.m_InitLocalRotation;
            set => DynamicObject.m_InitLocalRotation = value;
        }
    }
}
