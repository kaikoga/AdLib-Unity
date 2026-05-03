using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace Silksprite.AdLib.Reflection
{
    [PublicAPI]
    public class CachedAssembly
    {
        public readonly Assembly Assembly;
        readonly string _assemblyName;

        Dictionary<string, CachedType>? _typeCache;
        Dictionary<string, CachedType> TypeCache => _typeCache ??= Assembly.GetTypes()
            .ToDictionary(type => type.FullName, type => new CachedType(type));

        public CachedAssembly(Assembly assembly)
        {
            Assembly = assembly;
            _assemblyName = assembly.GetName().Name;
        }

        public CachedType GetType(string typeName)
        {
            if (TypeCache.TryGetValue(typeName, out var cachedType))
            {
                return cachedType;
            }
            cachedType = CachedType.NotFound(_assemblyName, typeName);
            TypeCache.Add(typeName, cachedType);
            return cachedType;
        }
    }
}
