using System.Text;

namespace CodeGen
{
    class InvokerGenerator : Generator
    {
        public override string FileName => "NativeInvoker.cs";

        public override string Generate( NativeData nativeData, GenOptions options)
        {
            var header =
            "using System;\nusing GTA;\nusing GTA.Math;\n\nnamespace GTA.Native\r\n{\r\n\tpublic static unsafe class NativeInvoker\r\n\t{";
            var footer = "\t}\r\n}";
            var names = new HashSet<string>();
            var sb = new StringBuilder();
            sb.AppendLine(header);
            foreach (var ns in nativeData)
            {
                sb.AppendLine($"\t\t#region {ns.Key}");
                foreach (var n in ns.Value)
                {
                    sb.AppendLine();
                    n.Value.WriteInvoker(sb, n.Key, names, options);
                }

                sb.AppendLine();
                sb.AppendLine("\t\t#endregion");
                sb.AppendLine();
            }

            sb.AppendLine(footer);
            return sb.ToString().Replace("\r\n", "\n");
        }
    }
}
