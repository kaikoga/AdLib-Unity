using System.Collections.Generic;
using UnityEngine;

namespace Silksprite.AdLib.Mesh
{
    public class MutableBoneMapping<TBone>
    {
        readonly Dictionary<MutableBone, TBone> _mappings = new Dictionary<MutableBone, TBone>();

        public IReadOnlyDictionary<MutableBone, TBone> Mappings => _mappings;

        public TBone BoneObject(MutableBone bone)
        {
            return _mappings.GetValueOrDefault(bone);
        }

        public MutableBone AddBoneMapping(MutableBone bone, TBone boneObject)
        {
            bone.BoneIndex = _mappings.Count;
            _mappings.Add(bone, boneObject);
            return bone;
        }

        public IEnumerable<MutableBone> MergeMapping(MutableBoneMapping<TBone> bones)
        {
            foreach (var (bone, boneObject) in bones._mappings)
            {
                yield return AddBoneMapping(bone, boneObject);
            }
        }

        public void Clear() => _mappings.Clear();
    }

    public static class MutableBoneMapping
    {
        public static MutableBoneMapping<Transform> From(SkinnedMeshRenderer source)
        {
            var boneMapping = new MutableBoneMapping<Transform>();
            var c = Mathf.Min(source.bones.Length, source.sharedMesh.bindposes.Length);
            for (var i = 0; i < c; i++)
            {
                boneMapping.AddBoneMapping(new MutableBone(source.sharedMesh.bindposes[i]), source.bones[i]);
            }
            return boneMapping;
        }
    }
}