using System;
using System.Collections.Generic;
using System.Linq;

namespace AdLib.Reflection.Generator
{
    abstract class ReflectionAccessGeneratorBase
    {
        protected readonly Type ActualType;

        protected readonly string AccessNamespace;
        protected readonly string AccessClassName;

        protected ReflectionAccessGeneratorBase(Type actualType, string accessNamespace, string accessClassName)
        {
            ActualType = actualType;
            
            AccessNamespace = accessNamespace;
            AccessClassName = accessClassName;
        }

        public static ReflectionAccessGeneratorBase Create(Type type, string accessNamespace, string accessClassName) =>
            type switch
            {
                { IsEnum: true } => new EnumAccessGenerator(type, accessNamespace, accessClassName),
                _ => new ObjectAccessGenerator(type, accessNamespace, accessClassName),
            };

        public string Generate()
        {
            var sb = new SourceCodeBuilder();
            GenerateUsings(sb);
            sb.AppendLine("");
            GenerateNamespace(sb);
            return sb.ToString();
        }

        void GenerateUsings(SourceCodeBuilder sb)
        {
            var systemUsings = new List<string>
            {
                "System",
                "System.Collections.Generic",
                "System.Diagnostics.CodeAnalysis"
            };
            var usings = CollectUsings().OrderBy(s => s);
            foreach (var usingItem in systemUsings.Concat(usings).Distinct().Where(s => s != AccessNamespace))
            {
                sb.AppendLine($"using {usingItem};");
            }
        }

        void GenerateNamespace(SourceCodeBuilder sb)
        {
            if (string.IsNullOrEmpty(AccessNamespace))
            {
                GenerateNested(sb);
                return;
            }
            sb.AppendLine($"namespace {AccessNamespace}");
            sb.AppendLine("{");
            using (sb.Indent())
            {
                sb.AppendLine(@"[SuppressMessage(""ReSharper"", ""InconsistentNaming"")]");
                GenerateNested(sb);
            }
            sb.AppendLine("}");
        }

        void GenerateNested(SourceCodeBuilder sb)
        {
            var nestedNames = AccessClassName.Split("+")!;
            var nestedCount = nestedNames.Length - 1;

            for (var i = 0; i < nestedCount; i++)
            {
                sb.AppendLine($"public static partial class {nestedNames[i]}");
                sb.AppendLine("{");
                sb.AddIndent();
            }

            sb.AppendLine($@"[ReflectionAccess(""{ActualType.FullName}"", ""{ActualType.Assembly.GetName().Name}"")]");
            GenerateType(sb, nestedNames[nestedCount]);

            for (var i = 0; i < nestedCount; i++)
            {
                sb.SubIndent();
                sb.AppendLine("}");
            }
        }

        protected virtual IEnumerable<string> CollectUsings()
        {
            yield return "Silksprite.AdLib.Reflection";
            yield return "Silksprite.AdLib.Reflection.Attributes";
            yield return "Silksprite.AdLib.Reflection.Base";
            yield return "Silksprite.AdLib.Reflection.Extensions";
        }

        protected abstract void GenerateType(SourceCodeBuilder sb, string accessClassIdent);

        protected void GenerateCachedAndActualType(SourceCodeBuilder sb)
        {
            sb.AppendLine($"static readonly CachedType CachedType = CachedAppDomain.Instance.GetRuntimeType(\"{ActualType.FullName}\");");
            sb.AppendLine("public static Type ActualType => CachedType.ActualType;");
            sb.AppendLine("public static Type IsImplemented => CachedType.IsImplemented;");
        }
    }
}
