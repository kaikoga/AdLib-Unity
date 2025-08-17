using Silksprite.AdLib.Material.Access;

namespace Silksprite.AdLib.Material.Impl
{
    public abstract class ShaderMaterialAccessBase
    {
        protected readonly IMaterialAccess MaterialAccess;

        protected ShaderMaterialAccessBase(IMaterialAccess access) => MaterialAccess = access;

        public UnityEngine.Material Target => MaterialAccess.Target;
        public UnityEngine.Material[] Targets => MaterialAccess.Targets;

        public IMaterialPropertyAccess<int> RenderQueue => MaterialAccess.RenderQueue();
    }
}
