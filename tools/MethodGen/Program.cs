#define FUNC
public class Program
{
    static StreamWriter sw;
    public static void Main()
    {
#if FUNC
        sw = new("Function.cs");
        sw.WriteLine("#region Call overloads without return value");
        sw.WriteLine();
        for (int i = 0; i < 25; i++)
        {
            Write(i, false);
        }
        sw.WriteLine();
        sw.WriteLine("#endregion");
        sw.WriteLine();
        sw.WriteLine();
        sw.WriteLine("#region Call overloads with return value");
        sw.WriteLine();
        for (int i = 0; i < 25; i++)
        {
            Write(i, true);
        }
        sw.WriteLine();
        sw.WriteLine("#endregion");
        sw.Dispose();
#endif
    }
    public static void Write(int argCount,bool ret)
    {
        string args = "";
        for (int i = 0; i < argCount; i++)
        {
            args += ", InputArgument arg" + i;
        }
        sw.WriteLine(ret?$"public static T Call<T>(Hash hash{args})": $"public static void Call(Hash hash{args})");
        string push = "";
        for (int i = 0; i < argCount; i++)
        {
            push += $"NativePush64(arg{i}.Value);\n";
        }
        var call = ret ? "return ConvertFromNative<T>(NativeCall());" : "NativeCall();";
        sw.WriteLine($"{{\nNativeInit((ulong)hash);\n{push}{call}\n}}");
    }
}