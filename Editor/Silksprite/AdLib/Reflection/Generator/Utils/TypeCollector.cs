using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Silksprite.AdLib.Reflection.Base;

namespace AdLib.Reflection.Generator.Utils
{
    static class TypeCollector
    {
        public static IEnumerable<AccessTypeInfo> CollectAccessTypes()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.GetName().Name != "AdLib.Reflection")
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(ReflectionAccessBase).IsAssignableFrom(type) && !type.IsInterface)
                .Select(ToInfo)
                .OfType<AccessTypeInfo>();

            AccessTypeInfo? ToInfo(Type access)
            {
                var actual = (Type?)access.GetProperty("ActualType", BindingFlags.Public | BindingFlags.Static)?.GetValue(null);
                if (actual == null)
                {
                    return null;
                }
                var valueType = typeof(EnumAccessBase).IsAssignableFrom(access) ? access.GetNestedType("EnumValues") : access;
                if (valueType == null)
                {
                    return null;
                }
                return new AccessTypeInfo(access, actual, valueType);
            }
        }
    }
}
