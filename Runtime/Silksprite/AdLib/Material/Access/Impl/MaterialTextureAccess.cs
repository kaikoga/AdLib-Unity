using UnityEngine;

namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialTextureAccess<T> : IMaterialPropertyAccess<T>
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
    }
}
