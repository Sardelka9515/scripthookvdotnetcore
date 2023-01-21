using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updater
{

    // Used fot this PR: https://github.com/crosire/scripthookvdotnet/pull/1136
    internal class NativeMemoryDelegateToFuncPtr : ISourceUpdater
    {
        public string TargetFile => "NativeMemory1.cs";
        static Dictionary<string, string> Fixes = new()
        {

            { "SetEntityAngularVelocityDelegate setAngularVelocityDelegate;","delegate* unmanaged[Stdcall] <IntPtr, float*, void> setAngularVelocityDelegate;"},

            {"var getFragInstFunc = CreateGetFragInstDelegateIfNotCreated(vFuncAddr);"
                ,"var getFragInstFunc = (delegate* unmanaged[Stdcall] <IntPtr, FragInst*>)(vFuncAddr);" },

            {"var getEntityAngularVelocity = CreateGetEntityAngularVelocityDelegateIfNotCreated(vFuncAddr);",
            "var getEntityAngularVelocity = (delegate* unmanaged[Stdcall] <IntPtr,float*>)(vFuncAddr);"},

            {"var setEntityAngularVelocityDelegate = CreateSetEntityAngularVelocityDelegateIfNotCreated(vFuncAddr);",
            "var setEntityAngularVelocityDelegate = (delegate* unmanaged[Stdcall] <IntPtr, float*, void>)(vFuncAddr);"},

            {"var getEventTypeIndexFunc = CreateGetEventTypeIndexDelegateIfNotCreated(eventAddress);"
            ,"var getEventTypeIndexFunc = (delegate* unmanaged[Stdcall] <ulong, int>)(eventAddress);"},
        };

        static HashSet<string> Remove = new() {
            "setEntityAngularVelocityVFuncCache",
            "getEntityAngularVelocityVFuncCache",
            "getFragInstVFuncCache",
            "CreateGetFragInstDelegateIfNotCreated",
            "getEventTypeIndexDelegateCacheDict",
            "CreateGetEntityAngularVelocityDelegateIfNotCreated",
            "CreateSetEntityAngularVelocityDelegateIfNotCreated",
            "CreateGetEventTypeIndexDelegateIfNotCreated",
            "setEntityAngularVelocityVFuncCache",
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
                case DelegateDeclarationSyntax dd:
                    return dd.Identifier.ToString();
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
            var delegates = new Dictionary<string, DelegateConverter>();
            foreach (var mb in nativeMemoryClass.Members)
            {
                var modifiers = mb.Modifiers.Select(x => x.ToString());

                var body = mb.ToString();

                if (mb is DelegateDeclarationSyntax dd)
                {
                    var d = new DelegateConverter(dd);
                    d.CallConv = "[Stdcall] ";
                    delegates.Add(dd.Identifier.ToString(), d);
                    var old = $" {dd.Identifier} ";
                    var @new = $" {d.ToFnPtr()} ";
                    Fixes.Add(old, @new);
                    old = $"GetDelegateForFunctionPointer<{d.Name}>";
                    @new = $"({d.ToFnPtr()})";
                    Fixes.Add(old, @new);
                    Remove.Add(d.Name);
                }

            }
            foreach (var f in Fixes)
            {
                src = src.Replace(f.Key, f.Value);
            }

            Parse(src);
        again:
            var mbs = nativeMemoryClass.Members.Where(x => Remove.Contains(GetId(x)));
            if (mbs.Any())
            {
                foreach (var mb in mbs)
                {
                    RemoveMember(GetId(mb));
                }
                Parse(src);
                goto again;
            }
            // src = tree.GetRoot().NormalizeWhitespace().GetText().ToString();
            // File.WriteAllText("bin/SHVDN.NativeMemory.cs", src);
            return src;

            void RemoveMember(string name)
            {
                Parse(src);
                var mb = nativeMemoryClass.Members.First(x => GetId(x) == name);
                Console.WriteLine("Removing member " + name);
                src = src.Replace(mb.ToString() + "\r\n", "");
                src = src.Replace(mb.ToString(), ""); // just in case
            }
        }
    }
}
