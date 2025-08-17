using UnityEngine;

namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialColorAccess : IMaterialPropertyAccess<Color>
    {
        readonly UnityEngine.Material _material;
        readonly string _name;

        public MaterialColorAccess(UnityEngine.Material material, string name)
        {
            _material = material;
            _name = name;
        }

        Color IMaterialPropertyAccess<Color>.Value
        {
            get => _material.GetColor(_name);
            set => _material.SetColor(_name, value);
        }
    }
}
