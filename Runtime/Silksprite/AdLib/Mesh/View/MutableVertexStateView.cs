using JetBrains.Annotations;

namespace Silksprite.AdLib.Mesh.View
{
    public readonly struct MutableVertexStateView<TBone, TMaterial>
    {
        [PublicAPI]
        public readonly MutableMeshState<TBone, TMaterial> MeshState;
        [PublicAPI]
        public readonly int Index;

        [PublicAPI]
        public MutableBoneWeight BoneWeights => MeshState.Mesh.BoneWeights[Index];

        public MutableVertexStateView(MutableMeshState<TBone, TMaterial> meshState, int index)
        {
            MeshState = meshState;
            Index = index;
        }
    }
}