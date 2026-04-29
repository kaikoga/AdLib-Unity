using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    public static partial class CVRAvatarClass
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        [ReflectionAccess("ABI.CCK.Components.CVRAvatar+CVRAvatarVisemeMode", "Assembly-CSharp")]
        public class CVRAvatarVisemeModeAccess : EnumAccessBase<CVRAvatarVisemeModeAccess.EnumValues>
        {
            static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.CVRAvatar+CVRAvatarVisemeMode");
            public static Type ActualType => CachedType.ActualType;
            public static bool IsImplemented => CachedType.IsImplemented;
            
            public static readonly CVRAvatarVisemeModeAccess Shared = new CVRAvatarVisemeModeAccess();
            CVRAvatarVisemeModeAccess() : base(CachedType) { }
            
            public enum EnumValues
            {
                Visemes = 0,
                SingleBlendshape = 1,
                JawBone = 2,
            }
        }
    }
}
