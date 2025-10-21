using System.Collections.Generic;
using System.Linq;

namespace Silksprite.AdLib.Mesh
{
    public class MutableSubMesh
    {
        public readonly List<int> Indices;

        public MutableSubMesh(List<int> indices)
        {
            Indices = indices;
        }

        public MutableSubMesh(IEnumerable<int> indices) : this(indices.ToList()) { }
    }
}