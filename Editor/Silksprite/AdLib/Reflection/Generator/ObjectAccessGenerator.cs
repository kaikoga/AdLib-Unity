using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using AdLib.Reflection.Extensions;
using AdLib.Reflection.Generator.Utils;

namespace AdLib.Reflection.Generator
{
    class ObjectAccessGenerator : ReflectionAccessGeneratorBase
    {
        readonly Type? _baseAccessClass;
        readonly Type? _baseObjectType;
        readonly AccessTypeInfo[] _accessTypesCache;

        public ObjectAccessGenerator(Type actualType, string accessNamespace, string accessClassName) : base(actualType, accessNamespace, accessClassName)
        {
            _accessTypesCache = TypeCollector.CollectAccessTypes().ToArray();

            if (ActualType.BaseType is { } baseType)
            {
                if (baseType.Assembly == ActualType.Assembly)
                {
                    _baseAccessClass = _accessTypesCache.FirstOrDefault(access => access.Actual == baseType)?.Access;
                }
                else
                {
                    _baseObjectType = baseType == typeof(object) ? null : baseType;
                }
            }
        }

        protected override IEnumerable<string> CollectUsings()
        {
            IEnumerable<Type> CollectNestedTypes(Type type)
            {
                yield return type;
                if (type.IsConstructedGenericType)
                {
                    foreach (var arg in type.GetGenericArguments().SelectMany(CollectNestedTypes))
                    {
                        yield return arg;
                    }
                }
            }
            IEnumerable<Type> CollectTypes()
            {
                if (_baseAccessClass != null)
                {
                    yield return _baseAccessClass;
                }
                if (_baseObjectType != null)
                {
                    yield return _baseObjectType;
                }
                foreach (var field in ActualType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
                {
                    yield return field.FieldType;
                }
                foreach (var property in ActualType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly))
                {
                    yield return property.PropertyType;
                }
            }
            IEnumerable<string?> DoCollectUsings()
            {
                foreach (var type in CollectTypes().SelectMany(CollectNestedTypes))
                {
                    if (TryGuessAccessValueType(type!, out var accessNs , out _, out _, out _))
                    {
                        yield return accessNs;
                    }
                }
            }
            foreach (var item in base.CollectUsings().Concat(DoCollectUsings()).Where(item => item != null))
            {
                yield return item!;
            }
        }

        protected override void GenerateType(SourceCodeBuilder sb, string accessClassIdent)
        {
            if (_baseAccessClass != null)
            {
                sb.AppendLine($"public class {accessClassIdent} : {_baseAccessClass.GetPrettyTypeName()}");
            }
            else if (_baseObjectType != null)
            {
                sb.AppendLine($"public class {accessClassIdent} : ObjectAccessBase<{_baseObjectType.GetPrettyTypeName()}>");
            }
            else
            {
                sb.AppendLine($"public class {accessClassIdent} : ObjectAccessBase<object>");
            }
            sb.AppendLine("{");
            using (sb.Indent())
            {
                GenerateCachedAndActualType(sb);
                sb.AppendLine("");
                sb.AppendLine($"public {accessClassIdent}() : base(CachedType.CreateInstance()) {{ }}");
                sb.AppendLine($"public {accessClassIdent}(object baseObject) : base(baseObject) {{ }}");
                sb.AppendLine($"public static {accessClassIdent}? Nullable(object? baseObject) => baseObject != null ? new {accessClassIdent}(baseObject) : null;");
                foreach (var member in ActualType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                {
                    sb.AppendLine("");
                    GenerateInstanceAccess(sb, member.FieldType, member.Name);
                }
                foreach (var member in ActualType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                {
                    sb.AppendLine("");
                    GenerateInstanceAccess(sb, member.PropertyType, member.Name);
                }
                foreach (var member in ActualType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly))
                {
                    sb.AppendLine("");
                    GenerateStaticAccess(sb, member.FieldType, member.Name, MemberTypes.Field);
                }
                foreach (var member in ActualType.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly))
                {
                    sb.AppendLine("");
                    GenerateStaticAccess(sb, member.PropertyType, member.Name, MemberTypes.Property);
                }
            }
            sb.AppendLine("}");
        }

        void GenerateInstanceAccess(SourceCodeBuilder sb, Type actualMemberType, string fieldName)
        {
            if (TryGuessAccessValueType(actualMemberType, out _, out var accessClassName, out var accessValueTypeName, out var accessImplKind))
            {
                sb.AppendLine($"public {accessValueTypeName} {fieldName}");
                sb.AppendLine("{");
                sb.AddIndent();
                switch (accessImplKind)
                {
                    case AccessImplKind.NotSupported:
                        throw new NotSupportedException();
                    case AccessImplKind.NotImplemented:
                        sb.AppendLine($"// {actualMemberType.GetPrettyTypeName()} {fieldName}");
                        break;
                    case AccessImplKind.Access:
                        sb.AppendLine($"get => {accessClassName}.Nullable(DynamicObject.{fieldName});");
                        sb.AppendLine($"set => DynamicObject.{fieldName} = value?.DynamicObject;");
                        break;
                    case AccessImplKind.EnumAccess:
                        sb.AppendLine($"get => {accessClassName}.Shared.ToAccess(DynamicObject.{fieldName});");
                        sb.AppendLine($"set => DynamicObject.{fieldName} = {accessClassName}.Shared.ToActual(value);");
                        break;
                    case AccessImplKind.AccessList:
                        sb.AppendLine($"get => ((object)DynamicObject.{fieldName}).ToAccessList({accessClassName}.Nullable);");
                        sb.AppendLine($"set => DynamicObject.{fieldName} = value?.ToDynamicList({accessClassName}.ActualType);");
                        break;
                    case AccessImplKind.Direct:
                        sb.AppendLine($"get => DynamicObject.{fieldName};");
                        sb.AppendLine($"set => DynamicObject.{fieldName} = value;");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                sb.SubIndent();
                sb.AppendLine("}");
            }
            else
            {
                sb.AppendLine($"// {actualMemberType.GetPrettyTypeName()} {fieldName}");
            }
        }

        void GenerateStaticAccess(SourceCodeBuilder sb, Type actualMemberType, string fieldName, MemberTypes memberTypes)
        {
            if (TryGuessAccessValueType(actualMemberType, out _, out var accessClassName, out var accessValueTypeName, out var accessImplKind))
            {
                sb.AppendLine($"public static {accessValueTypeName} {fieldName}");
                sb.AppendLine("{");
                sb.AddIndent();
                switch (accessImplKind)
                {
                    case AccessImplKind.NotSupported:
                        throw new NotSupportedException();
                    case AccessImplKind.NotImplemented:
                        sb.AppendLine($"// static {actualMemberType.GetPrettyTypeName()} {fieldName}");
                        break;
                    case AccessImplKind.Direct:
                        switch (memberTypes)
                        {
                            case MemberTypes.Field:
                                sb.AppendLine($"get => ({actualMemberType.GetPrettyTypeName()})CachedType.GetFieldValue(nameof({fieldName}));");
                                sb.AppendLine($"set => CachedType.SetFieldValue(nameof({fieldName}), value);");
                                break;
                            case MemberTypes.Property:
                                sb.AppendLine($"get => ({actualMemberType.GetPrettyTypeName()})CachedType.GetPropertyValue(nameof({fieldName}));");
                                sb.AppendLine($"set => CachedType.SetPropertyValue(nameof({fieldName}), value);");
                                break;
                            default:
                                throw new ArgumentException();
                        }
                        break;
                    case AccessImplKind.Access:
                        switch (memberTypes)
                        {
                            case MemberTypes.Field:
                                sb.AppendLine($"get => {accessClassName}.Nullable(CachedType.GetFieldValue(nameof({fieldName})));");
                                sb.AppendLine($"set => CachedType.SetFieldValue(nameof({fieldName}), value?.BaseObject);");
                                break;
                            case MemberTypes.Property:
                                sb.AppendLine($"get => {accessClassName}.Nullable(CachedType.GetPropertyValue(nameof({fieldName})));");
                                sb.AppendLine($"set => CachedType.SetPropertyValue(nameof({fieldName}), value?.BaseObject);");
                                break;
                            default:
                                throw new ArgumentException();
                        }
                        break;
                    case AccessImplKind.EnumAccess:
                    case AccessImplKind.AccessList:
                        sb.AppendLine("get;");
                        sb.AppendLine("set;");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                sb.SubIndent();
                sb.AppendLine("}");
            }
            else
            {
                sb.AppendLine($"// static {actualMemberType.GetPrettyTypeName()} {fieldName}");
            }
        }

        bool TryGuessAccessValueType(Type actualMemberType, [MaybeNullWhen(false)] out string accessClassNamespace, [MaybeNullWhen(false)] out string accessClassName, [MaybeNullWhen(false)] out string accessValueTypeName, out AccessImplKind accessImplKind)
        {
            if (actualMemberType.IsGenericType)
            {
                var genericBase = actualMemberType.GetGenericTypeDefinition();
                if (genericBase == typeof(List<>))
                {
                    var actualElementType = actualMemberType.GetGenericArguments()[0];
                    if (actualElementType.Assembly != ActualType.Assembly)
                    {
                        accessClassNamespace = actualMemberType.Namespace;
                        accessClassName = actualMemberType.GetPrettyTypeName();
                        accessValueTypeName = actualMemberType.GetNullGuardedPrettyTypeName();
                        accessImplKind = AccessImplKind.Direct;
                        return true;
                    }
                    var maybeElementAccessInfo = _accessTypesCache.FirstOrDefault(access => access.Actual == actualElementType);
                    if (maybeElementAccessInfo != null)
                    {
                        accessClassNamespace = maybeElementAccessInfo.Access.Namespace;
                        accessClassName = maybeElementAccessInfo.Access.GetPrettyTypeName();
                        accessValueTypeName = typeof(List<>).MakeGenericType(maybeElementAccessInfo.ValueType).GetNullGuardedPrettyTypeName();
                        accessImplKind = typeof(Enum).IsAssignableFrom(maybeElementAccessInfo.ValueType) ? AccessImplKind.NotImplemented : AccessImplKind.AccessList;
                        return true;
                    }
                }
            }
            else if (actualMemberType.IsArray)
            {
                var actualElementType = actualMemberType.GetElementType()!;
                if (actualElementType.Assembly != ActualType.Assembly)
                {
                    accessClassNamespace = actualMemberType.Namespace;
                    accessClassName = actualMemberType.GetPrettyTypeName();
                    accessValueTypeName = actualMemberType.GetNullGuardedPrettyTypeName();
                    accessImplKind = AccessImplKind.Direct;
                    return true;
                }
                var maybeElementAccessInfo = _accessTypesCache.FirstOrDefault(access => access.Actual == actualElementType);
                if (maybeElementAccessInfo != null)
                {
                    accessClassNamespace = maybeElementAccessInfo.Access.Namespace;
                    accessClassName = maybeElementAccessInfo.Access.GetPrettyTypeName();
                    accessValueTypeName = maybeElementAccessInfo.ValueType.MakeArrayType().GetNullGuardedPrettyTypeName();
                    accessImplKind = AccessImplKind.NotImplemented;
                    return true;
                }
            }
            if (actualMemberType.Assembly != ActualType.Assembly)
            {
                accessClassNamespace = actualMemberType.Namespace;
                accessClassName = actualMemberType.GetPrettyTypeName();
                accessValueTypeName = actualMemberType.GetNullGuardedPrettyTypeName();
                accessImplKind = AccessImplKind.Direct;
                return true;
            }
            var maybeAccessInfo = _accessTypesCache.FirstOrDefault(access => access.Actual == actualMemberType);
            if (maybeAccessInfo != null)
            {
                accessClassNamespace = maybeAccessInfo.Access.Namespace;
                accessClassName = maybeAccessInfo.Access.GetPrettyTypeName();
                accessValueTypeName = maybeAccessInfo.ValueType.GetNullGuardedPrettyTypeName();
                accessImplKind = typeof(Enum).IsAssignableFrom(maybeAccessInfo.ValueType) ? AccessImplKind.EnumAccess : AccessImplKind.Access;
                return true;
            }
            accessClassNamespace = null;
            accessClassName = null;
            accessValueTypeName = null;
            accessImplKind = AccessImplKind.NotSupported;
            return false;
        }
        
        enum AccessImplKind
        {
            NotSupported,
            NotImplemented,
            Direct,
            Access,
            EnumAccess,
            AccessList,
        }
    }
}
