using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Silksprite.AdLib.Mesh.View
{
    public readonly struct MutableTriangleView<TBone, TMaterial> : IEnumerable<MutableVertexView<TBone, TMaterial>>
    {
        [PublicAPI]
        public readonly MutableMesh<TBone, TMaterial> Mesh;

        readonly int _a;
        readonly int _b;
        readonly int _c;

        public MutableVertexView<TBone, TMaterial> a => new MutableVertexView<TBone, TMaterial>(Mesh, _a);
        public MutableVertexView<TBone, TMaterial> b => new MutableVertexView<TBone, TMaterial>(Mesh, _b);
        public MutableVertexView<TBone, TMaterial> c => new MutableVertexView<TBone, TMaterial>(Mesh, _c);

        public MutableTriangleView(MutableMesh<TBone, TMaterial> mesh, int a, int b, int c)
        {
            Mesh = mesh;
            _a = a;
            _b = b;
            _c = c;
        }

        public IEnumerator<MutableVertexView<TBone, TMaterial>> GetEnumerator()
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