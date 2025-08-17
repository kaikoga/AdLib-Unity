using System;
using UnityEngine;

namespace Silksprite.AdLib.Material.Access
{
    public interface IMaterialAccess
    {
        UnityEngine.Material Target { get; }
        UnityEngine.Material[] Targets { get; }

        IMaterialPropertyAccess<float> Float(string name);

        IMaterialPropertyAccess<bool> FloatBool(string name);
        IMaterialPropertyAccess<T> FloatEnum<T>(string name)
            where T : Enum;

        IMaterialPropertyAccess<Color> Color(string name);
        IMaterialTexturePropertyAccess<Texture2D> Texture2D(string name);
        IMaterialPropertyAccess<Vector4> Vector4(string name);

        IMaterialPropertyAccess<bool> Keyword(string keyword);
        IMaterialPropertyAccess<int> RenderQueue();
    }
}
