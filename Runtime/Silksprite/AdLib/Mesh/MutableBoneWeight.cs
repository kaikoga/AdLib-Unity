using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Silksprite.AdLib.Mesh
{
    public class MutableBoneWeight
    {
        // FIXME: TBone may be null

        public readonly List<(MutableBone bone, float weight)> BoneWeights = new List<(MutableBone bone, float weight)>();

        public int Length => BoneWeights.Count;

        MutableBoneWeight() { }

        public MutableBoneWeight(IEnumerable<(MutableBone bone, float weight)> weights)
        {
            BoneWeights.AddRange(weights);
        }

        [PublicAPI]
        public static MutableBoneWeight FromBoneWeight(BoneWeight boneWeight, MutableBoneList boneList)
        {
            var mutableBoneWeight = new MutableBoneWeight();
            if (boneWeight.weight0 > 0f) mutableBoneWeight.BoneWeights.Add((boneList.Bone(boneWeight.boneIndex0), boneWeight.weight0));
            if (boneWeight.weight1 > 0f) mutableBoneWeight.BoneWeights.Add((boneList.Bone(boneWeight.boneIndex1), boneWeight.weight1));
            if (boneWeight.weight2 > 0f) mutableBoneWeight.BoneWeights.Add((boneList.Bone(boneWeight.boneIndex2), boneWeight.weight2));
            if (boneWeight.weight3 > 0f) mutableBoneWeight.BoneWeights.Add((boneList.Bone(boneWeight.boneIndex3), boneWeight.weight3));
            return mutableBoneWeight;
        }

        [PublicAPI]
        public BoneWeight ToBoneWeight(MutableBoneList boneList)
        {
            return new BoneWeight
            {
                weight0 = BoneWeights.Count > 0 ? BoneWeights[0].weight : 0f,
                weight1 = BoneWeights.Count > 1 ? BoneWeights[1].weight : 0f,
                weight2 = BoneWeights.Count > 2 ? BoneWeights[2].weight : 0f,
                weight3 = BoneWeights.Count > 3 ? BoneWeights[3].weight : 0f,
                boneIndex0 = BoneWeights.Count > 0 ? boneList.BoneIndex(BoneWeights[0].bone) : 0,
                boneIndex1 = BoneWeights.Count > 1 ? boneList.BoneIndex(BoneWeights[1].bone) : 0,
                boneIndex2 = BoneWeights.Count > 2 ? boneList.BoneIndex(BoneWeights[2].bone) : 0,
                boneIndex3 = BoneWeights.Count > 3 ? boneList.BoneIndex(BoneWeights[3].bone) : 0
            };
        }

        public IEnumerable<BoneWeight1> ToBoneWeights(MutableBoneList boneList)
        {
            return BoneWeights.Select(weight => new BoneWeight1
            {
                boneIndex = boneList.BoneIndex(weight.bone),
                weight = weight.weight
            });
        }
    }
}