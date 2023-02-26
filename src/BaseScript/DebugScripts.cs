using GTA.UI;
using GTA;
using static GTA.Native.NativeInvoker;

namespace SHVDN
{
    public class DebugScript : Script
    {
        bool _t = false;
        bool _y = false;
        protected override void OnTick()
        {
            base.OnTick();

            if (_t)
            {
                new TextElement($"{World.GetAllEntities().Length}", new(300, 300), 1).Draw();
            }
            if (_y)
            {
                Logger.Debug($"{World.GetAllEntities().Length}");
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.T) _t = !_t;
            if (e.KeyCode == Keys.Y) _y = !_y;
        }
    }

    [ScriptAttributes(NoDefaultInstance = true)]
    public class DebugScript2 : Script
    {
        bool _t = false;
        const Keys TestKey = Keys.Y;
        protected override void OnTick()
        {
            base.OnTick();

            if (_t)
            {
                var allPeds = World.GetAllPeds();
                var allVeh = World.GetAllVehicles();
                var allProjs = World.GetAllProjectiles();
                new TextElement($"{allPeds.Length}, {allVeh.Length}, {allProjs.Length}", new(400, 400), 1).Draw();
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == TestKey) _t = !_t;
        }
    }

    [ScriptAttributes(NoDefaultInstance = true)]
    public class DebugScript3 : Script
    {
        const Keys TestKey = Keys.O;
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == TestKey)
            {
                START_ENTITY_FIRE(Game.Player.Character);
            }
        }
    }
}
