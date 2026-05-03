using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

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
            return GetAssembly(assemblyName)?.GetType(typeName) ?? CachedType.NotFound(assemblyName, typeName);
        }

        public CachedType GetRuntimeType(string typeName) => GetType("Assembly-CSharp", typeName);
        public CachedType GetEditorType(string typeName) => GetType("Assembly-CSharp-Editor", typeName);
    }
}
