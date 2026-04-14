using System;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ReflectionAccess("ABI.CCK.Components.BodyControlTask", "ABI.CCK.Components")]
    public class BodyControlTaskAccess : ObjectAccessBase<object>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.BodyControlTask");
        public static Type ActualType => CachedType.ActualType;

        public BodyControlTaskAccess() : base(CachedType.CreateInstance()) { }
        public BodyControlTaskAccess(object baseObject) : base(baseObject) { }
        public static BodyControlTaskAccess? Nullable(object? baseObject) => baseObject != null ? new BodyControlTaskAccess(baseObject) : null;

        public BodyControlTaskClass.BodyMaskAccess.EnumValues target
        {
            get => BodyControlTaskClass.BodyMaskAccess.Shared.ToAccess(DynamicObject.target);
            set => DynamicObject.target = BodyControlTaskClass.BodyMaskAccess.Shared.ToActual(value);
        }

        public float targetWeight
        {
            get => DynamicObject.targetWeight;
            set => DynamicObject.targetWeight = value;
        }
    }
}
