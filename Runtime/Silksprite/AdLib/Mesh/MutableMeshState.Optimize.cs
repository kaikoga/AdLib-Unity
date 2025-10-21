using System.Collections.Generic;
using System.Linq;

namespace Silksprite.AdLib.Mesh
{
    public partial class MutableMeshState<TBone, TMaterial>
    {
        void MergeSubMeshes()
        {
            var subMeshMapping = Materials.Select((m, i) => (m, i))
                .GroupBy(mi => mi.m)
                .ToArray();
            Mesh.MergeSubMeshes(subMeshMapping.Select(g => g.Select(mi => mi.i).ToArray()).ToArray());
            Materials.Clear();
            Materials.AddRange(subMeshMapping.Select(g => g.Key));
        }

        void RemoveUnusedBones()
        {
            var bones = Mesh.BoneWeights
                .SelectMany(w => w.BoneWeights)
                .Select(b => b.bone)
                .Distinct()
                .ToArray();
            Mesh.BoneList.Clear();
            for (var i = 0; i < bones.Length; i++)
            {
                var bone = bones[i];
                bone.BoneIndex = i;
                Mesh.BoneList.Add(bone);
            }
            var oldMappings = BoneMapping.Mappings.ToDictionary(kv => kv.Key, kv => kv.Value);
            BoneMapping.Clear();
            foreach (var kv in oldMappings)
            {
                BoneMapping.AddBoneMapping(kv.Key, kv.Value);
            }
        }

        void RemoveDuplicateBones()
        {
            var boneReverseMappings = BoneMapping.Mappings
                .GroupBy(
                    kv => kv.Value,
                    kv => kv.Key)
                .ToDictionary(g => g.Key, g => g.FirstOrDefault());
            var remapBones = BoneMapping
                .Mappings
                .ToDictionary(kv => kv.Key, kv => boneReverseMappings.GetValueOrDefault(kv.Value));
            Mesh.RemapBones(bone => remapBones.GetValueOrDefault(bone));
            
            BoneMapping.Clear();
            foreach (var boneReverseMapping in boneReverseMappings)
            {
                BoneMapping.AddBoneMapping(boneReverseMapping.Value, boneReverseMapping.Key);
            }
        }

        public void GC()
        {
            MergeSubMeshes();
            RemoveUnusedBones();
            RemoveDuplicateBones();
            Mesh.RemoveUnusedVertices();
        }

        public void GCInPlace()
        {
            Mesh.GCInPlace();
        }
    }
}