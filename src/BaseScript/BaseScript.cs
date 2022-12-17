using System.Drawing;
using System.Runtime.InteropServices;
using SHVDN;
using GTA;
using GTA.Native;
using static GTA.Native.Function;
using System.Reflection.Metadata;

namespace SHVDN;

internal unsafe class BaseScript : Script
{
    public BaseScript(IntPtr module):base(module)
    {
        Tick += OnTick;
        Start += OnStart;
        KeyDown += OnKeyDown;
    }

    private void OnKeyDown(KeyEventArgs e)
    {
        var P = Game.Player.Character;
        var V = P.CurrentVehicle;
        if (e.KeyCode == Keys.U)
        {
            if (V != null)
            {
                P.Task.LeaveVehicle(LeaveVehicleFlags.BailOut);
            }
        }
        else if (e.KeyCode == Keys.T)
        {
            P.Task.LeaveVehicle();
        }
    }

    private void OnStart()
    {
        GTA.UI.Notification.Show("Started");
    }

    private void OnTick()
    {
        var player = Call<Ped>(Hash.GET_PLAYER_PED, 0);
        var vehicle = player?.CurrentVehicle;
        if(vehicle != null)
        {
            var stuff = Call<string>(Hash.GET_VEHICLE_NUMBER_PLATE_TEXT, vehicle);
            DrawText(300, 200, $"player:{player.Handle}, veh:{vehicle.Handle}, {stuff}", Color.CornflowerBlue);
        }
        CleanupStrings();
    }
    private static void DrawText(float x, float y, string text, Color color, float scaleX = 0.5f,
        float scaleY = 0.5f)
    {
        Invoke(0x66E0276CC5F6B9DA /*SET_TEXT_FONT*/, 0); // Chalet London :>
        Invoke(0x07C837F9A01C34C9 /*SET_TEXT_SCALE*/, scaleX, scaleY);
        Invoke(0xBE6B23FFA53FB442 /*SET_TEXT_COLOUR*/, color.R, color.G, color.B, color.A);
        Invoke(0x25FBB336DF1804CB /*BEGIN_TEXT_COMMAND_DISPLAY_TEXT*/, CellEmailBcon);
        PushLongString(text);
        Invoke(0xCD015E5BB0D96A57 /*END_TEXT_COMMAND_DISPLAY_TEXT*/, x / BASE_WIDTH, y / BASE_HEIGHT);
    }
}
