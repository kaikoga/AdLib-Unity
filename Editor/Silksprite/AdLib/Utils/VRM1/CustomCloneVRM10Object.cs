#if VRM1

using UnityEditor;
using UnityEngine;
using UniVRM10;

namespace Silksprite.AdLib.Utils.VRM1
{
    public class CustomCloneVRM10Object : CustomClone<VRM10Object>
    {
        readonly bool _rename;
        readonly bool _copyThumbnail;

        public CustomCloneVRM10Object(bool rename = false, bool copyThumbnail = false)
        {
            _rename = rename;
            _copyThumbnail = copyThumbnail;
        }
        
        protected override void Define(CopyStrategyDescriptor descriptor)
        {
            descriptor.DeepCopy<VRM10Object>(postProcess: Rename);
            descriptor.DeepCopy<VRM10Expression>(postProcess: Rename);

            if (_copyThumbnail)
            {
                descriptor.DeepCopy<Texture2D>();
            }
            else
            {
                descriptor.ShallowCopy<Texture2D>();
            }
            
            descriptor.ShallowCopy<MonoScript>();
            descriptor.ShallowCopy<GameObject>();

            void Rename(Object obj)
            {
                if (_rename) obj.name = $"{obj.name} (Clone)";
            }
        }

        [MenuItem("Assets/LibVRMTool/Duplicate VRM1 Object", true)]
        static bool CheckDuplicateVrm10Object(MenuCommand menuCommand)
        {
            return Selection.activeObject is VRM10Object;
        }

        [MenuItem("Assets/LibVRMTool/Duplicate VRM1 Object", false)]
        static void DuplicateVrm10Object(MenuCommand menuCommand)
        {
            if (Selection.activeObject is VRM10Object vrm10Object)
            {
                new CustomCloneVRM10Object().CloneAsNewAsset(vrm10Object, AssetDatabase.GenerateUniqueAssetPath($"Assets/{vrm10Object.name}.asset"));
            }
        }
    }
}

#endif