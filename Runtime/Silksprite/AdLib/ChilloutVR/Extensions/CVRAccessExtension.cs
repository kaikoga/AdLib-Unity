using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.ChilloutVR.Access;
using Silksprite.AdLib.Reflection.Extensions;
using UnityEngine;

namespace Silksprite.AdLib.ChilloutVR.Extensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class CVRAccessExtension
    {
        public static bool TryGetCVRAvatarAccess(this Component component, [MaybeNullWhen(false)] out CVRAvatarAccess access)
        {
            return component.TryGetComponentAccess(CVRAvatarAccess.ActualType, c => new CVRAvatarAccess(c), out access);
        }
    }
}