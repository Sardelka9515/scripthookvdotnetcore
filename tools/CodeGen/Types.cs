using Newtonsoft.Json;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeGen
{


    [Flags]
    internal enum GenOptions
    {
        None = 0,

        /// <summary>
        ///     Include parameter info in the summary section of hash enum
        /// </summary>
        Parameters = 1,

        /// <summary>
        ///     Include return info in the returns section of hash enum
        /// </summary>
        Returns = 2,

        /// <summary>
        ///     Include comments the remarks section of hash enum
        /// </summary>
        Comments = 4,

        /// <summary>
        ///     Generate legacy native name
        /// </summary>
        OldNames = 8,

        /// <summary>
        ///     Mark legacy native name as obsolete
        /// </summary>
        MarkObsolete = 16,

        /// <summary>
        ///     Generate invoker class for static function calling
        /// </summary>
        GenInvoker = 32,

        /// <summary>
        /// Generator GTA.Native.Function overloads
        /// </summary>
        GenFunctionOverloads = 32,

        /// <summary>
        ///     All the above, default
        /// </summary>
        All = ~0
    }
    internal class NativeParameter
    {
        private string _name;
        public string type;

        public string name
        {
            get => _name;
            set
            {
                _name = value;
                _name = _name switch
                {
                    "event" or "override" or "base" or "object" or "string" or "out" => "@" + _name,
                    _ => _name
                };
            }
        }

        public override string ToString()
        {
            return $"{type} {name}";
        }

    }

    internal class NativeInfo
    {
        private StringBuilder _builder;

        [JsonProperty("build")] public string Build;

        [JsonProperty("comment")] public string Comment;

        [JsonProperty("jhash")] public string Hash;

        [JsonProperty("name")] public string Name;


        [JsonProperty("old_names")] public string[] OldNames;

        [JsonProperty("params")] public NativeParameter[] Parameters;

        [JsonProperty("return_type")] public string ReturnType;

        private void Add(string line = null)
        {
            if (string.IsNullOrEmpty(line))
            {
                _builder.AppendLine();
                return;
            }

            _builder.AppendLine($"\t\t{line}");
        }

        private void AddComment()
        {
            Add("/// <remarks>");

            foreach (var s in Comment.Split('\n', StringSplitOptions.RemoveEmptyEntries))
            {
                // Escape xml special characters
                var escaped = s.Replace("<", "&lt;").Replace(">", "&gt;").Replace("&", "&#38;");
                // Add url link
                var result = Regex.Replace(escaped,
                    @"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)",
                    "<see href='$1'>$1</see>");
                Add($"/// {result}<br/>");
            }

            Add("/// </remarks>");
        }

        private void AddObsolete(string name = null)
        {
            Add($"/// <remarks>This function has been replaced by <see cref=\"{name ?? Name}\"/></remarks>");
            Add("[Obsolete]");
        }

        private void Sanitize()
        {

            var dup = new HashSet<string>();
            foreach (var p in Parameters)
            {
                var i = 0;
                if (dup.Contains(p.name))
                    while (dup.Contains(p.name = $"{p.name}i"))
                        i++;
                dup.Add(p.name);
            }
        }

        public void WriteInvoker(StringBuilder sb, string hash, HashSet<string> added, GenOptions o)
        {
            if (added.Contains(Name)) return;
            _builder = sb;
            Sanitize();

            if (o.HasFlag(GenOptions.Parameters) && Parameters is { Length: > 0 })
            {
                Add("/// <summary>");
                Add("/// Parameters: " + string.Join(", ", (object[])Parameters));
                Add("/// </summary>");
            }

            if (o.HasFlag(GenOptions.Comments) && !string.IsNullOrEmpty(Comment)) AddComment();

            WriteMethod(hash);
            added.Add(Name);

            if (OldNames != null && o.HasFlag(GenOptions.OldNames))
                foreach (var old in OldNames)
                {
                    if (added.Contains(old)) return;
                    Add();
                    WriteMethod(hash, old, o.HasFlag(GenOptions.MarkObsolete));
                    added.Add(old);
                }
        }

        private void WriteMethod(string hash, string name = null, bool obsolete = false)
        {
            name ??= Name;
            var paras = "";
            foreach (var p in Parameters) paras += $", {p.name}";
            var ret = ReturnType != "void" ? $"<{ReturnType.ToSharpType()}>" : "";
            if (ret == "<IntPtr>") Add($"/// <returns>{ReturnType}</returns>");
            if (obsolete) AddObsolete();
            Add($"public static {ReturnType.ToSharpType()} {name}" +
                $"({string.Join(", ", Parameters.Select(x => $"{x.type.ToSharpType()} {x.name}"))})");
            Add($"\t=> Call{ret}((Hash){hash}{paras});");
        }

        public void WriteHashEnum(StringBuilder sb, string hash, HashSet<string> added, GenOptions o)
        {
            if (added.Contains(Name)) return;
            _builder = sb;
            Sanitize();

            if (o.HasFlag(GenOptions.Parameters) && Parameters is { Length: > 0 })
            {
                Add("/// <summary>");
                Add("/// Parameters: " + string.Join(", ", (object[])Parameters));
                Add("/// </summary>");
            }

            if (o.HasFlag(GenOptions.Comments) && !string.IsNullOrEmpty(Comment)) AddComment();

            if (o.HasFlag(GenOptions.Returns)) Add($"/// <returns>{ReturnType}</returns>");
            var suffix = string.IsNullOrEmpty(Hash) ? "" : $" // {Hash}";
            Add($"{Name} = {hash},{suffix}");
            added.Add(Name);
            if (OldNames != null && o.HasFlag(GenOptions.OldNames))
                foreach (var old in OldNames)
                {
                    if (added.Contains(old)) continue;
                    Add();
                    if (o.HasFlag(GenOptions.MarkObsolete)) AddObsolete();
                    Add($"{old} = {hash},{suffix}");
                    added.Add(old);
                }
        }

    }
}