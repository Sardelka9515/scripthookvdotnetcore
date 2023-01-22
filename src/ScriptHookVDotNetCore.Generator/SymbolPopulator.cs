using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptHookVDotNetCore.Generator
{
    public class SymbolPopulator
    {
        public static IEnumerable<ITypeSymbol> AllTypes;
        public static IEnumerable<IMethodSymbol> AllMethods;
        public GeneratorExecutionContext Ctx;
        public void Populate(GeneratorExecutionContext context)
        {
            AllTypes = GetAllTypes(context.Compilation);
            AllMethods = GetAllStaticMethods(context.Compilation);
        }

        IEnumerable<IMethodSymbol> GetAllStaticMethods(Compilation compilation)
            => GetAllTypes(compilation).SelectMany(x => x.GetMembers().OfType<IMethodSymbol>()).Where(x => x.IsStatic);

        IEnumerable<INamedTypeSymbol> GetAllTypes(Compilation compilation)
            => GetAllTypes(compilation.GlobalNamespace);

        IEnumerable<INamedTypeSymbol> GetAllTypes(INamespaceSymbol @namespace)
        {
            foreach (var type in @namespace.GetTypeMembers())
                foreach (var nestedType in GetNestedTypes(type))
                    yield return nestedType;

            foreach (var nestedNamespace in @namespace.GetNamespaceMembers())
                foreach (var type in GetAllTypes(nestedNamespace))
                    yield return type;
        }

        IEnumerable<INamedTypeSymbol> GetNestedTypes(INamedTypeSymbol type)
        {
            yield return type;
            foreach (var nestedType in type.GetTypeMembers()
                .SelectMany(nestedType => GetNestedTypes(nestedType)))
                yield return nestedType;
        }
    }
}
