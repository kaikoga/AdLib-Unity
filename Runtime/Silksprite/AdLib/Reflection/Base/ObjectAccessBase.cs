using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Silksprite.AdLib.Reflection.Base
{
    [PublicAPI]
    public abstract class ObjectAccessBase : ReflectionAccessBase
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        object _baseObject;

        protected internal object ActualObject
        {
            get => _baseObject;
            protected set => _baseObject = value;
        }

        protected ObjectAccessBase(object baseObject) => _baseObject = baseObject;
    }

    [PublicAPI]
    public abstract class ObjectAccessBase<T> : ObjectAccessBase
    {
        public T BaseObject => (T)ActualObject;

        protected ObjectAccessBase(object baseObject) : base(baseObject) { }
    }

}
