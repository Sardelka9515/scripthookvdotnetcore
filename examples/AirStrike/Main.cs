using GTA;
using GTA.UI;
using GTA.Math;
using System.Drawing;
using System.Runtime.InteropServices;
using System;

namespace AirStrike
{
    public class Main : Script
    {
        public Main()
        {
            Started += Main_Start;
            KeyDown += Main_KeyDown;
        }

        private void Main_KeyDown(KeyEventArgs obj)
        {
            if (obj.KeyCode == Keys.B)
            {
                var rand = new Random();
                var source = Game.Player.Character.Position + 200 * Vector3.WorldUp;
                var count = rand.Next(5, 10);
                var target = GetCamTarget();
                if (target == default) return;
                var asset = new WeaponAsset(WeaponHash.RPG);
                asset.Request(500);
                var n = Notification.Show("Incoming!");
                for (int i = 0; i < count; i++)
                {
                    World.ShootBullet(source, target, Game.Player.Character, asset, 0);
                    Wait((ulong)rand.Next(200, 1000));
                }
                asset.MarkAsNoLongerNeeded();
                Notification.Hide(n);
            }
        }

        private void Main_Start()
        {
            while (Game.IsLoading) { Yield(); }
            Notification.Show("Press B to launch an airstrike at the position you're aiming at");
        }
        public static Vector3 GetCamTarget()
        {

            Vector3 target3D = GameplayCamera.Position + GameplayCamera.ForwardVector * 1000;
            Vector3 source3D = GameplayCamera.Position;
            var player = Game.Player.Character;
            Entity ignoreEntity = player.IsInVehicle() ? player.CurrentVehicle : player;
            RaycastResult raycastResults = World.Raycast(source3D,
                target3D,
                IntersectFlags.Everything,
                ignoreEntity);

            if (raycastResults.DidHit)
            {
                return raycastResults.HitPosition;
            }

            return default;
        }

    }
}
