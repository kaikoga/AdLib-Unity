using UnityEditor;

namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialPropertyFloatBoolAccess : IMaterialPropertyAccess<bool>
    {
        readonly MaterialProperty _property;

        public MaterialPropertyFloatBoolAccess(MaterialProperty property)
        {
            _property = property;
        }

        bool IMaterialPropertyAccess<bool>.Value
        {
            get => _property.floatValue != 0.0f;
            set => _property.floatValue = value ? 1.0f : 0.0f;
        }
    }
}
