using System;
using System.Linq;

namespace AdLib.Reflection.Extensions
{
    static class TypeExtension
    {
        public static Type ToNullable(this Type type)
        {
            return typeof(Nullable<>).MakeGenericType(type); 
        }

        public static string GetNestedTypeName(this Type type)
        {
            if (type.IsArray)
            {
                var arrayElementDef = type.GetElementType()!.GetNestedTypeName();
                var arrayRank = string.Join(",", Enumerable.Repeat("", type.GetArrayRank()));
                return $"{arrayElementDef}[{arrayRank}]";
            }
            if (type is { IsGenericType: true, IsGenericTypeDefinition: false })
            {
                var genericDef = type.GetGenericTypeDefinition().GetNestedTypeName();
                var genericArgs = string.Join(",", type.GetGenericArguments().Select(arg => arg.GetNestedTypeName()));
                return $"{genericDef}<{genericArgs}>";
            }
            return type.DeclaringType is { } decl ? $"{decl.GetNestedTypeName()}.{type.Name}" : type.Name;
        }

        public static string GetPrettyTypeName(this Type type)
        {
            return type.FullName switch
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
                _ => type.GetNestedTypeName()
            };
        }
    }
}
