using System.Drawing;
using System.Runtime.InteropServices;
using SHVDN;
using GTA;
using GTA.Native;
using static GTA.Native.Function;
using System.Reflection.Metadata;
using System.Diagnostics;
using GTA.UI;

namespace SHVDN;

internal unsafe class BaseScript : Script
{
    public BaseScript()
    {
        Tick += OnTick;
        Start += OnStart;
        KeyDown += OnKeyDown;
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
    }

    protected override void OnStart()
    {
        base.OnStart();
        while (Game.IsLoading) Yield();
        Notification.Show("Started");
    }
    Stopwatch sw = new Stopwatch();
    protected override void OnTick()
    {
        base.OnTick();
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
    TextElement _textE = new TextElement("blah", default, 0.5f);
    private void DrawText(float x, float y, string text, Color color, float scale = 0.5f)
    {
        _textE.Position = new(x, y);
        _textE.Caption = text;
        _textE.Color=color;
        _textE.Scale = scale;
        _textE.Draw();
    }
}
