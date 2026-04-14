using System;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Base;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class AnimatorDriverTaskClass
    {
        public class SourceTypeAccess : EnumAccessBase<SourceTypeAccess.EnumValues>
        {
            static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.AnimatorDriverTask+SourceType");
            public static Type ActualType => CachedType.ActualType;

            public static readonly SourceTypeAccess Shared = new SourceTypeAccess();
            SourceTypeAccess() : base(CachedType) { }

            public enum EnumValues
            {
                Static,
                Parameter,
                Random
            }
        }
    }
}
