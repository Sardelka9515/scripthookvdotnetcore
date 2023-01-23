using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.Design.AxImporter;
using System.Xml.Linq;

namespace CodeGen
{
    internal class HashGenerator : Generator
    {

        public override string FileName => "NativeHashes.cs";

        public override string Generate(NativeData nativeData, GenOptions options)
        {
            var header = "using System;\n\nnamespace GTA.Native\r\n{\r\n\tpublic enum Hash : ulong\r\n\t{";
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
                    n.Value.WriteHashEnum(sb, n.Key, names, options);
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
