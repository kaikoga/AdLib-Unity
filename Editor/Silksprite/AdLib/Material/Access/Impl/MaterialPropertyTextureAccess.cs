using System;
using UnityEditor;
using UnityEngine;

namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialPropertyTextureAccess<T> : IMaterialTexturePropertyAccess<T>
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

        Vector2 IMaterialTexturePropertyAccess<T>.TextureScale
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        Vector2 IMaterialTexturePropertyAccess<T>.TextureOffset
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}
