using System;

namespace AdLib.Reflection.Generator
{
    class EnumAccessGenerator : ReflectionAccessGeneratorBase
    {
        public EnumAccessGenerator(Type actualType, string accessNamespace, string accessClassName) : base(actualType, accessNamespace, accessClassName)
        {
        }

        protected override void GenerateType(SourceCodeBuilder sb, string accessClassIdent)
        {
            sb.AppendLine($"public class {accessClassIdent} : EnumAccessBase<{accessClassIdent}.EnumValues>");
            sb.AppendLine("{");
            using (sb.Indent())
            {
                GenerateCachedAndActualType(sb);
                sb.AppendLine("");
                sb.AppendLine($"public static readonly {accessClassIdent} Shared = new {accessClassIdent}();");
                sb.AppendLine($"{accessClassIdent}() : base(CachedType) {{ }}");
                sb.AppendLine("");
                sb.AppendLine("public enum EnumValues");
                sb.AppendLine("{");
                using (sb.Indent())
                {
                    foreach (var enumValue in Enum.GetValues(ActualType))
                    {
                        sb.AppendLine($"{enumValue} = {(int)enumValue},");
                    }
                }
                sb.AppendLine("}");
            }
            sb.AppendLine("}");
        }
    }
}
