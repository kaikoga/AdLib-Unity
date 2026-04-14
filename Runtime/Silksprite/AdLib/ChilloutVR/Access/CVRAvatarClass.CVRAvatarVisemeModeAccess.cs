using System;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static partial class CVRAvatarClass
    {
        [ReflectionAccess("ABI.CCK.Components.CVRAvatar+CVRAvatarVisemeMode", "ABI.CCK.Components")]
        public class CVRAvatarVisemeModeAccess : EnumAccessBase<CVRAvatarVisemeModeAccess.EnumValues>
        {
            static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.CVRAvatar+CVRAvatarVisemeMode");
            public static Type ActualType => CachedType.ActualType;

            public static readonly CVRAvatarVisemeModeAccess Shared = new CVRAvatarVisemeModeAccess();
            CVRAvatarVisemeModeAccess() : base(CachedType) { }

            public enum EnumValues
            {
                Visemes = 0,
                SingleBlendshape = 1,
                JawBone = 2
            }
        }
    }
}
