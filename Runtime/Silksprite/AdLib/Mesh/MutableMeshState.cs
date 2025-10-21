using System.Collections.Generic;
using System.Linq;

namespace Silksprite.AdLib.Mesh
{
    public partial class MutableMeshState<TBone, TMaterial>
    {
        public readonly MutableMesh Mesh;

        public readonly MutableBoneMapping<TBone> BoneMapping = new MutableBoneMapping<TBone>();
        public readonly List<float> BlendShapeWeights = new List<float>();
        public readonly List<TMaterial> Materials = new List<TMaterial>();

        public MutableMeshState(string name)
        {
            Mesh = new MutableMesh(name);
        }

        public MutableMeshState(UnityEngine.Mesh mesh, IEnumerable<float> blendShapeWeights, MutableBoneMapping<TBone> boneMapping, IEnumerable<TMaterial> materials)
        {
            var boneList = new MutableBoneList(BoneMapping.MergeMapping(boneMapping));
            Mesh = new MutableMesh(mesh, boneList);
            BlendShapeWeights.AddRange(blendShapeWeights);
            Materials.AddRange(materials);
        }

        public void Add(UnityEngine.Mesh mesh, MutableBoneMapping<TBone> boneMapping, IEnumerable<TMaterial> materials)
        {
            var boneList = new MutableBoneList(BoneMapping.MergeMapping(boneMapping).ToArray());
            Mesh.Add(mesh, boneList);
            Materials.AddRange(materials);
        }
    }
}