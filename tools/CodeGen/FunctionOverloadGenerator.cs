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
        string alloc = argCount == 0 ? "" : $"var pArgs = stackalloc InputArgument[{argCount}];\n";
        string copy = "";
        for (int i = 0; i < argCount; i++)
        {
            copy += $"pArgs[{i}] = arg{i};\n";
        }
        var execTask = $@"
        var task = new NativeCallTask()
        {{
            Hash = (ulong)hash,
            PtrArgs = {(argCount == 0 ? "null" : "(ulong*)pArgs")},
            ArgsCount = {argCount},
        }};
        Core.ExecuteTask(task);
";
        var call = ret ? "return ConvertFromNative<T>(task.Result);" : "";
        sb.AppendLine($"{{\n{alloc}{copy}{execTask}{call}\n}}");
    }
}