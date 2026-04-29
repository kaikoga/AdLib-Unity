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

        public TAccess ToAccess(object value)
        {
            return (TAccess)Enum.ToObject(typeof(TAccess), (int)value);
        }

        public TAccess? ToAccessNullable(object? value)
        {
            return value != null ? ToAccess(value) : default;
        }

        public object ToActual(TAccess value)
        {
            return Enum.ToObject(_cachedType.ActualType, (int)(object)value);
        }

        public object? ToActualNullable(TAccess? value)
        {
            return value is { } val ? ToActual(val) : null;
        }
    }
}
