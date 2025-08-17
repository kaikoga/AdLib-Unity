using System;
using UnityEngine;

namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialTextureAccess<T> : IMaterialTexturePropertyAccess<T>
    where T : Texture
    {
        readonly UnityEngine.Material _material;
        readonly string _name;

        public MaterialTextureAccess(UnityEngine.Material material, string name)
        {
            _material = material;
            _name = name;
        }

        T IMaterialPropertyAccess<T>.Value
        {
            get => _material.GetTexture(_name) as T;
            set => _material.SetTexture(_name, value);
        }

        Vector2 IMaterialTexturePropertyAccess<T>.TextureScale
        {
            get => _material.GetTextureScale(_name);
            set => _material.SetTextureScale(_name, value);
        }

        Vector2 IMaterialTexturePropertyAccess<T>.TextureOffset
        {
            get => _material.GetTextureOffset(_name);
            set => _material.SetTextureOffset(_name, value);
        }
    }
}
