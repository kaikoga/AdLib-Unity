using System.Collections.Generic;
using System.Linq;

namespace Silksprite.AdLib.Mesh
{
    public class MutableSubMesh<TMaterial>
    {
        public readonly List<int> Indices;
        public readonly TMaterial Material;

        public MutableSubMesh(List<int> indices, TMaterial material)
        {
            Indices = indices;
            Material = material;
        }

        public MutableSubMesh(IEnumerable<int> indices, TMaterial material) : this (indices.ToList(), material) { }
    }
}