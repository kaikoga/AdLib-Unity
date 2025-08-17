using UnityEngine;

namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialVector4Access : IMaterialPropertyAccess<Vector4>
    {
        readonly UnityEngine.Material _material;
        readonly string _name;

        public MaterialVector4Access(UnityEngine.Material material, string name)
        {
            _material = material;
            _name = name;
        }

        Vector4 IMaterialPropertyAccess<Vector4>.Value
        {
            get => _material.GetVector(_name);
            set => _material.SetVector(_name, value);
        }
    }
}
