using System;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using UnityEngine;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ReflectionAccess("ABI.CCK.Components.CVRAvatar", "ABI.CCK.Components")]
    public class CVRAvatarAccess : ObjectAccessBase<Component>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.CVRAvatar");
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;

        public CVRAvatarAccess(object baseObject) : base(baseObject) { }

        public Vector3 viewPosition
        {
            get => DynamicObject.viewPosition;
            set => DynamicObject.viewPosition = value;
        }

        public SkinnedMeshRenderer bodyMesh
        {
            get => DynamicObject.bodyMesh;
            set => DynamicObject.bodyMesh = value;
        }

        public bool useBlinkBlendshapes
        {
            get => DynamicObject.useBlinkBlendshapes;
            set => DynamicObject.useBlinkBlendshapes = value;
        }

        public string[] blinkBlendshape
        {
            get => DynamicObject.blinkBlendshape;
            set => DynamicObject.blinkBlendshape = value;
        }

        public CVRAvatarClass.CVRAvatarEyeBlinkModeAccess.EnumValues blinkMode
        {
            get => CVRAvatarClass.CVRAvatarEyeBlinkModeAccess.Shared.ToAccess(DynamicObject.blinkMode);
            set => DynamicObject.blinkMode = CVRAvatarClass.CVRAvatarEyeBlinkModeAccess.Shared.ToActual(value);
        }

        public bool useVisemeLipsync
        {
            get => DynamicObject.useVisemeLipsync;
            set => DynamicObject.useVisemeLipsync = value;
        }

        public CVRAvatarClass.CVRAvatarVisemeModeAccess.EnumValues visemeMode
        {
            get => CVRAvatarClass.CVRAvatarVisemeModeAccess.Shared.ToAccess(DynamicObject.visemeMode);
            set => DynamicObject.visemeMode = CVRAvatarClass.CVRAvatarVisemeModeAccess.Shared.ToActual(value);
        }

        public string[] visemeBlendshapes
        {
            get => DynamicObject.visemeBlendshapes;
            set => DynamicObject.visemeBlendshapes = value;
        }

        public AnimatorOverrideController? overrides
        {
            get => DynamicObject.overrides;
            set => DynamicObject.overrides = value;
        }

        public bool avatarUsesAdvancedSettings
        {
            get => DynamicObject.avatarUsesAdvancedSettings;
            set => DynamicObject.avatarUsesAdvancedSettings = value;
        }

        public CVRAdvancedAvatarSettingsAccess? avatarSettings
        {
            get => CVRAdvancedAvatarSettingsAccess.Nullable(DynamicObject.avatarSettings);
            set => DynamicObject.avatarSettings = value?.DynamicObject;
        }
    }
}
