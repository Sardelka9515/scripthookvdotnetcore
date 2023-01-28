using GTA.UI;
using GTA;

namespace SHVDN
{
    public class DebugScript : Script
    {
        bool _t = false;
        const Keys TestKey = Keys.T;
        protected override void OnTick()
        {
            base.OnTick();

            if (_t)
            {
                var allPeds = World.GetAllPeds();
                var allVeh = World.GetAllVehicles();
                var allProjs = World.GetAllProjectiles();
                new TextElement($"{allPeds.Length}, {allVeh.Length}, {allProjs.Length}", new(300, 300), 1).Draw();
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == TestKey) _t = !_t;
        }
    }

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
}
