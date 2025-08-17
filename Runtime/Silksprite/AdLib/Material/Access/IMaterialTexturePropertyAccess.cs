using UnityEngine;

namespace Silksprite.AdLib.Material.Access
{
    public interface IMaterialTexturePropertyAccess<T> : IMaterialPropertyAccess<T>
    where T : Texture
    {
        Vector2 TextureScale { get; set; }
        Vector2 TextureOffset { get; set; }
    }
}
