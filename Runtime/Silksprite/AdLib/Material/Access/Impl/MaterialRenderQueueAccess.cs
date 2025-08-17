namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialRenderQueueAccess : IMaterialPropertyAccess<int>
    {
        readonly UnityEngine.Material _material;

        public MaterialRenderQueueAccess(UnityEngine.Material material)
        {
            _material = material;
        }

        int IMaterialPropertyAccess<int>.Value
        {
            get => _material.renderQueue;
            set => _material.renderQueue = value;
        }
    }
}
