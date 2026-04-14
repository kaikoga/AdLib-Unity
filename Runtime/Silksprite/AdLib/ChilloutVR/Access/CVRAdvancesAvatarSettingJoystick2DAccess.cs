using System;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using UnityEngine;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class CVRAdvancesAvatarSettingJoystick2DAccess : CVRAdvancesAvatarSettingBaseAccess
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancesAvatarSettingJoystick2D");
        public new static Type ActualType => CachedType.ActualType;

        public CVRAdvancesAvatarSettingJoystick2DAccess() : base(CachedType.CreateInstance()) { }
        public CVRAdvancesAvatarSettingJoystick2DAccess(object baseObject) : base(baseObject) { }

        public Vector2 defaultValue
        {
            get => DynamicObject.defaultValue;
            set => DynamicObject.defaultValue = value;
        }

        public Vector2 rangeMin
        {
            get => DynamicObject.rangeMin;
            set => DynamicObject.rangeMin = value;
        }

        public Vector2 rangeMax
        {
            get => DynamicObject.rangeMax;
            set => DynamicObject.rangeMax = value;
        }
    }
}
