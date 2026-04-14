using System;
using System.Diagnostics.CodeAnalysis;
using Silksprite.AdLib.Reflection;
using Silksprite.AdLib.Reflection.Base;

namespace Silksprite.AdLib.ChilloutVR.Access
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class AnimatorDriverTaskAccess : ObjectAccessBase<object>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.AnimatorDriverTask");
        public static Type ActualType => CachedType.ActualType;

        public AnimatorDriverTaskAccess() : base(CachedType.CreateInstance()) { }
        public AnimatorDriverTaskAccess(object baseObject) : base(baseObject) { }
        public static AnimatorDriverTaskAccess? Nullable(object? baseObject) => baseObject != null ? new AnimatorDriverTaskAccess(baseObject) : null;

        public AnimatorDriverTaskClass.ParameterTypeAccess.EnumValues targetType
        {
            get => AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToAccess(DynamicObject.targetType);
            set => DynamicObject.targetType = AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToActual(value);
        }

        public string targetName
        {
            get => DynamicObject.targetName;
            set => DynamicObject.targetName = value;
        }

        public AnimatorDriverTaskClass.OperatorAccess.EnumValues op
        {
            get => AnimatorDriverTaskClass.OperatorAccess.Shared.ToAccess(DynamicObject.op);
            set => DynamicObject.op = AnimatorDriverTaskClass.OperatorAccess.Shared.ToActual(value);
        }
        
        public AnimatorDriverTaskClass.SourceTypeAccess.EnumValues aType
        {
            get => AnimatorDriverTaskClass.SourceTypeAccess.Shared.ToAccess(DynamicObject.aType);
            set => DynamicObject.aType = AnimatorDriverTaskClass.SourceTypeAccess.Shared.ToActual(value);
        }

        public float aValue
        {
            get => DynamicObject.aValue;
            set => DynamicObject.aValue = value;
        }

        public float aMax
        {
            get => DynamicObject.aMax;
            set => DynamicObject.aMax = value;
        }

        public AnimatorDriverTaskClass.ParameterTypeAccess.EnumValues aParamType
        {
            get => AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToAccess(DynamicObject.aParamType);
            set => DynamicObject.aParamType = AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToActual(value);
        }

        public string aName
        {
            get => DynamicObject.aName;
            set => DynamicObject.aName = value;
        }
    }
}
