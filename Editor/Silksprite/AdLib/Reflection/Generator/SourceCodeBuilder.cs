using System;
using System.Text;

namespace AdLib.Reflection.Generator
{
    class SourceCodeBuilder
    {
        readonly StringBuilder _sb = new StringBuilder();
        string _indent = "";

        public void AppendLine(string value) => _sb.AppendLine(_indent + value);

        public void AddIndent() => _indent += "    ";

        public void SubIndent() => _indent = _indent[..^4];

        internal IndentScope Indent() => new IndentScope(this);

        internal readonly struct IndentScope : IDisposable
        {
            readonly SourceCodeBuilder _me;

            public IndentScope(SourceCodeBuilder me)
            {
                _me = me;
                _me.AddIndent();
            }

            public void Dispose()
            {
                _me.SubIndent();
            }
        }

        public override string ToString() => _sb.ToString();
    }
}
