using System;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Base;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class AnimatorDriverTaskClass
    {
        public class ParameterTypeAccess : EnumAccessBase<ParameterTypeAccess.EnumValues>
        {
            static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.AnimatorDriverTask+ParameterType");
            public static Type ActualType => CachedType.ActualType;

            public static readonly ParameterTypeAccess Shared = new ParameterTypeAccess();
            ParameterTypeAccess() : base(CachedType) { }

            public enum EnumValues
            {
                None,
                Float,
                Int,
                Bool,
                Trigger
            }
        }
    }
}
