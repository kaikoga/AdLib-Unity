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
        public static Type ActualType => CachedType.ActualType;
        public static bool IsImplemented => CachedType.IsImplemented;
        
        public AnimatorDriverTaskAccess() : base(CachedType.CreateInstance()) { }
        public AnimatorDriverTaskAccess(object baseObject) : base(baseObject) { }
        public static AnimatorDriverTaskAccess? Nullable(object? baseObject) => baseObject != null ? new AnimatorDriverTaskAccess(baseObject) : null;
        
        // EnumAccess Field
        public AnimatorDriverTaskClass.ParameterTypeAccess.EnumValues targetType
        {
            get => AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToAccess(CachedType.GetFieldValueOf(BaseObject, nameof(targetType)));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(targetType), AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToActual(value));
        }
        
        // Direct Field
        public string? targetName
        {
            get => (string)CachedType.GetFieldValueOf(BaseObject, nameof(targetName));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(targetName), value);
        }
        
        // EnumAccess Field
        public AnimatorDriverTaskClass.OperatorAccess.EnumValues op
        {
            get => AnimatorDriverTaskClass.OperatorAccess.Shared.ToAccess(CachedType.GetFieldValueOf(BaseObject, nameof(op)));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(op), AnimatorDriverTaskClass.OperatorAccess.Shared.ToActual(value));
        }
        
        // EnumAccess Field
        public AnimatorDriverTaskClass.SourceTypeAccess.EnumValues aType
        {
            get => AnimatorDriverTaskClass.SourceTypeAccess.Shared.ToAccess(CachedType.GetFieldValueOf(BaseObject, nameof(aType)));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(aType), AnimatorDriverTaskClass.SourceTypeAccess.Shared.ToActual(value));
        }
        
        // Direct Field
        public float aValue
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(aValue));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(aValue), value);
        }
        
        // Direct Field
        public float aMax
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(aMax));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(aMax), value);
        }
        
        // EnumAccess Field
        public AnimatorDriverTaskClass.ParameterTypeAccess.EnumValues aParamType
        {
            get => AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToAccess(CachedType.GetFieldValueOf(BaseObject, nameof(aParamType)));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(aParamType), AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToActual(value));
        }
        
        // Direct Field
        public string? aName
        {
            get => (string)CachedType.GetFieldValueOf(BaseObject, nameof(aName));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(aName), value);
        }
        
        // EnumAccess Field
        public AnimatorDriverTaskClass.SourceTypeAccess.EnumValues bType
        {
            get => AnimatorDriverTaskClass.SourceTypeAccess.Shared.ToAccess(CachedType.GetFieldValueOf(BaseObject, nameof(bType)));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(bType), AnimatorDriverTaskClass.SourceTypeAccess.Shared.ToActual(value));
        }
        
        // Direct Field
        public float bValue
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(bValue));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(bValue), value);
        }
        
        // Direct Field
        public float bMax
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(bMax));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(bMax), value);
        }
        
        // EnumAccess Field
        public AnimatorDriverTaskClass.ParameterTypeAccess.EnumValues bParamType
        {
            get => AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToAccess(CachedType.GetFieldValueOf(BaseObject, nameof(bParamType)));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(bParamType), AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToActual(value));
        }
        
        // Direct Field
        public string? bName
        {
            get => (string)CachedType.GetFieldValueOf(BaseObject, nameof(bName));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(bName), value);
        }
        
        // EnumAccess Field
        public AnimatorDriverTaskClass.SourceTypeAccess.EnumValues cType
        {
            get => AnimatorDriverTaskClass.SourceTypeAccess.Shared.ToAccess(CachedType.GetFieldValueOf(BaseObject, nameof(cType)));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(cType), AnimatorDriverTaskClass.SourceTypeAccess.Shared.ToActual(value));
        }
        
        // Direct Field
        public float cValue
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(cValue));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(cValue), value);
        }
        
        // Direct Field
        public float cMax
        {
            get => (float)CachedType.GetFieldValueOf(BaseObject, nameof(cMax));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(cMax), value);
        }
        
        // EnumAccess Field
        public AnimatorDriverTaskClass.ParameterTypeAccess.EnumValues cParamType
        {
            get => AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToAccess(CachedType.GetFieldValueOf(BaseObject, nameof(cParamType)));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(cParamType), AnimatorDriverTaskClass.ParameterTypeAccess.Shared.ToActual(value));
        }
        
        // Direct Field
        public string? cName
        {
            get => (string)CachedType.GetFieldValueOf(BaseObject, nameof(cName));
            set => CachedType.SetFieldValueOf(BaseObject, nameof(cName), value);
        }
    }
}
