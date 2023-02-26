using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Updater
{
    internal interface ISourceUpdater
    {
        string TargetFile { get; }
        string Update(ReadOnlySpan<char> src);
    }
    class DlcWeaponDataUpdater : ISourceUpdater
    {
        public string TargetFile => "DlcWeaponData.cs";

        public string Update(ReadOnlySpan<char> src)
        {
            return src.ToString()
                .Replace("internal unsafe struct DlcWeaponComponentData", "public unsafe struct DlcWeaponComponentData")
                .Replace("internal unsafe struct DlcWeaponData", "public unsafe struct DlcWeaponData")
                ;
        }
    }
    class GameUpdator : ISourceUpdater
    {
        public string TargetFile => "Game.cs";

        public string Update(ReadOnlySpan<char> src)
        {
            return src.ToString().Replace("using System.Windows.Forms;", "");
        }
    }
    class TextElementUpdater : ISourceUpdater
    {
        public string TargetFile => "TextElement.cs";

        public string Update(ReadOnlySpan<char> src)
        {
            return src.ToString().Replace(@"SHVDN.NativeFunc.PushLongString(value, (string str) =>
				{
					byte[] data = Encoding.UTF8.GetBytes(str + ""\0"");
					IntPtr next = Marshal.AllocCoTaskMem(data.Length);
					Marshal.Copy(data, 0, next, data.Length);
					_pinnedText.Add(next);
				});", @"SHVDN.NativeFunc.PushLongString(value, str => {
					byte[] data = Encoding.UTF8.GetBytes(str.ToString() + ""\0"");
					IntPtr next = Marshal.AllocCoTaskMem(data.Length);
					Marshal.Copy(data, 0, next, data.Length);
					_pinnedText.Add(next);
				});");
        }
    }
    class GlobalUpdater : ISourceUpdater
    {
        public string TargetFile => null;
        public static HashSet<string> Remove = new()
        {"\t\t[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]\r\n"};
        public static Dictionary<string, string> Fixes = new()
        {
            { "Enum.GetValues(typeof(VehicleModType))","Enum.GetValues<VehicleModType>()"}  ,
            { ".ExecuteTask(task)",".ExecuteTask(ref task)"}  ,
            { "Enum.GetValues(typeof(VehicleDoorIndex))","Enum.GetValues<VehicleDoorIndex>()"}  ,
            { "Enum.GetValues(typeof(PedPropAnchorPosition))","Enum.GetValues<PedPropAnchorPosition>()"}  ,
            { "Enum.GetValues(typeof(PedComponentType))","Enum.GetValues<PedComponentType>()"}  ,
            { "Enum.GetValues(typeof(VehicleNeonLight))","Enum.GetValues<VehicleNeonLight>()"}  ,
            { "T GetHelper<T>(string message)", "T GetHelper<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T > (string message)"}
        };
        public string Update(ReadOnlySpan<char> src)
        {
            var newSource = src.ToString().Replace("\r\n","\n");
            foreach (var item in Remove)
            {
                newSource = newSource.Replace(item, "");
            }

            foreach (var item in Fixes)
            {
                newSource = newSource.Replace(item.Key, item.Value);
            }

            var lines = newSource.Split('\n');
            var sb = new StringBuilder();
            foreach (var line in lines)
            {
                if (line.Contains("[SecurityPermission("))
                    continue;
                var newLine = line;
                if (newLine.Contains(" : IScriptTask"))
                {
                    newLine = newLine.Replace("class", "struct");
                    newLine = newLine.Replace(" sealed ", " ");
                }
                sb.AppendLine(newLine);
            }
            return sb.ToString().Substring(0,sb.Length-2);
        }
    }
}
