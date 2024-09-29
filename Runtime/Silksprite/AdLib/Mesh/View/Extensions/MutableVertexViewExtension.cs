using UnityEngine;

namespace Silksprite.AdLib.Mesh.View.Extensions
{
    public static class MutableVertexViewExtension
    {
        public static Vector3 CalculateActualPosition<TMaterial>(this MutableVertexView<Transform, TMaterial> vertex)
        {
            // TODO: blendShape values
            var v = vertex.Mesh.Vertices[vertex.Index];
            var m = Matrix4x4.zero;
            foreach (var bw in vertex.Mesh.BoneWeights[vertex.Index].BoneWeights)
            {
                var boneTransform = bw.bone.BoneObject.localToWorldMatrix;
                var bindPose = vertex.Mesh.Bones.BindPose(bw.bone.BoneObject);
                var mm = boneTransform * bindPose;

                m.m00 += mm.m00 * bw.weight;
                m.m10 += mm.m10 * bw.weight;
                m.m20 += mm.m20 * bw.weight;
                m.m30 += mm.m30 * bw.weight;
                m.m01 += mm.m01 * bw.weight;
                m.m11 += mm.m11 * bw.weight;
                m.m21 += mm.m21 * bw.weight;
                m.m31 += mm.m31 * bw.weight;
                m.m02 += mm.m02 * bw.weight;
                m.m12 += mm.m12 * bw.weight;
                m.m22 += mm.m22 * bw.weight;
                m.m32 += mm.m32 * bw.weight;
                m.m03 += mm.m03 * bw.weight;
                m.m13 += mm.m13 * bw.weight;
                m.m23 += mm.m23 * bw.weight;
                m.m33 += mm.m33 * bw.weight;
            }
            return m * new Vector4(v.x, v.y, v.z, 1.0f);
        }
    }
}