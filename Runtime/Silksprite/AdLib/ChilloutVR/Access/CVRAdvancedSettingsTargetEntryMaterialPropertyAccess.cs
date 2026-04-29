using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;
using UnityEngine;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ReflectionAccess("ABI.CCK.Scripts.CVRAdvancedSettingsTargetEntryMaterialProperty", "Assembly-CSharp")]
    public class CVRAdvancedSettingsTargetEntryMaterialPropertyAccess : ObjectAccessBase<object>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancedSettingsTargetEntryMaterialProperty");
        static CachedType CachedType___ => CachedType;
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public CVRAdvancedSettingsTargetEntryMaterialPropertyAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancedSettingsTargetEntryMaterialPropertyAccess(object baseObject) : base(baseObject) { }
        public static CVRAdvancedSettingsTargetEntryMaterialPropertyAccess? Nullable(object? baseObject) => baseObject != null ? new CVRAdvancedSettingsTargetEntryMaterialPropertyAccess(baseObject) : null;
        
        // Direct Field
        public float minValue
        {
            get => (float)CachedType___.GetFieldValueOf(BaseObject, nameof(minValue));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(minValue), value);
        }
        
        // Direct Field
        public float maxValue
        {
            get => (float)CachedType___.GetFieldValueOf(BaseObject, nameof(maxValue));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(maxValue), value);
        }
        
        // Direct Field
        public GameObject? gameObject
        {
            get => (GameObject)CachedType___.GetFieldValueOf(BaseObject, nameof(gameObject));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(gameObject), value);
        }
        
        // Direct Field
        public string? treePath
        {
            get => (string)CachedType___.GetFieldValueOf(BaseObject, nameof(treePath));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(treePath), value);
        }
        
        // Direct Field
        public Type? propertyType
        {
            get => (Type)CachedType___.GetFieldValueOf(BaseObject, nameof(propertyType));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(propertyType), value);
        }
        
        // Direct Field
        public string? propertyTypeIdentifier
        {
            get => (string)CachedType___.GetFieldValueOf(BaseObject, nameof(propertyTypeIdentifier));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(propertyTypeIdentifier), value);
        }
        
        // Direct Field
        public string? propertyName
        {
            get => (string)CachedType___.GetFieldValueOf(BaseObject, nameof(propertyName));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(propertyName), value);
        }
    }
}
