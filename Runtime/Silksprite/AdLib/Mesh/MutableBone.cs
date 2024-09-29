using System.Collections.Generic;
using UnityEngine;

namespace Silksprite.AdLib.Mesh
{
    public class MutableBone<TBone>
    {
        public readonly TBone BoneObject;
        public readonly Matrix4x4 BindPose;

        public MutableBone(TBone boneObject, Matrix4x4 bindPose)
        {
            BoneObject = boneObject;
            BindPose = bindPose;
        }

        sealed class BoneObjectEqualityComparer : IEqualityComparer<MutableBone<TBone>>
        {
            public bool Equals(MutableBone<TBone> x, MutableBone<TBone> y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return EqualityComparer<TBone>.Default.Equals(x.BoneObject, y.BoneObject);
            }

            public int GetHashCode(MutableBone<TBone> obj)
            {
                return EqualityComparer<TBone>.Default.GetHashCode(obj.BoneObject);
            }
        }

        public static IEqualityComparer<MutableBone<TBone>> BoneObjectComparer { get; } = new BoneObjectEqualityComparer();
    }
}