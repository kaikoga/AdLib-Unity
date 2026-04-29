using System;
using System.Linq;

namespace AdLib.Reflection.Extensions
{
    static class TypeExtension
    {
        public static string GetNestedTypeName(this Type type) => type.GetNestedTypeName(false, false);

        static string GetNestedTypeName(this Type type, bool fullName, bool isNullGuarded)
        {
            var nestedTypePath = type.GetNestedTypePath(fullName, isNullGuarded);
            return isNullGuarded && !type.IsValueType ? $"{nestedTypePath}?" : nestedTypePath;
        }

        static string GetNestedTypePath(this Type type, bool fullName, bool isNullGuarded)
        {
            if (type.IsArray)
            {
                var arrayElementDef = type.GetElementType()!.GetPrettyTypeName(fullName, isNullGuarded);
                var arrayRank = string.Join(",", Enumerable.Repeat("", type.GetArrayRank()));
                return $"{arrayElementDef}[{arrayRank}]";
            }
            if (type is { IsGenericType: true, IsGenericTypeDefinition: false })
            {
                var genericDefType = type.GetGenericTypeDefinition();
                if (genericDefType == typeof(Nullable<>))
                {
                    return $"{type.GetGenericArguments()[0].GetPrettyTypePath(fullName, isNullGuarded)}?";
                }
                var genericDef = genericDefType.GetPrettyTypePath(fullName, isNullGuarded);
                var genericArgs = string.Join(",", type.GetGenericArguments().Select(arg => arg.GetPrettyTypeName(fullName, isNullGuarded)));
                return $"{genericDef}<{genericArgs}>";
            }
            var rawTypeName = (fullName ? type.FullName : type.Name) ?? "anonymous";
            var typePath = rawTypeName.Split("`")[0] ?? "anonymous";
            return type.DeclaringType is { } decl ? $"{decl.GetPrettyTypePath(fullName, isNullGuarded)}.{typePath}" : typePath;
        }

        public static string GetPrettyTypeName(this Type type) => type.GetPrettyTypeName(false, false);
        public static string GetNullGuardedPrettyTypeName(this Type type) => type.GetPrettyTypeName(false, true);

        static string? MaybeGetPrettyTypePath(this Type type) =>
            type.FullName switch
            {
                "System.Boolean" => "bool",
                "System.Byte" => "byte",
                "System.SByte" => "sbyte",
                "System.Char" => "char",
                "System.Int16" => "short",
                "System.Int32" => "int",
                "System.Int64" => "long",
                "System.Single" => "float",
                "System.Double" => "double",
                "System.Decimal" => "decimal",
                "System.Void" => "void",
                "System.Object" => "object",
                "System.String" => "string",
                _ => null
            };

        static string GetPrettyTypePath(this Type type, bool fullName, bool isNullGuarded)
        {
            return type.MaybeGetPrettyTypePath() switch
            {
                { } prettyName => prettyName,
                null => type.GetNestedTypePath(fullName, isNullGuarded)
            };
        }

        static string GetPrettyTypeName(this Type type, bool fullName, bool isNullGuarded)
        {
            return type.MaybeGetPrettyTypePath() switch
            {
                "object" => isNullGuarded ? "object?" : "object",
                "string" => isNullGuarded ? "string?" : "string",
                { } prettyName => prettyName,
                null => type.GetNestedTypeName(fullName, isNullGuarded)
            };
        }
    }
}
