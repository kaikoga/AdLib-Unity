using System;
using UnityEditor;

namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialPropertyFloatEnumAccess<T> : IMaterialPropertyAccess<T>
    where T : Enum
    {
        readonly MaterialProperty _property;

        public MaterialPropertyFloatEnumAccess(MaterialProperty property)
        {
            _property = property;
        }

        T IMaterialPropertyAccess<T>.Value
        {
            get => (T)(object)(int)_property.floatValue;
            set => _property.floatValue = (int)(object)value;
        }
    }
}
