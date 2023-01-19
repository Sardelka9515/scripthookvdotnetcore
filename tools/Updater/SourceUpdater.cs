using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public string Update(ReadOnlySpan<char> src)
        {
            return src.ToString();
            // return src.ToString().Replace("NativeMemory.VehicleFlag2", "NativeMemory.Types.VehicleFlag2").Replace("NativeMemory.VehicleFlag1", "NativeMemory.Types.VehicleFlag1");
        }
    }
}
