using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Xml.Xsl;
using System.Security.Cryptography;

namespace Updater
{
    internal class NativeMemoryUpdater : ISourceUpdater
    {
        public string TargetFile => "NativeMemory.cs";
        static HashSet<string> Remove = new() {
             "_strBufferForStringToCoTaskMemUTF8",
             "StringToCoTaskMemUTF8",
             "PtrToStringUTF8",
        };
        static Dictionary<string, string> Fixes = new()
        {
            {"public static unsafe class NativeMemory","public static unsafe partial class NativeMemory" },
            {findPatternCodetoReplace,"" }
        };

        SyntaxTree tree;
        CompilationUnitSyntax root;
        NamespaceDeclarationSyntax nameSpace;
        ClassDeclarationSyntax nativeMemoryClass;
        static string GetId(MemberDeclarationSyntax mb)
        {
            switch (mb)
            {
                case FieldDeclarationSyntax fd:
                    return fd.Declaration.Variables.First().Identifier.ToString();
                case PropertyDeclarationSyntax pd:
                    return pd.Identifier.ToString();
                case MethodDeclarationSyntax md:
                    return md.Identifier.ToString();
                default:
                    return null;
            }
        }
        public string Update(ReadOnlySpan<char> srcSpan)
        {
            void Parse(string text)
            {
                tree = CSharpSyntaxTree.ParseText(text);
                root = tree.GetCompilationUnitRoot();
                nameSpace = root.Members.OfType<NamespaceDeclarationSyntax>().First();
                nativeMemoryClass = nameSpace.Members.OfType<ClassDeclarationSyntax>().First();
            }
            var src = srcSpan.ToString();
            Parse(src);
            List<string> toRemove = new();
            foreach (var mb in nativeMemoryClass.Members)
            {
                var id = GetId(mb);
                if (Remove.Contains(id))
                {
                    var content = src.Substring(mb.Span.Start, mb.Span.End - mb.Span.Start);
                    toRemove.Add(content);
                }
            }
            foreach (var r in toRemove)
            {
                src = src.Replace(r, "");
            }
            foreach (var f in Fixes)
            { src = src.Replace(f.Key, f.Value); }
            return src;
        }

        // 💩
        const string findPatternCodetoReplace = @"
		/// <summary>
		/// Searches the specific address space of the current process for a memory pattern.
		/// </summary>
		/// <param name=""pattern"">The pattern.</param>
		/// <param name=""mask"">The pattern mask.</param>
		/// <param name=""startAddress"">The address to start searching at.</param>
		/// <param name=""size"">The size where the pattern search will be performed from <paramref name=""startAddress""/>.</param>
		/// <returns>The address of a region matching the pattern or <see langword=""null"" /> if none was found.</returns>
		public static unsafe byte* FindPattern(string pattern, string mask, IntPtr startAddress, ulong size)
		{
			ulong address = (ulong)startAddress.ToInt64();
			ulong endAddress = address + size;

			for (; address < endAddress; address++)
			{
				for (int i = 0; i < pattern.Length; i++)
				{
					if (mask[i] != '?' && ((byte*)address)[i] != pattern[i])
						break;
					else if (i + 1 == pattern.Length)
						return (byte*)address;
				}
			}

			return null;
		}
";
    }
    class DelegateConverter
    {
        public List<(string, string)> Parameters;
        public string ReturnType;
        public string Name;
        public string Modifiers;
        public string CallConv;
        public DelegateConverter(DelegateDeclarationSyntax dd)
        {
            Parameters = dd.ParameterList.Parameters.Select(x => (x.Type.ToString(), x.Identifier.ToString())).ToList();
            Name = dd.Identifier.ToString();
            Modifiers = dd.Modifiers.ToString();
            ReturnType = dd.ReturnType.ToString();
        }
        public string ToFnPtrDecl(string modifiers = null)
        {
            return $"{(modifiers == null ? Modifiers : modifiers)} {ToFnPtr()} {Name};";
        }
        public string ToFnPtr()
        {
            var ps = string.Join(',', Parameters.Select(x => x.Item1));
            var types = string.IsNullOrEmpty(ps) ? ReturnType : $"{ps},{ReturnType}";
            return $"delegate* unmanaged{CallConv}<{types}>";
        }
    }
}
