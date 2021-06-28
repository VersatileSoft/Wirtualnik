using System;
using System.Text;

namespace ApiClientGenerator
{
    public class CodeWriter
    {
        private readonly StringBuilder content;
        private int indentLevel;
        private readonly ScopeTracker scopeTracker;

        public CodeWriter()
        {
            scopeTracker = new(this);
            content = new();
            indentLevel = 0;
        }

        public void Append(string line) => content.Append(line);
        public void AppendLine(string line) => content.Append(new string('\t', indentLevel)).AppendLine(line);
        public void AppendLine() => content.AppendLine();
        public void Using(string content) => AppendLine($"using {content};");
        public IDisposable Namespace(string name) => BeginScope($"namespace {name}");
        public IDisposable Class(string name) => BeginScope($"public class {name}");
        public IDisposable Interface(string name) => BeginScope($"public interface {name}");
        public IDisposable BeginScope(string line)
        {
            AppendLine(line);
            return BeginScope();
        }
        public IDisposable BeginScope()
        {
            content.Append(new string('\t', indentLevel)).AppendLine("{");
            indentLevel++;
            return scopeTracker;
        }

        public void EndLine() => content.AppendLine();

        public void EndScope()
        {
            indentLevel--;
            content.Append(new string('\t', indentLevel)).AppendLine("}");
        }

        public void StartLine() => content.Append(new string('\t', indentLevel));
        public override string ToString() => content.ToString();

        private class ScopeTracker : IDisposable
        {
            public ScopeTracker(CodeWriter parent)
            {
                Parent = parent;
            }
            public CodeWriter Parent { get; }

            public void Dispose()
            {
                Parent.EndScope();
            }
        }
    }
}