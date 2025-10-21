using System.Collections.Generic;

namespace Silksprite.AdLib.Mesh
{
    public class MutableBoneList
    {
        readonly List<MutableBone> _bones = new List<MutableBone>();
        readonly Dictionary<MutableBone, int> _boneIndices = new Dictionary<MutableBone, int>();

        public MutableBoneList()
        {
        }

        public MutableBoneList(IEnumerable<MutableBone> bones)
        {
            foreach (var bone in bones)
            {
                Add(bone);
            }
        }

        public IEnumerable<MutableBone> Bones => _bones;

        public MutableBone Bone(int index) => _bones[index];

        public int BoneIndex(MutableBone bone) => _boneIndices.GetValueOrDefault(bone);

        public void Add(MutableBone bone)
        {
            _boneIndices.Add(bone, _bones.Count);
            _bones.Add(bone);
        }

        public void AddRange(MutableBoneList boneList)
        {
            foreach (var bone in boneList._bones)
            {
                Add(bone);
            }
        }

        public void Clear()
        {
            _boneIndices.Clear();
            _bones.Clear();
        }
    }
}