using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    public static partial class BodyControlTaskClass
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        [ReflectionAccess("ABI.CCK.Components.BodyControlTask+BodyMask", "Assembly-CSharp")]
        public class BodyMaskAccess : EnumAccessBase<BodyMaskAccess.EnumValues>
        {
            static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.BodyControlTask+BodyMask");
            static CachedType CachedType___ => CachedType;
            public static Type ActualType => CachedType.ActualType;
            public static bool IsImplemented => CachedType.IsImplemented;
            
            public static readonly BodyMaskAccess Shared = new BodyMaskAccess();
            BodyMaskAccess() : base(CachedType) { }
            
            public enum EnumValues
            {
                Head = 0,
                Pelvis = 1,
                LeftArm = 2,
                RightArm = 3,
                LeftLeg = 4,
                RightLeg = 5,
                Locomotion = 6,
            }
        }
    }
}
