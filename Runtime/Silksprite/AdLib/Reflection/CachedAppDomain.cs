using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace Silksprite.AdLib.Reflection
{
    [PublicAPI]
    public class CachedAppDomain
    {
        public static readonly CachedAppDomain Instance = new CachedAppDomain();

        Dictionary<string, CachedAssembly>? _assemblyCache;
        
        Dictionary<string, CachedAssembly> AssemblyCache => _assemblyCache ??= AppDomain.CurrentDomain.GetAssemblies()
            .ToDictionary(assembly => assembly.GetName().Name, assembly => new CachedAssembly(assembly));

        public CachedAssembly? GetAssembly(string name) => AssemblyCache.GetValueOrDefault(name);

        public CachedType? FindType(string typeName) => AssemblyCache.Values
            .Select(assembly => assembly.GetType(typeName))
            .FirstOrDefault(type => type != null);

        public CachedType GetType(string assemblyName, string typeName)
        {
            var type = GetAssembly(assemblyName)?.GetType(typeName);
            if (type == null)
            {
                Debug.LogError($"Couldn't find type {typeName} in assembly {assemblyName}");
                type = CachedType.NotFound;
            }
            return type;
        }

        public CachedType GetRuntimeType(string typeName) => GetType("Assembly-CSharp", typeName);
        public CachedType GetEditorType(string typeName) => GetType("Assembly-CSharp-Editor", typeName);
    }

    [PublicAPI]
    public class CachedAssembly
    {
        public readonly Assembly Assembly;

        Dictionary<string, CachedType>? _typeCache;
        Dictionary<string, CachedType> TypeCache => _typeCache ??= Assembly.GetTypes()
            .ToDictionary(type => type.FullName, type => new CachedType(type));

        public CachedAssembly(Assembly assembly) => Assembly = assembly;

        public CachedType? GetType(string name) => TypeCache.GetValueOrDefault(name);
    }
    
    // maybe this can be just Type?
    [PublicAPI]
    public class CachedType
    {
        public static readonly CachedType NotFound = new CachedType(null!); 

        readonly Type? _actualType;
        public Type ActualType => _actualType!;
        public bool IsImplemented => _actualType != null;

        public CachedType(Type type) => _actualType = type;

        public object CreateInstance() => Activator.CreateInstance(ActualType);

        public dynamic? GetFieldValue(string fieldName) => ActualType.GetField(fieldName).GetValue(null);
        public void SetFieldValue(string fieldName, dynamic? value) => ActualType.GetField(fieldName).SetValue(null, value);
    }
}
