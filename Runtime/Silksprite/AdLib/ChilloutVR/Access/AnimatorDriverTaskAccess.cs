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
    [ReflectionAccess("ABI.CCK.Components.AnimatorDriverTask", "Assembly-CSharp")]
    public class AnimatorDriverTaskAccess : ObjectAccessBase<object>
    {
        static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType("ABI.CCK.Components.AnimatorDriverTask");
        static CachedType CachedType___ => CachedType;
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public AnimatorDriverTaskAccess() : base(CachedType.CreateInstance()) { }
        public AnimatorDriverTaskAccess(object baseObject) : base(baseObject) { }
        public static AnimatorDriverTaskAccess? Nullable(object? baseObject) => baseObject != null ? new AnimatorDriverTaskAccess(baseObject) : null;
        
        // EnumAccess Field
        public AnimatorDriverTaskClass.ParameterTypeAccess.EnumValues targetType
        {
            get => AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToAccess(CachedType___.GetFieldValueOf(BaseObject, nameof(targetType)));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(targetType), AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToActual(value));
        }
        
        // Direct Field
        public string? targetName
        {
            get => (string)CachedType___.GetFieldValueOf(BaseObject, nameof(targetName));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(targetName), value);
        }
        
        // EnumAccess Field
        public AnimatorDriverTaskClass.OperatorAccess.EnumValues op
        {
            get => AnimatorDriverTaskClass.OperatorAccess.Shared.ToAccess(CachedType___.GetFieldValueOf(BaseObject, nameof(op)));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(op), AnimatorDriverTaskClass.OperatorAccess.Shared.ToActual(value));
        }
        
        // EnumAccess Field
        public AnimatorDriverTaskClass.SourceTypeAccess.EnumValues aType
        {
            get => AnimatorDriverTaskClass.SourceTypeAccess.Shared.ToAccess(CachedType___.GetFieldValueOf(BaseObject, nameof(aType)));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(aType), AnimatorDriverTaskClass.SourceTypeAccess.Shared.ToActual(value));
        }
        
        // Direct Field
        public float aValue
        {
            get => (float)CachedType___.GetFieldValueOf(BaseObject, nameof(aValue));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(aValue), value);
        }
        
        // Direct Field
        public float aMax
        {
            get => (float)CachedType___.GetFieldValueOf(BaseObject, nameof(aMax));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(aMax), value);
        }
        
        // EnumAccess Field
        public AnimatorDriverTaskClass.ParameterTypeAccess.EnumValues aParamType
        {
            get => AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToAccess(CachedType___.GetFieldValueOf(BaseObject, nameof(aParamType)));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(aParamType), AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToActual(value));
        }
        
        // Direct Field
        public string? aName
        {
            get => (string)CachedType___.GetFieldValueOf(BaseObject, nameof(aName));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(aName), value);
        }
        
        // EnumAccess Field
        public AnimatorDriverTaskClass.SourceTypeAccess.EnumValues bType
        {
            get => AnimatorDriverTaskClass.SourceTypeAccess.Shared.ToAccess(CachedType___.GetFieldValueOf(BaseObject, nameof(bType)));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(bType), AnimatorDriverTaskClass.SourceTypeAccess.Shared.ToActual(value));
        }
        
        // Direct Field
        public float bValue
        {
            get => (float)CachedType___.GetFieldValueOf(BaseObject, nameof(bValue));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(bValue), value);
        }
        
        // Direct Field
        public float bMax
        {
            get => (float)CachedType___.GetFieldValueOf(BaseObject, nameof(bMax));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(bMax), value);
        }
        
        // EnumAccess Field
        public AnimatorDriverTaskClass.ParameterTypeAccess.EnumValues bParamType
        {
            get => AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToAccess(CachedType___.GetFieldValueOf(BaseObject, nameof(bParamType)));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(bParamType), AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToActual(value));
        }
        
        // Direct Field
        public string? bName
        {
            get => (string)CachedType___.GetFieldValueOf(BaseObject, nameof(bName));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(bName), value);
        }
        
        // EnumAccess Field
        public AnimatorDriverTaskClass.SourceTypeAccess.EnumValues cType
        {
            get => AnimatorDriverTaskClass.SourceTypeAccess.Shared.ToAccess(CachedType___.GetFieldValueOf(BaseObject, nameof(cType)));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(cType), AnimatorDriverTaskClass.SourceTypeAccess.Shared.ToActual(value));
        }
        
        // Direct Field
        public float cValue
        {
            get => (float)CachedType___.GetFieldValueOf(BaseObject, nameof(cValue));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(cValue), value);
        }
        
        // Direct Field
        public float cMax
        {
            get => (float)CachedType___.GetFieldValueOf(BaseObject, nameof(cMax));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(cMax), value);
        }
        
        // EnumAccess Field
        public AnimatorDriverTaskClass.ParameterTypeAccess.EnumValues cParamType
        {
            get => AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToAccess(CachedType___.GetFieldValueOf(BaseObject, nameof(cParamType)));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(cParamType), AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToActual(value));
        }
        
        // Direct Field
        public string? cName
        {
            get => (string)CachedType___.GetFieldValueOf(BaseObject, nameof(cName));
            set => CachedType___.SetFieldValueOf(BaseObject, nameof(cName), value);
        }
    }
}
