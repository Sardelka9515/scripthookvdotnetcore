using GTA;
using GTA.UI;
using SHVDN;
using static GTA.Native.NativeInvoker;
namespace ControllerExample
{
    public class Main : Script
    {
        readonly TextElement msg = new("Type UNLOAD in cheat console to unload me", new(200, 200), 1);
        readonly uint hash = NativeMemory.GetHashKey("UNLOAD");
        protected override void OnTick()
        {
            base.OnTick();
            msg.Draw();
            if (HAS_PC_CHEAT_WITH_HASH_BEEN_ACTIVATED(hash))
                Core.RuntimeController.RequestUnload(Core.CurrentDirectory);
        }
    }
}