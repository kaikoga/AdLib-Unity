namespace Silksprite.AdLib.Material.Access.Impl
{
    public class MaterialKeywordAccess : IMaterialPropertyAccess<bool>
    {
        readonly UnityEngine.Material _material;
        readonly string _keyword;

        public MaterialKeywordAccess(UnityEngine.Material material, string keyword)
        {
            _material = material;
            _keyword = keyword;
        }

        bool IMaterialPropertyAccess<bool>.Value
        {
            get => _material.IsKeywordEnabled(_keyword);
            set
            {
                if (value)
                {
                    _material.EnableKeyword(_keyword);
                }
                else
                {
                    _material.DisableKeyword(_keyword);
                }
            }
        }
    }
}
