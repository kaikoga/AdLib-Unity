using System.Linq;

namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialTargetsRenderQueueAccess : CompositeMaterialPropertyAccess<int>
    {
        public MaterialTargetsRenderQueueAccess(UnityEngine.Object[] targets)
            : base(targets.OfType<UnityEngine.Material>()
                .Select(material => (IMaterialPropertyAccess<int>)new MaterialRenderQueueAccess(material)))
        {
        }
    }
}
