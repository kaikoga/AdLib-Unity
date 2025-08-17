namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialFloatAccess : IMaterialPropertyAccess<float>
    {
        readonly UnityEngine.Material _material;
        readonly string _name;

        public MaterialFloatAccess(UnityEngine.Material material, string name)
        {
            _material = material;
            _name = name;
        }

        float IMaterialPropertyAccess<float>.Value
        {
            get => _material.GetFloat(_name);
            set => _material.SetFloat(_name, value);
        }
    }
}
