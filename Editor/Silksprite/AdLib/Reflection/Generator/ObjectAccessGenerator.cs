using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using AdLib.Reflection.Extensions;
using AdLib.Reflection.Generator.Utils;
using Silksprite.AdLib.Reflection;

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
                    GenerateInstanceAccess(sb, member.FieldType, member.Name, MemberTypes.Field);
                }
                foreach (var member in ActualType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
                {
                    sb.AppendLine("");
                    GenerateInstanceAccess(sb, member.PropertyType, member.Name, MemberTypes.Property);
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

        void GenerateInstanceAccess(SourceCodeBuilder sb, Type actualMemberType, string fieldName, MemberTypes memberTypes)
        {
            string Getter()
            {
                var getMethod = memberTypes switch
                {
                    MemberTypes.Field => nameof(CachedType.GetFieldValueOf),
                    MemberTypes.Property => nameof(CachedType.GetPropertyValueOf),
                    _ => throw new NotSupportedException()
                };
                return $"CachedType.{getMethod}(BaseObject, nameof({fieldName}))";
            }
            string Setter(string value)
            {
                var setMethod = memberTypes switch
                {
                    MemberTypes.Field => nameof(CachedType.SetFieldValueOf),
                    MemberTypes.Property => nameof(CachedType.SetPropertyValueOf),
                    _ => throw new NotSupportedException()
                };
                return $"CachedType.{setMethod}(BaseObject, nameof({fieldName}), {value})";
            }

            if (TryGuessAccessValueType(actualMemberType, out _, out var accessClassName, out var accessValueTypeName, out var accessImplKind))
            {
                sb.AppendLine($"// {accessImplKind} {memberTypes}");
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
                    case AccessImplKind.Direct:
                        sb.AppendLine($"get => ({actualMemberType.GetPrettyTypeName()}){Getter()};");
                        sb.AppendLine($"set => {Setter("value")};");
                        break;
                    case AccessImplKind.Access:
                        sb.AppendLine($"get => {accessClassName}.Nullable({Getter()});");
                        sb.AppendLine($"set => {Setter("value?.BaseObject")};");
                        break;
                    case AccessImplKind.EnumAccess:
                        sb.AppendLine($"get => {accessClassName}.Shared.ToAccess({Getter()});");
                        sb.AppendLine($"set => {Setter($"{accessClassName}.Shared.ToActual(value)")};");
                        break;
                    case AccessImplKind.AccessList:
                        sb.AppendLine($"get => {Getter()}.ToAccessList({accessClassName}.Nullable);");
                        sb.AppendLine($"set => {Setter($"value?.ToDynamicList({accessClassName}.ActualType)")};");
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
            string Getter()
            {
                var getMethod = memberTypes switch
                {
                    MemberTypes.Field => nameof(CachedType.GetFieldValue),
                    MemberTypes.Property => nameof(CachedType.GetPropertyValue),
                    _ => throw new NotSupportedException()
                };
                return $"CachedType.{getMethod}(nameof({fieldName}))";
            }
            string Setter(string value)
            {
                var setMethod = memberTypes switch
                {
                    MemberTypes.Field => nameof(CachedType.SetFieldValue),
                    MemberTypes.Property => nameof(CachedType.SetPropertyValue),
                    _ => throw new NotSupportedException()
                };
                return $"CachedType.{setMethod}(nameof({fieldName}), {value})";
            }

            if (TryGuessAccessValueType(actualMemberType, out _, out var accessClassName, out var accessValueTypeName, out var accessImplKind))
            {
                sb.AppendLine($"// {accessImplKind} {memberTypes}");
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
                        sb.AppendLine($"get => ({actualMemberType.GetPrettyTypeName()}){Getter()};");
                        sb.AppendLine($"set => {Setter("value")};");
                        break;
                    case AccessImplKind.Access:
                        sb.AppendLine($"get => {accessClassName}.Nullable({Getter()});");
                        sb.AppendLine($"set => {Setter("value?.BaseObject")};");
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
            bool IsDirectAllowed(Type type)
            {
                return type.Assembly != ActualType.Assembly
                       && type.GenericTypeArguments.All(IsDirectAllowed);
            }

            if (actualMemberType.IsGenericType)
            {
                var genericBase = actualMemberType.GetGenericTypeDefinition();
                if (genericBase == typeof(List<>))
                {
                    var actualElementType = actualMemberType.GetGenericArguments()[0];
                    if (IsDirectAllowed(actualElementType))
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
                if (IsDirectAllowed(actualElementType))
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
            if (IsDirectAllowed(actualMemberType))
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
                if (typeof(Enum).IsAssignableFrom(maybeAccessInfo.ValueType))
                {
                    accessValueTypeName = maybeAccessInfo.ValueType.GetPrettyTypeName();
                    accessImplKind = AccessImplKind.EnumAccess;
                }
                else
                {
                    accessValueTypeName = maybeAccessInfo.ValueType.GetNullGuardedPrettyTypeName();
                    accessImplKind = AccessImplKind.Access;
                }
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
