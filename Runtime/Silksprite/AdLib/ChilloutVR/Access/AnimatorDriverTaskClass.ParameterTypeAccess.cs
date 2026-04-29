using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    public static partial class AnimatorDriverTaskClass
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        [ReflectionAccess("ABI.CCK.Components.AnimatorDriverTask+ParameterType", "Assembly-CSharp")]
        public class ParameterTypeAccess : EnumAccessBase<ParameterTypeAccess.EnumValues>
        {
            static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.AnimatorDriverTask+ParameterType");
            static CachedType CachedType___ => CachedType;
            public static Type ActualType => CachedType.ActualType;
            public static bool IsImplemented => CachedType.IsImplemented;
            
            public static readonly ParameterTypeAccess Shared = new ParameterTypeAccess();
            ParameterTypeAccess() : base(CachedType) { }
            
            public enum EnumValues
            {
                None = 0,
                Float = 1,
                Int = 2,
                Bool = 3,
                Trigger = 4,
            }
        }
    }
}
