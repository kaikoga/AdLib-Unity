using System;

namespace AdLib.Reflection.Generator.Utils
{
    class AccessTypeInfo
    {
        public readonly Type Access;
        public readonly Type Actual;
        public readonly Type ValueType;

        public AccessTypeInfo(Type access, Type actual, Type valueType)
        {
            Access = access;
            Actual = actual;
            ValueType = valueType;
        }
    }
}
