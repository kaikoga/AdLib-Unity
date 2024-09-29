using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Silksprite.AdLib.Mesh.View
{
    public readonly struct MutableSubMeshView<TBone, TMaterial>
    {
        [PublicAPI]
        public readonly MutableMesh<TBone, TMaterial> Mesh;
        [PublicAPI]
        public readonly MutableSubMesh<TMaterial> SubMesh;

        public List<int> Indices => SubMesh.Indices;

        public MutableSubMeshView(MutableMesh<TBone, TMaterial> mesh, MutableSubMesh<TMaterial> subMesh)
        {
            Mesh = mesh;
            SubMesh = subMesh;
        }

        public IEnumerable<MutableVertexView<TBone, TMaterial>> Vertices
        {
            get
            {
                var mesh = Mesh;
                return SubMesh.Indices.Select(index => new MutableVertexView<TBone, TMaterial>(mesh, index));
            }
        }

        public IEnumerable<MutableTriangleView<TBone, TMaterial>> Triangles
        {
            get
            {
                var i = 0;
                while (true)
                {
                    if (i >= SubMesh.Indices.Count) break;
                    var a = SubMesh.Indices[i++];
                    if (i >= SubMesh.Indices.Count) break;
                    var b = SubMesh.Indices[i++];
                    if (i >= SubMesh.Indices.Count) break;
                    var c = SubMesh.Indices[i++];
                    yield return new MutableTriangleView<TBone, TMaterial>(Mesh, a, b, c);
                }
            }
        }
    }
}