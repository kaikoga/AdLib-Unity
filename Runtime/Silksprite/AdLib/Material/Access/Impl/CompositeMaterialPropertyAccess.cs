using System.Collections.Generic;
using System.Linq;

namespace Silksprite.AdLib.Material.Access.Impl
{
    public class CompositeMaterialPropertyAccess<T> : IMaterialPropertyAccess<T>
    {
        readonly IMaterialPropertyAccess<T>[] _accesses;

        public CompositeMaterialPropertyAccess(IEnumerable<IMaterialPropertyAccess<T>> accesses)
        {
            _accesses = accesses.ToArray();
        }

        public T Value
        {
            get => _accesses.Length == 0 ? default : _accesses[0].Value;
            set
            {
                foreach (var access in _accesses) access.Value = value;
            }
        }
    }
}
