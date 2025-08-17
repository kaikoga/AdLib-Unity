using UnityEngine;

namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialAccess : IMaterialAccess
    {
        readonly UnityEngine.Material _material;

        public MaterialAccess(UnityEngine.Material material) => _material = material;

        UnityEngine.Material IMaterialAccess.Target => _material;
        UnityEngine.Material[] IMaterialAccess.Targets => new [] { _material };

        IMaterialPropertyAccess<float> IMaterialAccess.Float(string name) => new MaterialFloatAccess(_material, name);

        IMaterialPropertyAccess<bool> IMaterialAccess.FloatBool(string name) => new MaterialFloatBoolAccess(_material, name);
        IMaterialPropertyAccess<T> IMaterialAccess.FloatEnum<T>(string name) => new MaterialFloatEnumAccess<T>(_material, name);

        IMaterialPropertyAccess<Color> IMaterialAccess.Color(string name) => new MaterialColorAccess(_material, name);
        IMaterialTexturePropertyAccess<Texture2D> IMaterialAccess.Texture2D(string name) => new MaterialTextureAccess<Texture2D>(_material, name);
        IMaterialPropertyAccess<Vector4> IMaterialAccess.Vector4(string name) => new MaterialVector4Access(_material, name);
        
        public IMaterialPropertyAccess<bool> Keyword(string keyword) => new MaterialKeywordAccess(_material, keyword);
        public IMaterialPropertyAccess<int> RenderQueue() => new MaterialRenderQueueAccess(_material);
    }

    public static class MaterialAccessFactoryExtension
    {
        public static IMaterialAccess ToMaterialAccess(this UnityEngine.Material material) => new MaterialAccess(material);
    }
}
