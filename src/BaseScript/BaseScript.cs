using System.Drawing;
using System.Runtime.InteropServices;
using SHVDN;
using GTA;
using GTA.Native;
using static GTA.Native.Function;
using System.Reflection.Metadata;
using System.Diagnostics;

namespace SHVDN;

internal unsafe class BaseScript : Script
{
    public BaseScript(IntPtr module) : base(module)
    {
        Tick += OnTick;
        Start += OnStart;
        KeyDown += OnKeyDown;
    }

    private void OnKeyDown(KeyEventArgs e)
    {
    }

    private void OnStart()
    {
        GTA.UI.Notification.Show("Started");
    }
    Stopwatch sw = new Stopwatch();
    private void OnTick()
    {
        var P = Call<Ped>(Hash.GET_PLAYER_PED, 0);
        var V = P?.CurrentVehicle;
        if (V != null)
        {
            var stuff = Call<string>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT, V);
            DrawText(300, 200, $"player:{P.Handle}, veh:{V.Handle}, {stuff}", Color.CornflowerBlue);
        }
        sw.Restart();
        var position = P.Position;
        sw.Stop();
        DrawText(300, 250, $"pos:{position}, time{sw.ElapsedTicks}", Color.CornflowerBlue);
        CleanupStrings();
    }
    private static void DrawText(float x, float y, string text, Color color, float scaleX = 0.5f,
        float scaleY = 0.5f)
    {
        Call((Hash)0x66E0276CC5F6B9DA /*SET_TEXT_FONT*/, 0); // Chalet London :>
        Call((Hash)0x07C837F9A01C34C9 /*SET_TEXT_SCALE*/, scaleX, scaleY);
        Call((Hash)0xBE6B23FFA53FB442 /*SET_TEXT_COLOUR*/, color.R, color.G, color.B, color.A);
        Call((Hash)0x25FBB336DF1804CB /*BEGIN_TEXT_COMMAND_DISPLAY_TEXT*/, CellEmailBcon);
        PushLongString(text);
        Call((Hash)0xCD015E5BB0D96A57 /*END_TEXT_COMMAND_DISPLAY_TEXT*/, x / BASE_WIDTH, y / BASE_HEIGHT);
    }
}
