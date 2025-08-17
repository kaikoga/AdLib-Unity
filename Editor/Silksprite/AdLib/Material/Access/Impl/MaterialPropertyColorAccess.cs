using UnityEditor;
using UnityEngine;

namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialPropertyColorAccess : IMaterialPropertyAccess<Color>
    {
        readonly MaterialProperty _property;

        public MaterialPropertyColorAccess(MaterialProperty property)
        {
            _property = property;
        }

        Color IMaterialPropertyAccess<Color>.Value
        {
            get => _property.colorValue;
            set => _property.colorValue = value;
        }
    }
}
