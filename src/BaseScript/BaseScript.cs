using System.Diagnostics;
using System.Drawing;
using GTA;
using GTA.Native;
using GTA.UI;
using static GTA.Native.Function;

namespace SHVDN;

internal class BaseScript : Script
{
    private readonly TextElement _textE = new("blah", default, 0.5f);
    private readonly Stopwatch _sw = new();

    protected override void OnStart()
    {
        base.OnStart();
        while (Game.IsLoading) Yield();
        Notification.Show("Started");
    }

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

        _sw.Restart();
        var position = P.Position;
        _sw.Stop();
        DrawText(300, 250, $"pos:{position}, time{_sw.ElapsedTicks}", Color.CornflowerBlue);
        CleanupStrings();
    }

    private void DrawText(float x, float y, string text, Color color, float scale = 0.5f)
    {
        _textE.Position = new PointF(x, y);
        _textE.Caption = text;
        _textE.Color = color;
        _textE.Scale = scale;
        _textE.Draw();
    }
}