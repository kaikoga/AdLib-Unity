using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Silksprite.AdLib.Mesh.View
{
    public readonly struct MutableMeshStateView<TBone, TMaterial>
    {
        [PublicAPI]
        public readonly MutableMeshState<TBone, TMaterial> MeshState;

        public MutableMeshStateView(MutableMeshState<TBone, TMaterial> meshState)
        {
            MeshState = meshState;
        }

        public IEnumerable<MutableVertexStateView<TBone, TMaterial>> Vertices
        {
            get
            {
                var meshState = MeshState;
                return Enumerable.Range(0, meshState.Mesh.Vertices.Count).Select(i => new MutableVertexStateView<TBone, TMaterial>(meshState, i));
            }
        }
        public IEnumerable<MutableSubMeshStateView<TBone, TMaterial>> SubMeshes
        {
            get
            {
                var meshState = MeshState;
                return MeshState.Mesh.SubMeshes.Select(subMesh => new MutableSubMeshStateView<TBone, TMaterial>(meshState, subMesh));
            }
        }
    }
}