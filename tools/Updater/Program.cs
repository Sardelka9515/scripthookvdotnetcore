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
            "ScriptAttributes.cs"
        };
        static Dictionary<string, string> SrcUpstream = new();
        static List<ISourceUpdater> Updaters = typeof(ISourceUpdater).Assembly.GetTypes().Where(x => x.IsAssignableTo(typeof(ISourceUpdater)) && !x.IsAbstract && !x.IsInterface).Select(x =>
        {
            Console.WriteLine($"Adding updater {x}");
            return (ISourceUpdater)Activator.CreateInstance(x);
        }).ToList();
        static unsafe void Main(string[] args)
        {
            void Add(string src)
            {
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
            Directory.SetCurrentDirectory(@"..\..\");
            Console.WriteLine($"Working directory is {Directory.GetCurrentDirectory()}");
            Console.WriteLine("Reading upstream source");
            Add(Combine("shvdn", "source", "core", "NativeMemory.cs"));
            foreach (var dir in Directory.GetDirectories(Combine("shvdn", "source", "scripting_v3"), "GTA*", SearchOption.TopDirectoryOnly))
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
                catch (Exception ex) { }
            }
            Directory.CreateDirectory(dest);
            foreach (var s in SrcUpstream)
            {
                File.WriteAllText(Combine(dest, GetFileName(s.Key)), s.Value);
            }
        }
    }
}