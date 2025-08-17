using System;
using UnityEngine;

namespace Silksprite.AdLib.Material.Access
{
    public interface IMaterialAccess
    {
        IMaterialPropertyAccess<float> Float(string name);

        IMaterialPropertyAccess<bool> FloatBool(string name);
        IMaterialPropertyAccess<T> FloatEnum<T>(string name)
            where T : Enum;

        IMaterialPropertyAccess<Color> Color(string name);
        IMaterialPropertyAccess<Texture2D> Texture2D(string name);
    }
}
