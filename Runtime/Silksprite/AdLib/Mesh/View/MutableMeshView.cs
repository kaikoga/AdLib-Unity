using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Silksprite.AdLib.Mesh.View
{
    public readonly struct MutableMeshView<TBone, TMaterial>
    {
        [PublicAPI]
        public readonly MutableMesh<TBone, TMaterial> Mesh;

        public MutableMeshView(MutableMesh<TBone, TMaterial> mesh)
        {
            Mesh = mesh;
        }

        public IEnumerable<MutableVertexView<TBone, TMaterial>> Vertices
        {
            get
            {
                var mesh = Mesh;
                return Enumerable.Range(0, mesh.Vertices.Count).Select(i => new MutableVertexView<TBone, TMaterial>(mesh, i));
            }
        }
        public IEnumerable<MutableSubMeshView<TBone, TMaterial>> SubMeshes
        {
            get
            {
                var mesh = Mesh;
                return Mesh.SubMeshes.Select(subMesh => new MutableSubMeshView<TBone, TMaterial>(mesh, subMesh));
            }
        }
    }
}