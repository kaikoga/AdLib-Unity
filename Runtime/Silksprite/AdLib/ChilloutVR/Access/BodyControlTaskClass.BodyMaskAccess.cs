using System;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class BodyControlTaskClass
    {
        [ReflectionAccess("ABI.CCK.Components.BodyControlTask+BodyMask", "ABI.CCK.Components")]
        public class BodyMaskAccess : EnumAccessBase<BodyMaskAccess.EnumValues>
        {
            static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.BodyControlTask+BodyMask");
            public static Type ActualType => CachedType.ActualType;

            public static readonly BodyMaskAccess Shared = new BodyMaskAccess();
            BodyMaskAccess() : base(CachedType) { }

            public enum EnumValues
            {
                Head,
                Pelvis,
                LeftArm,
                RightArm,
                LeftLeg,
                RightLeg,
                Locomotion,
            }
        }
    }
}
