using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Silksprite.AdLib.Mesh
{
    public class MutableBoneWeight<TBone>
    {
        // FIXME: TBone may be null

        public readonly List<(MutableBone<TBone> bone, float weight)> BoneWeights = new List<(MutableBone<TBone> bone, float weight)>();

        public IEnumerable<MutableBone<TBone>> Bones => BoneWeights.Select(weight => weight.bone);
        public int Length => BoneWeights.Count;

        MutableBoneWeight() { }

        public MutableBoneWeight(IEnumerable<(MutableBone<TBone> bone, float weight)> weights)
        {
            BoneWeights.AddRange(weights);
        }

        [PublicAPI]
        public static MutableBoneWeight<TBone> FromBoneWeight(BoneWeight boneWeight, MutableBoneMapping<TBone> bones)
        {
            var mutableBoneWeight = new MutableBoneWeight<TBone>();
            if (boneWeight.weight0 > 0f) mutableBoneWeight.BoneWeights.Add((bones.Bone(boneWeight.boneIndex0), boneWeight.weight0));
            if (boneWeight.weight1 > 0f) mutableBoneWeight.BoneWeights.Add((bones.Bone(boneWeight.boneIndex1), boneWeight.weight1));
            if (boneWeight.weight2 > 0f) mutableBoneWeight.BoneWeights.Add((bones.Bone(boneWeight.boneIndex2), boneWeight.weight2));
            if (boneWeight.weight3 > 0f) mutableBoneWeight.BoneWeights.Add((bones.Bone(boneWeight.boneIndex3), boneWeight.weight3));
            return mutableBoneWeight;
        }

        [PublicAPI]
        public BoneWeight ToBoneWeight(MutableBoneMapping<TBone> bones)
        {
            return new BoneWeight
            {
                weight0 = BoneWeights.Count > 0 ? BoneWeights[0].weight : 0f,
                weight1 = BoneWeights.Count > 1 ? BoneWeights[1].weight : 0f,
                weight2 = BoneWeights.Count > 2 ? BoneWeights[2].weight : 0f,
                weight3 = BoneWeights.Count > 3 ? BoneWeights[3].weight : 0f,
                boneIndex0 = BoneWeights.Count > 0 ? bones.IndexOf(BoneWeights[0].bone.BoneObject) : 0,
                boneIndex1 = BoneWeights.Count > 1 ? bones.IndexOf(BoneWeights[1].bone.BoneObject) : 0,
                boneIndex2 = BoneWeights.Count > 2 ? bones.IndexOf(BoneWeights[2].bone.BoneObject) : 0,
                boneIndex3 = BoneWeights.Count > 3 ? bones.IndexOf(BoneWeights[3].bone.BoneObject) : 0
            };
        }

        public IEnumerable<BoneWeight1> ToBoneWeights(MutableBoneMapping<TBone> bones)
        {
            return BoneWeights.Select(weight => new BoneWeight1
            {
                boneIndex = bones.IndexOf(weight.bone.BoneObject),
                weight = weight.weight
            });
        }
    }
}