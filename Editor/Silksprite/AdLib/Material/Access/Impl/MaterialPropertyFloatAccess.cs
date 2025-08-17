using UnityEditor;

namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialPropertyFloatAccess : IMaterialPropertyAccess<float>
    {
        readonly MaterialProperty _property;

        public MaterialPropertyFloatAccess(MaterialProperty property)
        {
            _property = property;
        }

        float IMaterialPropertyAccess<float>.Value
        {
            get => _property.floatValue;
            set => _property.floatValue = value;
        }
    }
}
