using System;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Base;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class CVRAdvancedSettingsEntryClass
    {
        public class SettingsTypeAccess : EnumAccessBase<SettingsTypeAccess.EnumValues>
        {
            static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Scripts.CVRAdvancedSettingsEntry+SettingsType");
            public static Type ActualType => CachedType.ActualType;

            public static readonly SettingsTypeAccess Shared = new SettingsTypeAccess();
            SettingsTypeAccess() : base(CachedType) { }

            public enum EnumValues
            {
                Toggle,
                Dropdown,
                Color,
                Slider,
                Joystick2D,
                Joystick3D,
                InputSingle,
                InputVector2,
                InputVector3
            }
        }
    }
}
