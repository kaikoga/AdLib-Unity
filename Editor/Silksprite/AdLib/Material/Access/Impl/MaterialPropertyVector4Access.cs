using UnityEditor;
using UnityEngine;

namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialPropertyVector4Access : IMaterialPropertyAccess<Vector4>
    {
        readonly MaterialProperty _property;

        public MaterialPropertyVector4Access(MaterialProperty property)
        {
            _property = property;
        }

        Vector4 IMaterialPropertyAccess<Vector4>.Value
        {
            get => _property.vectorValue;
            set => _property.vectorValue = value;
        }
    }
}
