using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static System.IO.Path;
namespace Updater
{
    internal unsafe class Program
    {
        static HashSet<string> SrcExlude = new HashSet<string>
        {
            "Native.cs",
            "Script.cs",
            "Vector3.cs",
            "ScriptAttributes.cs",
            "NativeHashes.cs"
        };
        static Dictionary<string, string> SrcUpstream = new();
        static List<ISourceUpdater> Updaters = typeof(ISourceUpdater).Assembly.GetTypes().Where(x => x.IsAssignableTo(typeof(ISourceUpdater)) && !x.IsAbstract && !x.IsInterface).Select(x =>
        {
            Console.WriteLine($"Adding updater {x}");
            return (ISourceUpdater)Activator.CreateInstance(x);
        }).ToList();

        static unsafe void Main(string[] args)
        {
            Directory.SetCurrentDirectory(@"..\..\");
            Console.WriteLine($"Working directory is {Directory.GetCurrentDirectory()}");
            Console.WriteLine("Reading upstream source");
            var scriptingApiDir = GetFullPath(Combine("shvdn", "source", "scripting_v3\\"));
            HashSet<string> dirsToCreate = new();
            void Add(string src)
            {
                if (src.StartsWith(scriptingApiDir))
                {
                    var dir = Directory.GetParent(src).FullName.Substring(scriptingApiDir.Length);
                    if (!dirsToCreate.Contains(dir))
                    {
                        dirsToCreate.Add(dir);
                        Console.WriteLine($"Added dir {dir}");
                    }
                }
                var t = File.ReadAllText(src);
                var u = Updaters.Where(x => x.TargetFile == GetFileName(src) || x.TargetFile == null);
                if (u.Any())
                {
                    foreach (var ur in u)
                    {
                        if (ur.TargetFile != null)
                        {
                            Console.WriteLine($"Running updater {ur.GetType()}");
                        }
                        t = ur.Update(t);
                    }
                }
                SrcUpstream.Add(src, t);
            }
            Add(Combine("shvdn", "source", "core", "NativeMemory.cs"));
            foreach (var dir in Directory.GetDirectories(scriptingApiDir, "GTA*", SearchOption.TopDirectoryOnly))
            {
                foreach (var sc in Directory.GetFiles(dir, "*.cs", SearchOption.AllDirectories))
                {
                    if (!SrcExlude.Contains(GetFileName(sc)))
                    {
                        Add(sc);
                        // Console.WriteLine("added source " + sc);
                    }
                }
            }

            var dest = Combine("src", "ScriptHookVDotNetCore", "CodeDom");
            if (Directory.Exists(dest))
            {
                try
                {
                    Directory.Delete(dest, true);
                }
                catch (Exception) { }
            }
            Directory.CreateDirectory(dest);
            foreach (var d in dirsToCreate)
            {
                Directory.CreateDirectory(Combine(dest, d));
            }
            foreach (var s in SrcUpstream)
            {
                var fileDest = GetFileName(s.Key);
                if (s.Key.StartsWith(scriptingApiDir))
                    fileDest = s.Key.Substring(scriptingApiDir.Length);
                File.WriteAllText(Combine(dest, fileDest), s.Value);
            }
        }
    }
}