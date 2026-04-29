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
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public CVRAdvancedSettingsTargetEntryMaterialPropertyAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancedSettingsTargetEntryMaterialPropertyAccess(object baseObject) : base(baseObject) { }
        public static CVRAdvancedSettingsTargetEntryMaterialPropertyAccess? Nullable(object? baseObject) => baseObject != null ? new CVRAdvancedSettingsTargetEntryMaterialPropertyAccess(baseObject) : null;
        
        // Direct Field
        public float minValue
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(minValue));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(minValue), value);
        }
        
        // Direct Field
        public float maxValue
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(maxValue));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(maxValue), value);
        }
        
        // Direct Field
        public GameObject? gameObject
        {
            get => (GameObject)CachedType.GetFieldValueOf(BaseObject, nameof(gameObject));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(gameObject), value);
        }
        
        // Direct Field
        public string? treePath
        {
            get => (string)CachedType.GetFieldValueOf(BaseObject, nameof(treePath));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(treePath), value);
        }
        
        // Direct Field
        public Type? propertyType
        {
            get => (Type)CachedType.GetFieldValueOf(BaseObject, nameof(propertyType));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(propertyType), value);
        }
        
        // Direct Field
        public string? propertyTypeIdentifier
        {
            get => (string)CachedType.GetFieldValueOf(BaseObject, nameof(propertyTypeIdentifier));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(propertyTypeIdentifier), value);
        }
        
        // Direct Field
        public string? propertyName
        {
            get => (string)CachedType.GetFieldValueOf(BaseObject, nameof(propertyName));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(propertyName), value);
        }
    }
}
