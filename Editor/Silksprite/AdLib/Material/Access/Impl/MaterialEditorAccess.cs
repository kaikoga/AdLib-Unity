using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialEditorAccess : IMaterialAccess
    {
        readonly MaterialProperty[] _properties;
        readonly Object[] _targets;

        public MaterialEditorAccess(MaterialProperty[] properties, Object[] targets)
        {
            _properties = properties;
            _targets = targets;
        }

        MaterialProperty FindProperty(string name) => _properties.FirstOrDefault(property => property.name == name);

        UnityEngine.Material IMaterialAccess.Target => ((IMaterialAccess)this).Targets.FirstOrDefault();
        UnityEngine.Material[] IMaterialAccess.Targets => _targets.OfType<UnityEngine.Material>().ToArray();

        IMaterialPropertyAccess<float> IMaterialAccess.Float(string name) => new MaterialPropertyFloatAccess(FindProperty(name));

        IMaterialPropertyAccess<bool> IMaterialAccess.FloatBool(string name) => new MaterialPropertyFloatBoolAccess(FindProperty(name));
        IMaterialPropertyAccess<T> IMaterialAccess.FloatEnum<T>(string name) => new MaterialPropertyFloatEnumAccess<T>(FindProperty(name));

        IMaterialPropertyAccess<Color> IMaterialAccess.Color(string name) => new MaterialPropertyColorAccess(FindProperty(name));
        IMaterialTexturePropertyAccess<Texture2D> IMaterialAccess.Texture2D(string name) => new MaterialPropertyTextureAccess<Texture2D>(FindProperty(name));
        IMaterialPropertyAccess<Vector4> IMaterialAccess.Vector4(string name) => new MaterialPropertyVector4Access(FindProperty(name));

        public IMaterialPropertyAccess<bool> Keyword(string keyword) => new MaterialTargetsKeywordAccess(_targets, keyword);
        public IMaterialPropertyAccess<int> RenderQueue() => new MaterialTargetsRenderQueueAccess(_targets);
    }
    
    public static class MaterialEditorAccessFactoryExtension
    {
        public static IMaterialAccess ToMaterialAccess(this MaterialEditor materialEditor) => new MaterialEditorAccess(MaterialEditor.GetMaterialProperties(materialEditor.targets), materialEditor.targets);
        public static IMaterialAccess ToMaterialAccess(this MaterialProperty[] properties, Object[] targets) => new MaterialEditorAccess(properties, targets);
    }
}
