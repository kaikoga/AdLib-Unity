using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Silksprite.AdLib.Reflection
{
    [PublicAPI]
    public class CachedType
    {
        readonly Type? _actualType;
        
        public Type ActualType
        {
            get
            {
                if (_actualType == null)
                {
                    Debug.LogError($"Couldn't find type {_typeName} in assembly {_assemblyName}");
                }
                return _actualType!;
            }
        }
        public bool IsImplemented => _actualType != null;

        readonly string _assemblyName;
        readonly string _typeName;
        
        CachedType(Type type, string assemblyName, string typeName)
        {
            _actualType = type;
            _assemblyName = assemblyName;
            _typeName = typeName;
        }

        public CachedType(Type type)
        {
            _actualType = type;
            _assemblyName = type.Assembly.GetName().Name;
            _typeName = type.FullName!;
        }

        public static CachedType NotFound(string assemblyName, string typeName) => new CachedType(null!, assemblyName, typeName); 

        public object CreateInstance() => Activator.CreateInstance(ActualType);

        public object? GetFieldValue(string fieldName) => ActualType.GetField(fieldName).GetValue(null);
        public void SetFieldValue(string fieldName, object? value) => ActualType.GetField(fieldName).SetValue(null, value);
        public object? GetPropertyValue(string fieldName) => ActualType.GetProperty(fieldName)!.GetValue(null);
        public void SetPropertyValue(string fieldName, object? value) => ActualType.GetProperty(fieldName)!.SetValue(null, value);

        public object? GetFieldValueOf(object self, string fieldName) => ActualType.GetField(fieldName).GetValue(self);
        public void SetFieldValueOf(object self, string fieldName, object? value) => ActualType.GetField(fieldName).SetValue(self, value);
        public object? GetPropertyValueOf(object self, string fieldName) => ActualType.GetProperty(fieldName)!.GetValue(self);
        public void SetPropertyValueOf(object self, string fieldName, object? value) => ActualType.GetProperty(fieldName)!.SetValue(self, value);
    }
}
