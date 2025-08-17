using System;

namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialFloatEnumAccess<T> : IMaterialPropertyAccess<T>
    where T : Enum
    {
        readonly UnityEngine.Material _material;
        readonly string _name;

        public MaterialFloatEnumAccess(UnityEngine.Material material, string name)
        {
            _material = material;
            _name = name;
        }

        T IMaterialPropertyAccess<T>.Value
        {
            get => (T)(object)(int)_material.GetFloat(_name);
            set => _material.SetFloat(_name, (int)(object)value);
        }
    }
}
