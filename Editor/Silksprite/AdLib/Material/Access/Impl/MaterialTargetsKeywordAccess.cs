using System.Linq;

namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialTargetsKeywordAccess : CompositeMaterialPropertyAccess<bool>
    {
        public MaterialTargetsKeywordAccess(UnityEngine.Object[] targets, string keyword)
            : base(targets.OfType<UnityEngine.Material>()
                .Select(material => (IMaterialPropertyAccess<bool>)new MaterialKeywordAccess(material, keyword)))
        {
        }
    }
}
