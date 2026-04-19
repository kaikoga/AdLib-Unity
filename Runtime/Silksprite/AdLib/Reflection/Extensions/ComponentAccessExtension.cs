using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UnityEngine;

namespace Silksprite.AdLib.Reflection.Extensions
{
    static class ComponentAccessExtension
    {
        public static bool TryGetComponentAccess<T>(this Component component, Type? type, Func<Component, T> toAccess, [MaybeNullWhen(false)] out T access)
        {
            if (type == null)
            {
                access = default;
                return false;
            }
            access = component.GetComponents<Component>()
                .Where(c => c != null && c.GetType() == type)
                .Select(toAccess)
                .FirstOrDefault();
            return access != null;
        }
    }
}