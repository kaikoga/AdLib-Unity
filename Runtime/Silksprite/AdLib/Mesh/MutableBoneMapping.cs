using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Silksprite.AdLib.Mesh
{
    public class MutableBoneMapping<TBone>
    {
        readonly List<MutableBone<TBone>> _bones = new List<MutableBone<TBone>>();

        public MutableBone<TBone> Bone(int boneIndex) => _bones[boneIndex];

        public IEnumerable<TBone> BoneObjects => _bones.Select(bone => bone.BoneObject);
        public IEnumerable<Matrix4x4> BindPoses => _bones.Select(bone => bone.BindPose);

        public int IndexOf(TBone boneObject)
        {
            for (var i = 0; i < _bones.Count; i++)
            {
                if (EqualityComparer<TBone>.Default.Equals(_bones[i].BoneObject, boneObject)) return i;
            }
            return -1;
        }

        public Matrix4x4 BindPose(TBone boneObject) => _bones[IndexOf(boneObject)].BindPose;

        public void Add(MutableBone<TBone> bone) => _bones.Add(bone);

        public void AddRange(MutableBoneMapping<TBone> bones) => _bones.AddRange(bones._bones);

        public void Filter(IEnumerable<TBone> boneObjects)
        {
            var entries = _bones.Where(bone => boneObjects.Contains(bone.BoneObject))
                .Distinct(MutableBone<TBone>.BoneObjectComparer)
                .ToArray();
            _bones.Clear();
            _bones.AddRange(entries); 
        }

        public void Distinct()
        {
            var entries = _bones
                .Distinct(MutableBone<TBone>.BoneObjectComparer)
                .ToArray();
            _bones.Clear();
            _bones.AddRange(entries); 
        }
    }

    public static class MutableBoneMapping
    {
        public static MutableBoneMapping<Transform> From(SkinnedMeshRenderer source)
        {
            var bones = new MutableBoneMapping<Transform>();
            foreach (var bone in source.bones.Zip(source.sharedMesh.bindposes, (t, m) => new MutableBone<Transform>(t, m)))
            {
                bones.Add(bone);
            }
            return bones;
        }
    }
}