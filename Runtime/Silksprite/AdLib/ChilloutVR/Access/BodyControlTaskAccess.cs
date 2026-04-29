using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Attributes;
using Silksprite.AdLib.Reflection.Base;
using Silksprite.AdLib.Reflection.Extensions;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [ReflectionAccess("ABI.CCK.Components.BodyControlTask", "Assembly-CSharp")]
    public class BodyControlTaskAccess : ObjectAccessBase<object>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.BodyControlTask");
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public BodyControlTaskAccess() : base(CachedType.CreateInstance()) { }
        public BodyControlTaskAccess(object baseObject) : base(baseObject) { }
        public static BodyControlTaskAccess? Nullable(object? baseObject) => baseObject != null ? new BodyControlTaskAccess(baseObject) : null;
        
        // EnumAccess Field
        public BodyControlTaskClass.BodyMaskAccess.EnumValues target
        {
            get => BodyControlTaskClass.BodyMaskAccess.Shared.ToAccess(CachedType.GetFieldValueOf(BaseObject, nameof(target)));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(target), BodyControlTaskClass.BodyMaskAccess.Shared.ToActual(value));
        }
        
        // Direct Field
        public float targetWeight
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(targetWeight));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(targetWeight), value);
        }
        
        // Direct Field
        public float transitionDuration
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(transitionDuration));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(transitionDuration), value);
        }
        
        // Direct Field
        public bool isBlend
        {
            get => (bool)CachedType.GetFieldValueOf(BaseObject, nameof(isBlend));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(isBlend), value);
        }
    }
}
