using UnityEngine;

namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialAccess : IMaterialAccess
    {
        readonly UnityEngine.Material _material;

        public MaterialAccess(UnityEngine.Material material) => _material = material;

        IMaterialPropertyAccess<float> IMaterialAccess.Float(string name) => new MaterialFloatAccess(_material, name);

        IMaterialPropertyAccess<bool> IMaterialAccess.FloatBool(string name) => new MaterialFloatBoolAccess(_material, name);
        IMaterialPropertyAccess<T> IMaterialAccess.FloatEnum<T>(string name) => new MaterialFloatEnumAccess<T>(_material, name);

        IMaterialPropertyAccess<Color> IMaterialAccess.Color(string name) => new MaterialColorAccess(_material, name);
        IMaterialPropertyAccess<Texture2D> IMaterialAccess.Texture2D(string name) => new MaterialTextureAccess<Texture2D>(_material, name);
    }

    public static class MaterialAccessFactoryExtension
    {
        public static IMaterialAccess ToMaterialAccess(this UnityEngine.Material material) => new MaterialAccess(material);
    }
}
