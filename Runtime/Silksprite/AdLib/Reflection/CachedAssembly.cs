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

        Dictionary<string, CachedType>? _typeCache;
        Dictionary<string, CachedType> TypeCache => _typeCache ??= Assembly.GetTypes()
            .ToDictionary(type => type.FullName, type => new CachedType(type));

        public CachedAssembly(Assembly assembly) => Assembly = assembly;

        public CachedType? GetType(string name) => TypeCache.GetValueOrDefault(name);
    }
}
