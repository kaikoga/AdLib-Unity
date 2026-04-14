using System;
using JetBrains.Annotations;

namespace Silksprite.AdLib.Reflection.Attributes
{
    [PublicAPI]
    public class ReflectionAccessAttribute : Attribute
    {
        public readonly string TypeFullName;
        public readonly string AssemblyName;

        public ReflectionAccessAttribute(string typeFullName, string assemblyName)
        {
            TypeFullName = typeFullName;
            AssemblyName = assemblyName;
        }
    }
}
