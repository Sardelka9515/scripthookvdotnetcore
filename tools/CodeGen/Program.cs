global using NativeData = System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, CodeGen.NativeInfo>>;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json;
namespace CodeGen;

internal static class Program
{
    public static GenOptions Options = GenOptions.All;
    public static readonly string Destination = Path.Combine("src", "ScriptHookVDotNetCore", "Scripting","Generated");
    private static void Main(string[] args)
    {

        Directory.SetCurrentDirectory(@"..\..\");
        Console.WriteLine("SHVDN source generator by Sardelka9515");
        Console.WriteLine("Available options:");
        Console.WriteLine("\t" + string.Join(", ", Enum.GetValues<GenOptions>()));

        if (args.Length > 0)
        {
            Options = GenOptions.None;
            foreach (var a in args) Options |= Enum.Parse<GenOptions>(a, true);
        }

        Console.WriteLine("Generating with configuration: " + Options);

        Console.WriteLine("Downloading natives...");
        string nativeData;
        using (var wc = new HttpClient())
        {
            nativeData =
                wc.GetStringAsync("https://raw.githubusercontent.com/alloc8or/gta5-nativedb-data/master/natives.json").GetAwaiter().GetResult();
        }


        Console.WriteLine("Parsing data...");
        var namespaces = JsonConvert.DeserializeObject<NativeData>(nativeData);

        Directory.CreateDirectory(Destination);
        foreach (var generator in typeof(Program).Assembly.GetTypes().
            Where(x => x.IsAssignableTo(typeof(Generator)) && x.IsClass && !x.IsAbstract)
            .Select(x => x.GetConstructor(Type.EmptyTypes).Invoke(null) as Generator))
        {
            Console.WriteLine("Running generator: " + generator.GetType());
            var sw = new StreamWriter(Path.Combine(Destination, generator.FileName));
            var result = generator.Generate(namespaces, Options);
            if (generator.NeedFormatting)
            {
                Console.WriteLine("Formatting result");
                result = FormatSource(result);
            }
            Console.WriteLine("Writing to " + generator.FileName);
            sw.Write(result);
            sw.Close();
            sw.Dispose();
        }

    }
    public static string FormatSource(string source)
    {
        return CSharpSyntaxTree.ParseText(source).GetRoot().NormalizeWhitespace().SyntaxTree.GetText().ToString();
    }
    public static string ToSharpType(this string name)
    {
        return name switch
        {
            "Any" or "ScrHandle" or "SrcHandle" or "FireId" or "Interior" or "ScrHandle*" or "SrcHandle*"
                or "Any*" => "IntPtr",
            "BOOL*" => "bool*",
            "Ped*" or "Entity*" or "Vehicle*" or "Object*" or "Blip*" => "int*",
            "Cam" => "Camera",
            "Object" => "int",
            "Hash" => "uint",
            "Hash*" => "uint*",
            "const char*" => "string",
            "char*" => "byte*",
            "BOOL" => "bool",
            _ => name
        };
    }
}