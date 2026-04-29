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
    [ReflectionAccess("ABI.CCK.Scripts.CVRAdvancesAvatarSettingJoystick2D", "Assembly-CSharp")]
    public class CVRAdvancesAvatarSettingJoystick2DAccess : CVRAdvancesAvatarSettingBaseAccess
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancesAvatarSettingJoystick2D");
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public CVRAdvancesAvatarSettingJoystick2DAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancesAvatarSettingJoystick2DAccess(object baseObject) : base(baseObject) { }
        public static CVRAdvancesAvatarSettingJoystick2DAccess? Nullable(object? baseObject) => baseObject != null ? new CVRAdvancesAvatarSettingJoystick2DAccess(baseObject) : null;
        
        // Direct Field
        public Vector2 defaultValue
        {
            get => (Vector2)CachedType.GetFieldValueOf(BaseObject, nameof(defaultValue));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(defaultValue), value);
        }
        
        // Direct Field
        public Vector2 rangeMin
        {
            get => (Vector2)CachedType.GetFieldValueOf(BaseObject, nameof(rangeMin));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(rangeMin), value);
        }
        
        // Direct Field
        public Vector2 rangeMax
        {
            get => (Vector2)CachedType.GetFieldValueOf(BaseObject, nameof(rangeMax));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(rangeMax), value);
        }
    }
}
