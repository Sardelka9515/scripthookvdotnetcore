global using GTA;
global using GTA.Native;
global using SHVDN;
using GTA.UI;
using System.Drawing;
using System.Runtime.InteropServices;

namespace AirStrike
{
    public class Main : Script
    {
        public Main()
        {
            Tick += Main_Tick;
        }

        private void Main_Tick()
        {
            new TextElement("Boom!", new PointF(Screen.Width / 2, Screen.Height / 2), 1).Draw();
            Marshaller.CleanupStrings();
        }
    }
}
