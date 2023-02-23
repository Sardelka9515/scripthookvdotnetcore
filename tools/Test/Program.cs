
using SHVDN;
using System.Diagnostics;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new();
            while (true)
            {
                UnmanagedDictionary<int, int> dic = new(128);
                Dictionary<int, int> dic2 = new(128);
                sw.Restart();
                for (int i = 0; i < 1024; i++)
                {
                    dic.Add(i, i * 20);
                }
                sw.Stop();
                Console.WriteLine("UnmanagedDic insert: " + sw.ElapsedTicks);
                sw.Restart();
                for (int i = 0; i < 1024; i++)
                {
                    dic2.Add(i, i * 20);
                }
                sw.Stop();
                Console.WriteLine("ManagedDic insert: " + sw.ElapsedTicks);

                sw.Restart();
                for (int i = 0; i < 1024; i++)
                {
                    var value = dic[i];
                }
                sw.Stop();
                Console.WriteLine("UnmanagedDic retrive: " + sw.ElapsedTicks);
                sw.Restart();
                for (int i = 0; i < 1024; i++)
                {
                    var value = dic2[i];
                }
                sw.Stop();
                Console.WriteLine("ManagedDic retrive: " + sw.ElapsedTicks);
                Console.ReadLine();
                dic.Free();
                dic2.Clear();
            }
            return;
        }
    }
}