using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Silksprite.AdLib.Mesh.View
{
    public readonly struct MutableSubMeshStateView<TBone, TMaterial>
    {
        [PublicAPI]
        public readonly MutableMeshState<TBone, TMaterial> MeshState;
        [PublicAPI]
        public readonly MutableSubMesh SubMesh;

        public List<int> Indices => SubMesh.Indices;

        public MutableSubMeshStateView(MutableMeshState<TBone, TMaterial> meshState, MutableSubMesh subMesh)
        {
            MeshState = meshState;
            SubMesh = subMesh;
        }

        public IEnumerable<MutableVertexStateView<TBone, TMaterial>> Vertices
        {
            get
            {
                var meshState = MeshState;
                return SubMesh.Indices.Select(index => new MutableVertexStateView<TBone, TMaterial>(meshState, index));
            }
        }

        public IEnumerable<MutableTriangleStateView<TBone, TMaterial>> Triangles
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
                    yield return new MutableTriangleStateView<TBone, TMaterial>(MeshState, a, b, c);
                }
            }
        }
    }
}