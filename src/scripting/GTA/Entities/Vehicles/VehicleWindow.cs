//
// Copyright (C) 2015 crosire & contributors
// License: https://github.com/crosire/scripthookvdotnet#license
//

namespace GTA
{
    public sealed class VehicleWindow
    {
        internal VehicleWindow(Vehicle owner, VehicleWindowIndex index)
        {
            Vehicle = owner;
            Index = index;
        }

        public Vehicle Vehicle { get; }

        public VehicleWindowIndex Index { get; }

        public bool IsIntact => Call<bool>(Hash.IS_VEHICLE_WINDOW_INTACT, Vehicle.Handle, Index);

        public void Smash()
        {
            Call(Hash.SMASH_VEHICLE_WINDOW, Vehicle.Handle, Index);
        }

        public void Repair()
        {
            Call(Hash.FIX_VEHICLE_WINDOW, Vehicle.Handle, Index);
        }

        public void Remove()
        {
            Call(Hash.REMOVE_VEHICLE_WINDOW, Vehicle.Handle, Index);
        }

        public void RollUp()
        {
            Call(Hash.ROLL_UP_WINDOW, Vehicle.Handle, Index);
        }

        public void RollDown()
        {
            Call(Hash.ROLL_DOWN_WINDOW, Vehicle.Handle, Index);
        }
    }
}