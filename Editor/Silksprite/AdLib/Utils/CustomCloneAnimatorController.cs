using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace Silksprite.AdLib.Utils
{
    public class CustomCloneAnimatorController : CustomClone<AnimatorController>
    {
        readonly bool _rename;
        readonly bool _cloneClips;

        public CustomCloneAnimatorController(bool rename = false, bool cloneClips = false)
        {
            _rename = rename;
            _cloneClips = cloneClips;
        }
        
        protected override void Define(CopyStrategyDescriptor descriptor)
        {
            descriptor.DeepCopy<AnimatorController>(postProcess: Rename);
            if (_cloneClips)
            {
                descriptor.DeepCopy<AnimationClip>(postProcess: Rename);
                descriptor.DeepCopy<BlendTree>(postProcess: Rename);
            }
            else
            {
                descriptor.ShallowCopy<AnimationClip>();
                descriptor.ShallowCopy<BlendTree>();
            }

            descriptor.DeepCopy<AnimatorStateMachine>();
            descriptor.DeepCopy<AnimatorState>();
            descriptor.DeepCopy<AnimatorTransition>();
            descriptor.DeepCopy<AnimatorStateTransition>();
            descriptor.DeepCopy<StateMachineBehaviour>(true);
            
            descriptor.ShallowCopy<UnityEngine.Material>();

            descriptor.ShallowCopy<AvatarMask>();
            descriptor.ShallowCopy<MonoScript>();

            void Rename(Object obj)
            {
                if (_rename) obj.name = $"{obj.name} (Clone)";
            }
        }

        [MenuItem("Assets/Avatar DataObject Library/Duplicate Animator Controller", true)]
        [MenuItem("Assets/Avatar DataObject Library/Duplicate Animator Controller With Clips", true)]
        static bool CheckDuplicateAnimatorController(MenuCommand menuCommand)
        {
            return Selection.activeObject is AnimatorController;
        }

        [MenuItem("Assets/Avatar DataObject Library/Duplicate Animator Controller", false)]
        static void DuplicateAnimatorController(MenuCommand menuCommand)
        {
            if (Selection.activeObject is AnimatorController animatorController)
            {
                new CustomCloneAnimatorController().CloneAsNewAsset(animatorController, AssetDatabase.GenerateUniqueAssetPath($"Assets/{animatorController.name}.controller"));
            }
        }

        [MenuItem("Assets/Avatar DataObject Library/Duplicate Animator Controller With Clips", false)]
        static void DuplicateAnimatorControllerCloneClips(MenuCommand menuCommand)
        {
            if (Selection.activeObject is AnimatorController animatorController)
            {
                new CustomCloneAnimatorController(cloneClips: true).CloneAsNewAsset(animatorController, AssetDatabase.GenerateUniqueAssetPath($"Assets/{animatorController.name}.controller"));
            }
        }
    }
}
