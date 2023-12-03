#if VRM0

using UnityEditor;
using UnityEngine;
using VRM;

namespace LibVRMTool.Utils.VRM0
{
    public class CustomCloneBlendShapeAvatar : CustomClone<BlendShapeAvatar>
    {
        readonly bool _rename;

        public CustomCloneBlendShapeAvatar(bool rename = false)
        {
            _rename = rename;
        }

        protected override void Define(CopyStrategyDescriptor descriptor)
        {
            descriptor.DeepCopy<BlendShapeAvatar>(postProcess: Rename);
            descriptor.DeepCopy<BlendShapeClip>(postProcess: Rename);
            descriptor.ShallowCopy<MonoScript>();
            descriptor.ShallowCopy<GameObject>();

            void Rename(Object obj)
            {
                if (_rename) obj.name = $"{obj.name} (Clone)";
            }
        }

        [MenuItem("Assets/LibVRMTool/Duplicate VRM0 BlendShapeAvatar", true)]
        static bool CheckDuplicateBlendShapeAvatar(MenuCommand menuCommand)
        {
            return Selection.activeObject is BlendShapeAvatar;
        }

        [MenuItem("Assets/LibVRMTool/Duplicate VRM0 BlendShapeAvatar", false)]
        static void DuplicateBlendShapeAvatar(MenuCommand menuCommand)
        {
            if (Selection.activeObject is BlendShapeAvatar blendShapeAvatar)
            {
                new CustomCloneBlendShapeAvatar().CloneAsNewAsset(blendShapeAvatar, AssetDatabase.GenerateUniqueAssetPath($"Assets/{blendShapeAvatar.name}.asset"));
            }
        }
    }
}

#endif