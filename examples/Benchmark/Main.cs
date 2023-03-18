using GTA;
using GTA.Native;

namespace Benchmark
{
    public class Main : Script
    {

        [GTA.ConsoleCommand("Benchmark runtime performance with GetHashKey")]
        public static long BenchmarkHash()
        {
            string blah = "oa8ecynr89pwesr9guiousehngruicmhsiurdhgtipr";
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            long time = 0;
            for (int i = -20; i < 200; i++)
            {
                sw.Restart();
                for (int j = 0; j < 10000; j++)
                {
                    SHVDN.NativeMemory.GetHashKey(blah);
                }
                sw.Stop();
                if (i >= 0)
                    time += sw.ElapsedTicks;
            }
            return time / 200;
        }

        [GTA.ConsoleCommand("Benchmark runtime performance with GetHashKeyASCII")]
        public static long BenchmarkHashASCII()
        {
            string blah = "oa8ecynr89pwesr9guiousehngruicmhsiurdhgtipr";
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            long time = 0;
            for (int i = -20; i < 200; i++)
            {
                sw.Restart();
                for (int j = 0; j < 10000; j++)
                {
                    SHVDN.NativeMemory.GetHashKeyASCII(blah);
                }
                sw.Stop();
                if (i >= 0)
                    time += sw.ElapsedTicks;
            }
            return time / 200;
        }


        [GTA.ConsoleCommand("Benchmark runtime performance with GetHashKeyASCIINoPreConversion")]
        public static long BenchmarkHashASCIINoCov()
        {
            string blah = "oa8ecynr89pwesr9guiousehngruicmhsiurdhgtipr";
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            long time = 0;
            for (int i = -20; i < 200; i++)
            {
                sw.Restart();
                for (int j = 0; j < 10000; j++)
                {
                    SHVDN.NativeMemory.GetHashKeyASCIINoPreConversion(blah);
                }
                sw.Stop();
                if (i >= 0)
                    time += sw.ElapsedTicks;
            }
            return time / 200;
        }

        [GTA.ConsoleCommand("Benchmark runtime performance with GET_HASH_KEY native call")]
        public static long BenchmarkHashNative()
        {
            string blah = "oa8ecynr89pwesr9guiousehngruicmhsiurdhgtipr";
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            long time = 0;
            for (int i = -20; i < 200; i++)
            {
                sw.Restart();
                for (int j = 0; j < 10000; j++)
                {
                    Function.Call<uint>(Hash.GET_HASH_KEY, blah);
                }
                sw.Stop();
                if (i >= 0)
                    time += sw.ElapsedTicks;
            }
            return time / 200;
        }
    }
}