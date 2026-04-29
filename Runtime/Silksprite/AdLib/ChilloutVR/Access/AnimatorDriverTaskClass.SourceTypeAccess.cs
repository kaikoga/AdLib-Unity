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
        [ReflectionAccess("ABI.CCK.Components.AnimatorDriverTask+SourceType", "Assembly-CSharp")]
        public class SourceTypeAccess : EnumAccessBase<SourceTypeAccess.EnumValues>
        {
            static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.AnimatorDriverTask+SourceType");
            public static Type ActualType => CachedType.ActualType;
            public static bool IsImplemented => CachedType.IsImplemented;
            
            public static readonly SourceTypeAccess Shared = new SourceTypeAccess();
            SourceTypeAccess() : base(CachedType) { }
            
            public enum EnumValues
            {
                Static = 0,
                Parameter = 1,
                Random = 2,
            }
        }
    }
}
