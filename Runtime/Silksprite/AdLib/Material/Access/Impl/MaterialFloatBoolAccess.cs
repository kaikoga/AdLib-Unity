namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialFloatBoolAccess : IMaterialPropertyAccess<bool>
    {
        readonly UnityEngine.Material _material;
        readonly string _name;

        public MaterialFloatBoolAccess(UnityEngine.Material material, string name)
        {
            _material = material;
            _name = name;
        }

        bool IMaterialPropertyAccess<bool>.Value
        {
            get => _material.GetFloat(_name) != 0.0f;
            set => _material.SetFloat(_name, value ? 1.0f : 0.0f);
        }
    }
}
