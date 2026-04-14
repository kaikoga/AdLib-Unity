using System;
using JetBrains.Annotations;

namespace Silksprite.AdLib.Reflection.Base
{
    [PublicAPI]
    public abstract class EnumAccessBase : ReflectionAccessBase
    {
    }

    [PublicAPI]
    public abstract class EnumAccessBase<TAccess> : EnumAccessBase
        where TAccess : struct, Enum
    {
        readonly CachedType _cachedType;

        protected EnumAccessBase(CachedType cachedType)
        {
            _cachedType = cachedType;
        }

        public TAccess ToAccess(dynamic value)
        {
            return (TAccess)Enum.ToObject(typeof(TAccess), (int)(object)value);
        }

        public TAccess? ToAccessNullable(dynamic value)
        {
            return value is { } val ? ToAccess(val) : null;
        }

        public dynamic ToActual(TAccess value)
        {
            return Enum.ToObject(_cachedType.ActualType, (int)(object)value);
        }

        public dynamic? ToActualNullable(TAccess? value)
        {
            return value is { } val ? ToActual(val) : null;
        }
    }
}
