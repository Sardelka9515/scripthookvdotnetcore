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
        public static List<ITypeSymbol> AllTypes = new();
        public static List<IMethodSymbol> AllMethods = new();
        public GeneratorExecutionContext Ctx;
        public void Populate(GeneratorExecutionContext context)
        {
            Ctx = context;
            var cpl = Ctx.Compilation;
            foreach (var tree in cpl.SyntaxTrees)
            {
                var model = Ctx.Compilation.GetSemanticModel(tree);
                var methods = tree.GetRoot().DescendantNodes().Where(x => x is MethodDeclarationSyntax).Cast<MethodDeclarationSyntax>().Select(x => (IMethodSymbol)model.GetDeclaredSymbol(x));
                AllMethods.AddRange(methods);
            }
            AllMethods = AllMethods.Distinct(SymbolEqualityComparer.Default).Cast<IMethodSymbol>().ToList();

            foreach (var tree in cpl.SyntaxTrees)
            {
                var classes = tree.GetRoot().DescendantNodes().Where(x => x is ClassDeclarationSyntax).Cast<ClassDeclarationSyntax>();
                var model = Ctx.Compilation.GetSemanticModel(tree);
                AllTypes.AddRange(classes.Select(x => (ITypeSymbol)model.GetDeclaredSymbol(x)));
            }
            AllTypes = AllTypes.Distinct(SymbolEqualityComparer.Default).Cast<ITypeSymbol>().ToList();
        }
    }
}
