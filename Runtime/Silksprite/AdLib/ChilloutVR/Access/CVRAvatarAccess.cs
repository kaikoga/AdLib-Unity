using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;
using UnityEngine;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ReflectionAccess("ABI.CCK.Components.CVRAvatar", "Assembly-CSharp")]
    public class CVRAvatarAccess : ObjectAccessBase<MonoBehaviour>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.CVRAvatar");
        static CachedType CachedType___ => CachedType;
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public CVRAvatarAccess() : base(CachedType.CreateInstance()) { }
        public CVRAvatarAccess(object baseObject) : base(baseObject) { }
        public static CVRAvatarAccess? Nullable(object? baseObject) => baseObject != null ? new CVRAvatarAccess(baseObject) : null;
        
        // Direct Field
        public Vector3 viewPosition
        {
            get => (Vector3)CachedType___.GetFieldValueOf(BaseObject, nameof(viewPosition));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(viewPosition), value);
        }
        
        // Direct Field
        public Vector3 voicePosition
        {
            get => (Vector3)CachedType___.GetFieldValueOf(BaseObject, nameof(voicePosition));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(voicePosition), value);
        }
        
        // CVRAvatar.CVRAvatarVoiceParent voiceParent
        
        // Direct Field
        public AnimatorOverrideController? overrides
        {
            get => (AnimatorOverrideController)CachedType___.GetFieldValueOf(BaseObject, nameof(overrides));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(overrides), value);
        }
        
        // Direct Field
        public SkinnedMeshRenderer? bodyMesh
        {
            get => (SkinnedMeshRenderer)CachedType___.GetFieldValueOf(BaseObject, nameof(bodyMesh));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(bodyMesh), value);
        }
        
        // Direct Field
        public Vector2 eyeMovementInterval
        {
            get => (Vector2)CachedType___.GetFieldValueOf(BaseObject, nameof(eyeMovementInterval));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(eyeMovementInterval), value);
        }
        
        // Direct Field
        public bool useEyeMovement
        {
            get => (bool)CachedType___.GetFieldValueOf(BaseObject, nameof(useEyeMovement));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(useEyeMovement), value);
        }
        
        // CVRAvatar.EyeMovementInfo eyeMovementInfo
        
        // Direct Field
        public bool useBlinkBlendshapes
        {
            get => (bool)CachedType___.GetFieldValueOf(BaseObject, nameof(useBlinkBlendshapes));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(useBlinkBlendshapes), value);
        }
        
        // Direct Field
        public string?[]? blinkBlendshape
        {
            get => (string[])CachedType___.GetFieldValueOf(BaseObject, nameof(blinkBlendshape));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(blinkBlendshape), value);
        }
        
        // Direct Field
        public Vector2 blinkGap
        {
            get => (Vector2)CachedType___.GetFieldValueOf(BaseObject, nameof(blinkGap));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(blinkGap), value);
        }
        
        // Direct Field
        public Vector2 blinkDuration
        {
            get => (Vector2)CachedType___.GetFieldValueOf(BaseObject, nameof(blinkDuration));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(blinkDuration), value);
        }
        
        // EnumAccess Field
        public CVRAvatarClass.CVRAvatarEyeBlinkModeAccess.EnumValues blinkMode
        {
            get => CVRAvatarClass.CVRAvatarEyeBlinkModeAccess.Shared.ToAccess(CachedType___.GetFieldValueOf(BaseObject, nameof(blinkMode)));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(blinkMode), CVRAvatarClass.CVRAvatarEyeBlinkModeAccess.Shared.ToActual___(value));
        }
        
        // Direct Field
        public bool useVisemeLipsync
        {
            get => (bool)CachedType___.GetFieldValueOf(BaseObject, nameof(useVisemeLipsync));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(useVisemeLipsync), value);
        }
        
        // EnumAccess Field
        public CVRAvatarClass.CVRAvatarVisemeModeAccess.EnumValues visemeMode
        {
            get => CVRAvatarClass.CVRAvatarVisemeModeAccess.Shared.ToAccess(CachedType___.GetFieldValueOf(BaseObject, nameof(visemeMode)));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(visemeMode), CVRAvatarClass.CVRAvatarVisemeModeAccess.Shared.ToActual___(value));
        }
        
        // Direct Field
        public int visemeSmoothing
        {
            get => (int)CachedType___.GetFieldValueOf(BaseObject, nameof(visemeSmoothing));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(visemeSmoothing), value);
        }
        
        // Direct Field
        public string?[]? visemeBlendshapes
        {
            get => (string[])CachedType___.GetFieldValueOf(BaseObject, nameof(visemeBlendshapes));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(visemeBlendshapes), value);
        }
        
        // Direct Field
        public bool enableCustomFPR
        {
            get => (bool)CachedType___.GetFieldValueOf(BaseObject, nameof(enableCustomFPR));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(enableCustomFPR), value);
        }
        
        // List<CVRAvatarFPREntry> fprSettingsList
        
        // Direct Field
        public bool enableAdvancedTagging
        {
            get => (bool)CachedType___.GetFieldValueOf(BaseObject, nameof(enableAdvancedTagging));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(enableAdvancedTagging), value);
        }
        
        // List<CVRAvatarAdvancedTaggingEntry> advancedTaggingList
        
        // Direct Field
        public bool avatarUsesAdvancedSettings
        {
            get => (bool)CachedType___.GetFieldValueOf(BaseObject, nameof(avatarUsesAdvancedSettings));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(avatarUsesAdvancedSettings), value);
        }
        
        // Access Field
        public CVRAdvancedAvatarSettingsAccess? avatarSettings
        {
            get => CVRAdvancedAvatarSettingsAccess.Nullable(CachedType___.GetFieldValueOf(BaseObject, nameof(avatarSettings)));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(avatarSettings), value?.BaseObject);
        }
        
        // Direct Field
        public static float EyeMovementMinIntervalLimit
        {
            get => (float)CachedType___.GetFieldValue(nameof(EyeMovementMinIntervalLimit));
            set => CachedType___.SetFieldValue(nameof(EyeMovementMinIntervalLimit), value);
        }
        
        // Direct Field
        public static float EyeMovementMaxIntervalLimit
        {
            get => (float)CachedType___.GetFieldValue(nameof(EyeMovementMaxIntervalLimit));
            set => CachedType___.SetFieldValue(nameof(EyeMovementMaxIntervalLimit), value);
        }
        
        // Direct Field
        public static float DefaultEyeAngleLimitDown
        {
            get => (float)CachedType___.GetFieldValue(nameof(DefaultEyeAngleLimitDown));
            set => CachedType___.SetFieldValue(nameof(DefaultEyeAngleLimitDown), value);
        }
        
        // Direct Field
        public static float DefaultEyeAngleLimitUp
        {
            get => (float)CachedType___.GetFieldValue(nameof(DefaultEyeAngleLimitUp));
            set => CachedType___.SetFieldValue(nameof(DefaultEyeAngleLimitUp), value);
        }
        
        // Direct Field
        public static float DefaultEyeAngleLimitIn
        {
            get => (float)CachedType___.GetFieldValue(nameof(DefaultEyeAngleLimitIn));
            set => CachedType___.SetFieldValue(nameof(DefaultEyeAngleLimitIn), value);
        }
        
        // Direct Field
        public static float DefaultEyeAngleLimitOut
        {
            get => (float)CachedType___.GetFieldValue(nameof(DefaultEyeAngleLimitOut));
            set => CachedType___.SetFieldValue(nameof(DefaultEyeAngleLimitOut), value);
        }
        
        // Direct Field
        public static float DefaultUniformAngleLimit
        {
            get => (float)CachedType___.GetFieldValue(nameof(DefaultUniformAngleLimit));
            set => CachedType___.SetFieldValue(nameof(DefaultUniformAngleLimit), value);
        }
        
        // Direct Field
        public static float BlinkMinGapLimit
        {
            get => (float)CachedType___.GetFieldValue(nameof(BlinkMinGapLimit));
            set => CachedType___.SetFieldValue(nameof(BlinkMinGapLimit), value);
        }
        
        // Direct Field
        public static float BlinkMaxGapLimit
        {
            get => (float)CachedType___.GetFieldValue(nameof(BlinkMaxGapLimit));
            set => CachedType___.SetFieldValue(nameof(BlinkMaxGapLimit), value);
        }
        
        // Direct Field
        public static float BlinkMinDurationLimit
        {
            get => (float)CachedType___.GetFieldValue(nameof(BlinkMinDurationLimit));
            set => CachedType___.SetFieldValue(nameof(BlinkMinDurationLimit), value);
        }
        
        // Direct Field
        public static float BlinkMaxDurationLimit
        {
            get => (float)CachedType___.GetFieldValue(nameof(BlinkMaxDurationLimit));
            set => CachedType___.SetFieldValue(nameof(BlinkMaxDurationLimit), value);
        }
    }
}
