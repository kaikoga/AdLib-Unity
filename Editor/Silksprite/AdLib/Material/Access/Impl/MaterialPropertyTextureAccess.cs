using UnityEditor;
using UnityEngine;

namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialPropertyTextureAccess<T> : IMaterialPropertyAccess<T>
    where T : Texture
    {
        readonly MaterialProperty _property;

        public MaterialPropertyTextureAccess(MaterialProperty property)
        {
            _property = property;
        }

        T IMaterialPropertyAccess<T>.Value
        {
            get => _property.textureValue as T;
            set => _property.textureValue = value;
        }
    }
}
