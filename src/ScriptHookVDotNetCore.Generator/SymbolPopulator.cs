using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptHookVDotNetCore.Generator
{
    public class SymbolPopulator
    {
        public List<INamedTypeSymbol> AllClasses = new();
        public List<IMethodSymbol> AllMethods = new();
        public void Populate(GeneratorExecutionContext context)
        {
            var comp = context.Compilation;
            foreach (var tree in comp.SyntaxTrees)
            {
                var vis = new Visitor();
                var model = context.Compilation.GetSemanticModel(tree);
                vis.Visit(tree.GetRoot());
                AllClasses.AddRange(vis.classes.Select(x => model.GetDeclaredSymbol(x)));
            }
            AllClasses = AllClasses.Distinct(SymbolEqualityComparer.Default).Cast<INamedTypeSymbol>().ToList();
            AllMethods = AllClasses.SelectMany(c => c.GetMembers().OfType<IMethodSymbol>()).ToList();
        }

        class Visitor : CSharpSyntaxRewriter
        {
            public List<ClassDeclarationSyntax> classes = new();
            public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
            {
                classes.Add(node);
                return node;
            }
        }
    }
}
