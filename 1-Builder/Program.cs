using System;
using System.Collections.Generic;
using System.Text;

namespace TestDP
{
    public class CodeLine
    {
        public string Access { get; set; }
        public string VariableType { get; set; }
        public string VariableValue { get; set; }
        public CodeLine(string access, string variableType, string variableVal)
        {
            Access = access;
            VariableType = variableType;
            VariableValue = variableVal;
        }

        public override string ToString()
        {
            return $"{Access} {VariableType} {VariableValue};";
        }
    }

    public sealed class Code
    {
        public List<CodeLine> codeLines = new List<CodeLine>();
        public string ClassName = "";
        private const int indentSize = 2;

        public override string ToString() 
        { 
            var sb = new StringBuilder();
            sb.AppendLine($"public class {ClassName}");
            sb.AppendLine("{");
            var indent = new string(' ', indentSize);
            foreach ( CodeLine line in codeLines ) 
                sb.AppendLine(indent + line.ToString());
            sb.AppendLine("}");
            return sb.ToString();
        }
    }

    public class CodeBuilder
    {
        private Code code;
        public CodeBuilder(string className)
        {
            code = new Code();
            code.ClassName = className;
        }

        public CodeBuilder AddField(string value, string name)
        {
            code.codeLines.Add(new CodeLine("public", name, value));
            return this;
        }

        public override string ToString() 
        { 
            return code.ToString();
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person")
                .AddField("Name", "string")
                .AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }
}
