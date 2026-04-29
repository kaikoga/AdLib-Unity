using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    public static partial class CVRAdvancedSettingsEntryClass
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        [ReflectionAccess("ABI.CCK.Scripts.CVRAdvancedSettingsEntry+SettingsType", "Assembly-CSharp")]
        public class SettingsTypeAccess : EnumAccessBase<SettingsTypeAccess.EnumValues>
        {
            static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancedSettingsEntry+SettingsType");
            public static Type ActualType => CachedType.ActualType;
            public static bool IsImplemented => CachedType.IsImplemented;
            
            public static readonly SettingsTypeAccess Shared = new SettingsTypeAccess();
            SettingsTypeAccess() : base(CachedType) { }
            
            public enum EnumValues
            {
                Toggle = 0,
                Dropdown = 1,
                Color = 2,
                Slider = 3,
                Joystick2D = 4,
                Joystick3D = 5,
                InputSingle = 6,
                InputVector2 = 7,
                InputVector3 = 8,
            }
        }
    }
}
