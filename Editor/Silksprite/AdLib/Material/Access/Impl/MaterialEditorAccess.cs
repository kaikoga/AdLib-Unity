using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialEditorAccess : IMaterialAccess
    {
        readonly MaterialProperty[] _properties;

        public MaterialEditorAccess(MaterialProperty[] properties) => _properties = properties;

        MaterialProperty FindProperty(string name) => _properties.FirstOrDefault(property => property.name == name);

        IMaterialPropertyAccess<float> IMaterialAccess.Float(string name) => new MaterialPropertyFloatAccess(FindProperty(name));

        IMaterialPropertyAccess<bool> IMaterialAccess.FloatBool(string name) => new MaterialPropertyFloatBoolAccess(FindProperty(name));
        IMaterialPropertyAccess<T> IMaterialAccess.FloatEnum<T>(string name) => new MaterialPropertyFloatEnumAccess<T>(FindProperty(name));

        IMaterialPropertyAccess<Color> IMaterialAccess.Color(string name) => new MaterialPropertyColorAccess(FindProperty(name));
        IMaterialPropertyAccess<Texture2D> IMaterialAccess.Texture2D(string name) => new MaterialPropertyTextureAccess<Texture2D>(FindProperty(name));
    }
    
    public static class MaterialEditorAccessFactoryExtension
    {
        public static IMaterialAccess ToMaterialAccess(this MaterialProperty[] properties) => new MaterialEditorAccess(properties);
    }
}
