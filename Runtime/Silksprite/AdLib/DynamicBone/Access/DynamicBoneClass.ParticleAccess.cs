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
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ReflectionAccess("DynamicBone+Particle", "Assembly-CSharp")]
    public class ParticleAccess : ObjectAccessBase<object>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("DynamicBone+Particle");
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public ParticleAccess() : base(CachedType.CreateInstance()) { }
        public ParticleAccess(object baseObject) : base(baseObject) { }
        public static ParticleAccess? Nullable(object? baseObject) => baseObject != null ? new ParticleAccess(baseObject) : null;
        
        // Direct Field
        public Transform? m_Transform
        {
            get => (Transform)CachedType.GetFieldValueOf(BaseObject, nameof(m_Transform));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Transform), value);
        }
        
        // Direct Field
        public int m_ParentIndex
        {
            get => (int)CachedType.GetFieldValueOf(BaseObject, nameof(m_ParentIndex));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_ParentIndex), value);
        }
        
        // Direct Field
        public float m_Damping
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(m_Damping));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Damping), value);
        }
        
        // Direct Field
        public float m_Elasticity
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(m_Elasticity));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Elasticity), value);
        }
        
        // Direct Field
        public float m_Stiffness
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(m_Stiffness));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Stiffness), value);
        }
        
        // Direct Field
        public float m_Inert
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(m_Inert));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Inert), value);
        }
        
        // Direct Field
        public float m_Friction
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(m_Friction));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Friction), value);
        }
        
        // Direct Field
        public float m_Radius
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(m_Radius));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Radius), value);
        }
        
        // Direct Field
        public float m_BoneLength
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(m_BoneLength));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_BoneLength), value);
        }
        
        // Direct Field
        public bool m_isCollide
        {
            get => (bool)CachedType.GetFieldValueOf(BaseObject, nameof(m_isCollide));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_isCollide), value);
        }
        
        // Direct Field
        public Vector3 m_Position
        {
            get => (Vector3)CachedType.GetFieldValueOf(BaseObject, nameof(m_Position));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_Position), value);
        }
        
        // Direct Field
        public Vector3 m_PrevPosition
        {
            get => (Vector3)CachedType.GetFieldValueOf(BaseObject, nameof(m_PrevPosition));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_PrevPosition), value);
        }
        
        // Direct Field
        public Vector3 m_EndOffset
        {
            get => (Vector3)CachedType.GetFieldValueOf(BaseObject, nameof(m_EndOffset));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_EndOffset), value);
        }
        
        // Direct Field
        public Vector3 m_InitLocalPosition
        {
            get => (Vector3)CachedType.GetFieldValueOf(BaseObject, nameof(m_InitLocalPosition));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_InitLocalPosition), value);
        }
        
        // Direct Field
        public Quaternion m_InitLocalRotation
        {
            get => (Quaternion)CachedType.GetFieldValueOf(BaseObject, nameof(m_InitLocalRotation));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(m_InitLocalRotation), value);
        }
    }
}
