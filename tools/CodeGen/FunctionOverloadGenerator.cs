using CodeGen;
using System.Text;

class FunctionOverloadGenerator : Generator
{
    public override string FileName => "Function.Overloads.cs";
    public override bool NeedFormatting => true;

    public override string Generate(NativeData nativeData, GenOptions options)
    {
        var sb = new StringBuilder();
        sb.AppendLine("namespace GTA.Native;\n");
        sb.AppendLine("public static unsafe partial class Function\n{");
        sb.AppendLine("#region Call overloads without return value");
        sb.AppendLine();
        for (int i = 0; i < 40; i++)
        {
            WriteOverload(sb, i, false);
        }
        sb.AppendLine();
        sb.AppendLine("#endregion");
        sb.AppendLine();
        sb.AppendLine();
        sb.AppendLine("#region Call overloads with return value");
        sb.AppendLine();
        for (int i = 0; i < 40; i++)
        {
            WriteOverload(sb, i, true);
        }
        sb.AppendLine();
        sb.AppendLine("#endregion");

        sb.AppendLine("}");
        return sb.ToString();
    }
    public static void WriteOverload(StringBuilder sb, int argCount, bool ret)
    {
        string args = "";
        for (int i = 0; i < argCount; i++)
        {
            args += ", InputArgument arg" + i;
        }
        sb.AppendLine(ret ? $"public static T Call<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T>(Hash hash{args})" : $"public static void Call(Hash hash{args})");
        // var debug = "";
        // var ps = "";
        // for (int i = 0; i < argCount; i++)
        // {
        //     ps += $"{{(ulong)&arg{i}}},";
        // }
        // if (argCount > 0)
        // {
        //     debug = $@"MessageBoxA(0, $""{ps}"", """", 0);";
        // }
        var pArgs = argCount > 0 ? $"&arg0" : "null";
        var execTask = $@"
        var task = new NativeCallTask((ulong)hash, {pArgs}, {argCount});
        Core.ExecuteTask(ref task);
";
        var call = ret ? "return ConvertFromNative<T>(task.Result);" : "";
        var thread = $"{execTask}{call}";


        string push = "";
        for (int i = 0; i < argCount; i++)
        {
            push += $"NativePush64(arg{i});\n";
        }
        var callDirect = ret ? "return ConvertFromNative<T>(NativeCall());" : "NativeCall();";
        var noThread = $"NativeInit((ulong)hash);\n{push}{callDirect}";
        sb.AppendLine($@"{{
        {thread}
}}");
    }
}