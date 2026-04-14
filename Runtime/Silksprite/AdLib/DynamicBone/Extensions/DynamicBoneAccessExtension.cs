using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.DynamicBone.Access;
using Silksprite.AdLib.Reflection.Extensions;
using UnityEngine;

namespace Silksprite.AdLib.DynamicBone.Extensions
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public static class DynamicBoneAccessExtension
    {
        public static bool TryGetDynamicBoneAccess(this Component component, [MaybeNullWhen(false)] out DynamicBoneAccess access)
        {
            return component.TryGetComponentAccess(DynamicBoneAccess.ActualType, c => new DynamicBoneAccess(c), out access);
        }
    }
}
