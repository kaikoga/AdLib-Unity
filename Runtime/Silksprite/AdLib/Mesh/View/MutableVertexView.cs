using System;
using JetBrains.Annotations;

namespace Silksprite.AdLib.Mesh.View
{
    public readonly struct MutableVertexView<TBone, TMaterial> : IEquatable<MutableVertexView<TBone, TMaterial>>
    {
        [PublicAPI]
        public readonly MutableMesh<TBone, TMaterial> Mesh;
        [PublicAPI]
        public readonly int Index;

        public MutableBoneWeight<TBone> BoneWeights => Mesh.BoneWeights[Index];

        public MutableVertexView(MutableMesh<TBone, TMaterial> mesh, int index)
        {
            Mesh = mesh;
            Index = index;
        }

        public static implicit operator int(MutableVertexView<TBone, TMaterial> vertex) => vertex.Index;

        public bool Equals(MutableVertexView<TBone, TMaterial> other)
        {
            return Equals(Mesh, other.Mesh) && Index == other.Index;
        }

        public override bool Equals(object obj)
        {
            return obj is MutableVertexView<TBone, TMaterial> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Mesh, Index);
        }

        public static bool operator ==(MutableVertexView<TBone, TMaterial> left, MutableVertexView<TBone, TMaterial> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MutableVertexView<TBone, TMaterial> left, MutableVertexView<TBone, TMaterial> right)
        {
            return !left.Equals(right);
        }
    }
}