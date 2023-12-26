#if VRM0

using UnityEditor;
using UnityEngine;
using VRM;

namespace Silksprite.AdLib.Utils.VRM0
{
    public class CustomCloneVRMMetaObject : CustomClone<VRMMetaObject>
    {
        readonly bool _rename;
        readonly bool _copyThumbnail;

        public CustomCloneVRMMetaObject(bool rename = false, bool copyThumbnail = false)
        {
            _rename = rename;
            _copyThumbnail = copyThumbnail;
        }
        
        protected override void Define(CopyStrategyDescriptor descriptor)
        {
            descriptor.DeepCopy<VRMMetaObject>(postProcess: Rename);
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
    }
}

#endif