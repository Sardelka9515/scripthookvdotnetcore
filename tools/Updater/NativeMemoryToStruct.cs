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
    internal class NativeMemoryToStruct : ISourceUpdater
    {
        public string TargetFile => "NativeMemory.cs";
        static HashSet<string> Move = new()
        {
            "FindPattern",
            "ReadByte",
            "ReadInt16",
            "ReadInt32",
            "ReadFloat",
            "ReadString",
            "ReadAddress",
            "ReadMatrix",
            "ReadVector3",
            "WriteByte",
            "WriteInt16",
            "WriteInt32",
            "WriteFloat",
            "WriteMatrix",
            "WriteVector3",
            "WriteAddress",
            "SetBit",
            "ClearBit",
            "IsBitSet",
            "String",
            "NullString",
            "CellEmailBcon",
            "disallowWeaponHashSetForHumanPedsOnFoot",
        };
        static HashSet<string> Remove = new() {
             "_strBufferForStringToCoTaskMemUTF8",
             "StringToCoTaskMemUTF8",
             "PtrToStringUTF8",

            "setEntityAngularVelocityVFuncCache",
            "getEntityAngularVelocityVFuncCache",
            "getFragInstVFuncCache",
            "CreateGetFragInstDelegateIfNotCreated",
            "getEventTypeIndexDelegateCacheDict",
            "CreateGetEventTypeIndexDelegateIfNotCreated",
            "setEntityAngularVelocityVFuncCache",
            "CreateSetEntityAngularVelocityDelegateIfNotCreated",
            "CreateGetEntityAngularVelocityDelegateIfNotCreated",
        };
        static Dictionary<string, string> StFixes = new()
        {
            {"static NativeMemory(", "public NativeMemoryStruct(" },
            {"SHVDN.NativeMemory.", "" },
            { "NativeMemory.", ""},
            {" PtrToStringUTF8("," Marshaller.PtrToStringUTF8(" },
            { "ReadOnlyCollection","HeapArray"},
            { "Array.AsReadOnly","Marshaller.ToHeapArray"},
            { "unmanaged[Stdcall]","unmanaged[SuppressGCTransition]"}
            };
        static Dictionary<string, string> CaFixes = new()
        {
            { "ReadOnlyCollection","HeapArray"},
            { "unmanaged[Stdcall]","unmanaged[SuppressGCTransition]"}
        };
        List<MethodDeclarationSyntax> Externals = new();

        SyntaxTree tree;
        CompilationUnitSyntax root;
        NamespaceDeclarationSyntax nameSpace;
        ClassDeclarationSyntax nativeMemoryClass;
        string newSource = null;
        bool NeedMove(MemberDeclarationSyntax mb)
        {
            if (mb is MethodDeclarationSyntax m)
            {
                if (mb.Modifiers.Any(x => x.ToString() == "extern"))
                {
                    Externals.Add(m);
                }
                return true;
            }
            return Move.Contains(GetId(mb));
        }
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
            var sbMembers = new StringBuilder();
            var sbBridges = new StringBuilder();
            var sbMoved = new StringBuilder();
            var delegates = new Dictionary<string, DelegateConverter>();
            foreach (var mb in nativeMemoryClass.Members)
            {
                if (Remove.Contains(GetId(mb)))
                {
                    continue;
                }
                var modifiers = mb.Modifiers.Select(x => x.ToString());

                var body = mb.ToString();


                if (NeedMove(mb))
                {
                    sbMoved.AppendLine(body);
                    continue;
                }

                if (!modifiers.Contains("public") && !modifiers.Contains("internal"))
                {
                    AddModifier("internal");
                }

                // Make all fields/properties non-static
                if (mb is FieldDeclarationSyntax || mb is PropertyDeclarationSyntax || mb is MethodDeclarationSyntax)
                {
                    RemoveModifier("static");
                    body = body.Replace("private ", "");
                }

                if (mb is TypeDeclarationSyntax || mb is EnumDeclarationSyntax || mb is DelegateDeclarationSyntax)
                {
                    // Convert delegates to function pointer syntax
                    if (mb is DelegateDeclarationSyntax dd)
                    {
                        var d = new DelegateConverter(dd);
                        d.CallConv = "[Stdcall, SuppressGCTransition] ";
                        delegates.Add(dd.Identifier.ToString(), d);
                        var old = $" {dd.Identifier} ";
                        var @new = $" {d.ToFnPtr()} ";
                        StFixes.Add(old, @new);
                        CaFixes.Add(old, @new);
                        old = $"GetDelegateForFunctionPointer<{d.Name}>";
                        @new = $"({d.ToFnPtr()})";
                        StFixes.Add(old, @new);
                        CaFixes.Add(old, @new);
                    }
                    else
                    {
                        sbMoved.AppendLine(body);
                    }
                    continue;
                }
                else
                {
                    sbMembers.AppendLine(body);
                }

                void AddModifier(string mod)
                {
                    string txt = mb switch
                    {
                        StructDeclarationSyntax s => s.Modifiers.Any() ? $"{s.Modifiers} struct {s.Identifier}" : $"struct {s.Identifier}",
                        DelegateDeclarationSyntax s => s.Modifiers.Any() ? $"{s.Modifiers} delegate {s.ReturnType} {s.Identifier}" : $"delegate {s.ReturnType} {s.Identifier}",
                        MethodDeclarationSyntax s => s.Modifiers.Any() ? $"{s.Modifiers} {s.ReturnType} {s.Identifier}" : $"{s.ReturnType} {s.Identifier}",
                        PropertyDeclarationSyntax s => s.Modifiers.Any() ? $"{s.Modifiers} {s.Type} {s.Identifier}" : $"{s.Type} {s.Identifier}",

                        EnumDeclarationSyntax s => s.Modifiers.Any() ? $"{s.Modifiers} enum {s.Identifier}" : $"enum {s.Identifier}",
                        FieldDeclarationSyntax s => s.ToString(),
                        _ => null
                    };
                    if (txt != null)
                    {
                        body = body.Replace(txt, $" {mod} " + txt);
                    }
                }
                void RemoveModifier(string mod)
                {
                    string txt = mb switch
                    {
                        StructDeclarationSyntax s => s.Modifiers.Any() ? $"{s.Modifiers} struct {s.Identifier}" : $"struct {s.Identifier}",
                        DelegateDeclarationSyntax s => s.Modifiers.Any() ? $"{s.Modifiers} delegate {s.ReturnType} {s.Identifier}" : $"delegate {s.ReturnType} {s.Identifier}",
                        MethodDeclarationSyntax s => s.Modifiers.Any() ? $"{s.Modifiers} {s.ReturnType} {s.Identifier}" : $"{s.ReturnType} {s.Identifier}",
                        PropertyDeclarationSyntax s => s.Modifiers.Any() ? $"{s.Modifiers} {s.Type} {s.Identifier}" : $"{s.Type} {s.Identifier}",

                        EnumDeclarationSyntax s => s.Modifiers.Any() ? $"{s.Modifiers} enum {s.Identifier}" : $"enum {s.Identifier}",
                        FieldDeclarationSyntax s => s.ToString(),
                        _ => null
                    };
                    if (txt != null)
                    {
                        body = body.Replace(txt, txt.Replace($"{mod} ", ""));
                    }
                }

                // Bridge
                switch (mb)
                {
                    case MethodDeclarationSyntax md:
                        var parms = md.ParameterList.Parameters.Select(x => x.Modifiers.Any(x => x.ToString() == "ref") ? "ref " + x.Identifier : x.Identifier.ToString());
                        if (modifiers.Contains("extern"))
                        {
                            sbBridges.AppendLine($"{md.Modifiers.ToString().Replace("extern", "")} {md.ReturnType} {md.Identifier}{md.ParameterList} => NativeMemoryStruct.{md.Identifier}({string.Join(',', parms)});");
                        }
                        else
                        {
                            sbBridges.AppendLine($"{md.Modifiers} {md.ReturnType} {md.Identifier}{md.ParameterList} => _pNativeMemory->{md.Identifier}({string.Join(',', parms)});");
                        }
                        break;
                    case PropertyDeclarationSyntax pd:
                        var t = pd.ToString();
                        var acc = pd.AccessorList?.Accessors;
                        var hasGetter = acc?.Any(x => x.Keyword.Text == "get") == true || t.Contains("=>");
                        var hasSetter = acc?.Any(x => x.Keyword.Text == "set") == true;
                        if (hasGetter)
                        {

                            if (hasSetter)
                            {
                                sbBridges.AppendLine($"{pd.Modifiers} {pd.Type} {pd.Identifier}{{get=>_pNativeMemory->{pd.Identifier};set=> _pNativeMemory->{pd.Identifier}=value;}}");
                            }
                            else // getter only
                            {
                                sbBridges.AppendLine($"{pd.Modifiers} {pd.Type} {pd.Identifier} => _pNativeMemory->{pd.Identifier};");
                            }
                        }
                        else
                        {
                            sbBridges.AppendLine($"{pd.Modifiers} {pd.Type} {pd.Identifier} {{set=> _pNativeMemory->{pd.Identifier}=value;}}");
                        }
                        break;

                    case FieldDeclarationSyntax fd:
                        var f = fd.Declaration.Variables.First();
                        sbBridges.AppendLine($"{fd.Modifiers} {fd.Declaration.Type} {f.Identifier} => _pNativeMemory->{f.Identifier};");
                        break;
                }

            }
            var members = sbMembers.ToString();
            var newClass = $@"
            {sbMoved}
            #region Bridges
            {sbBridges}
            #endregion";
            foreach (var f in StFixes)
            {
                members = members.Replace(f.Key, f.Value);
            }
            foreach (var f in CaFixes)
            {
                newClass = newClass.Replace(f.Key, f.Value);
            }
            foreach (var ext in Externals)
            {
                members = members.Replace($"{ext.Identifier}(", $"NativeMemory.{ext.Identifier}(");
            }
            newSource = $@"
//
// Copyright (C) 2015 crosire & contributors
// License: https://github.com/crosire/scripthookvdotnet#license
//

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;
using static System.Runtime.InteropServices.Marshal;
using static SHVDN.NativeMemory;
namespace SHVDN
{{   

    
    /// <summary>
	/// Struct to hold memory pattern and offsets.
	/// </summary>
	public unsafe struct NativeMemoryStruct
	{{
        {members}
    }}

    public static unsafe class NativeMemory
    {{
        public const string StructSinature = ""SHVDN.NativeMemory.98cd9e030a8f81d45cc9d2e87da5002117f3266777a45a455f9a51fcc7195640"";
        private static readonly Mutex _nativeMemoryMutex = new Mutex(true, StructSinature);
        static NativeMemory()
        {{
            try
            {{
                _nativeMemoryMutex.WaitOne();
                // Safeguard against repeated static constructor invocation
                if (_pNativeMemory != null)
                {{
                    return;
                }}
                // Return if the struct has already been initialized
                else if ((_pNativeMemory = (NativeMemoryStruct*)Core.GetPtr(StructSinature)) != null)
                {{
                    Logger.Debug($""Using NativeMemoryStruct at address {{(IntPtr)_pNativeMemory}}"");
                    return;
                }}

                var temp = new NativeMemoryStruct();
                // Need to manually allocate it on unmanaged heap so it doesn't get popped from the stack (or GC'd?)
                _pNativeMemory = (NativeMemoryStruct*)AllocHGlobal(sizeof(NativeMemoryStruct));
                *_pNativeMemory = temp;
                Core.SetPtr(StructSinature, (ulong)_pNativeMemory);
                Logger.Debug($""Initialized NativeMemoryStruct at address {{(IntPtr)_pNativeMemory}}"");
            }}
            catch (Exception ex)
            {{
                Logger.Error($""NativeMemory init error: {{ex}}"");
                throw;
            }}
            finally
            {{
                _nativeMemoryMutex.ReleaseMutex();
            }}
        }}

        private static readonly NativeMemoryStruct* _pNativeMemory = null;
        {newClass}
        public static string PtrToStringUTF8(IntPtr ptr) => Marshaller.PtrToStringUTF8(ptr);
    }}
}}";
            tree = CSharpSyntaxTree.ParseText(newSource);
            root = tree.GetCompilationUnitRoot();
            newSource = tree.GetRoot().NormalizeWhitespace().SyntaxTree.GetText().ToString();
            Parse(newSource);
            var nst = nameSpace.Members.OfType<StructDeclarationSyntax>().First(x => x.Identifier.ToString() == "NativeMemoryStruct");


            // Compute struct signature
            using var sha = SHA256.Create();
            List<string> signarutres = new();
            Console.WriteLine();
            Console.WriteLine("----------NativeMemory Fields------------");
            foreach (var f in nst.Members.OfType<FieldDeclarationSyntax>())
            {
                Console.WriteLine($"{f.Declaration.Type} {f.Declaration.Variables.First().Identifier}");
                signarutres.Add(f.Declaration.ToString());
            }
            Console.WriteLine("----------End Fields------------");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("----------NativeMemory Properties------------");
            foreach (var p in nst.Members.OfType<PropertyDeclarationSyntax>())
            {
                Console.WriteLine($"{p.Type} {p.Identifier}");
                signarutres.Add(p.Type + " " + p.Identifier);
            }
            Console.WriteLine("----------End Properties------------");
            Console.WriteLine();
            var sig = sha.ComputeHash(Encoding.UTF8.GetBytes(string.Join(';', signarutres)));
            StringBuilder sbSig = new StringBuilder();
            for (int i = 0; i < sig.Length; i++)
            {
                sbSig.Append(sig[i].ToString("x2"));
            }
            var structSignature = $"SHVDN.NativeMemory.{sbSig}";
            Console.WriteLine($"Struct signature is {structSignature}");
            newSource = newSource.Replace("const string StructSinature;", $"const string StructSinature = \"{structSignature}\";");
            return newSource;
        }
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
