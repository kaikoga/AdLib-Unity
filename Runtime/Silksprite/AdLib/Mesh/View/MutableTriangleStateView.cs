using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Silksprite.AdLib.Mesh.View
{
    public readonly struct MutableTriangleStateView<TBone, TMaterial> : IEnumerable<MutableVertexStateView<TBone, TMaterial>>
    {
        [PublicAPI]
        public readonly MutableMeshState<TBone, TMaterial> MeshState;

        readonly int _a;
        readonly int _b;
        readonly int _c;

        public MutableVertexStateView<TBone, TMaterial> a => new MutableVertexStateView<TBone, TMaterial>(MeshState, _a);
        public MutableVertexStateView<TBone, TMaterial> b => new MutableVertexStateView<TBone, TMaterial>(MeshState, _b);
        public MutableVertexStateView<TBone, TMaterial> c => new MutableVertexStateView<TBone, TMaterial>(MeshState, _c);

        public MutableTriangleStateView(MutableMeshState<TBone, TMaterial> meshState, int a, int b, int c)
        {
            MeshState = meshState;
            _a = a;
            _b = b;
            _c = c;
        }

        public IEnumerator<MutableVertexStateView<TBone, TMaterial>> GetEnumerator()
        {
            yield return a;
            yield return b;
            yield return c;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}