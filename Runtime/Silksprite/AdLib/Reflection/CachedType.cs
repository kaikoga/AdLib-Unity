using System;
using JetBrains.Annotations;

namespace Silksprite.AdLib.Reflection
{
    [PublicAPI]
    public class CachedType
    {
        public static readonly CachedType NotFound = new CachedType(null!); 

        readonly Type? _actualType;
        public Type ActualType => _actualType!;
        public bool IsImplemented => _actualType != null;

        public CachedType(Type type) => _actualType = type;

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
