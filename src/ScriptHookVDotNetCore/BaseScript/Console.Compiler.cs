using GTA;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;
using System.Text.RegularExpressions;

[assembly: InternalsVisibleTo("ConsoleInput")]

namespace SHVDN;
internal static unsafe partial class Console
{
    const string Template = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA.Native;
using GTA.UI;
using GTA.Math;
using static GTA.Native.NativeInvoker;

namespace GTA;
static unsafe class ConsoleInput
{{
    public static object Run()
    {{
        var P = Game.Player.Character;
        var V = P.CurrentVehicle;
        {0};
        return null;
    }}
    {1}
}}";
    static readonly string[] _frameworkAssemblies = Directory.GetFiles(
            Directory.GetParent(typeof(object).Assembly.Location).FullName,
            "System.*.dll")
            .Where(Core.IsManagedAssembly).ToArray();
    static MemoryStream CompileInput(string expression)
    {
        var references = _frameworkAssemblies
            .Append(typeof(Core).Assembly.Location)
            .Select(x => MetadataReference.CreateFromFile(x));

        var source = SourceText.From(string.Format(Template, expression
            , string.Join('\n',
            _commands.Values.Select(x =>
            {
                // Add commands to source only if used in expression
                if (Regex.IsMatch(expression, @$"(^|\n|\W+){x.Name}\("))
                    return x.Code;
                return string.Empty;
            }))));
        // Logger.Debug($"Source:\n" + source);
        var options = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp10);
        var parsedSyntaxTree = SyntaxFactory.ParseSyntaxTree(source, options);
        var compilation = CSharpCompilation.Create("ConsoleInput",
            new[] { parsedSyntaxTree },
            references: references,
            options: new CSharpCompilationOptions(
                outputKind: OutputKind.DynamicallyLinkedLibrary,
                optimizationLevel: OptimizationLevel.Debug,
                assemblyIdentityComparer: DesktopAssemblyIdentityComparer.Default,
                allowUnsafe: true));

        var peStream = new MemoryStream();
        var result = compilation.Emit(peStream);

        foreach (var diagnostic in result.Diagnostics
            .Where(x =>
            x.IsWarningAsError || x.Severity == DiagnosticSeverity.Error))
        {
            Logger.Error($"{diagnostic.Id}: {diagnostic.GetMessage()}");
        }

        if (!result.Success)
        {
            peStream.Dispose();
            return null;
        }

        peStream.Seek(0, SeekOrigin.Begin);
        return peStream;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static void ExecuteAndUnload(Stream assemblyStream, out WeakReference alcWeakRef)
    {
        var alc = new AssemblyLoadContext("ConsoleInput", true);
        alc.Resolving += (s, e) =>
        {
            if (e.Name == typeof(Core).Assembly.GetName().Name)
                return typeof(Core).Assembly;
            return null;
        };
        Assembly a = alc.LoadFromStream(assemblyStream);
        alcWeakRef = new WeakReference(alc, trackResurrection: true);
        var result = a.GetType("GTA.ConsoleInput").GetMethod("Run", BindingFlags.Static | BindingFlags.Public).Invoke(null, null);
        if (result != null)
            PrintInfo($"[Return Value]: {result}");
        alc.Unload();
    }

}