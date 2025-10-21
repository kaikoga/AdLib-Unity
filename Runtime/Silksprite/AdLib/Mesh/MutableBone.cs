using UnityEngine;

namespace Silksprite.AdLib.Mesh
{
    public class MutableBone
    {
        public readonly Matrix4x4 BindPose;
        internal int BoneIndex;

        public MutableBone(Matrix4x4 bindPose, int boneIndex = 0)
        {
            BindPose = bindPose;
            BoneIndex = boneIndex;
        }
    }
}