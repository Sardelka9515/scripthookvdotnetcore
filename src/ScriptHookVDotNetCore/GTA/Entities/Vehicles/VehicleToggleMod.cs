//
// Copyright (C) 2015 crosire & contributors
// License: https://github.com/crosire/scripthookvdotnet#license
//

namespace GTA
{
    public sealed class VehicleToggleMod
    {
        internal VehicleToggleMod(Vehicle owner, VehicleToggleModType modType)
        {
            Vehicle = owner;
            Type = modType;
        }

        public Vehicle Vehicle { get; }

        public VehicleToggleModType Type { get; }

        public void Remove()
        {
            Call(Hash.REMOVE_VEHICLE_MOD, Vehicle.Handle, Type);
        }

        public bool IsInstalled
        {
            get => Call<bool>(Hash.IS_TOGGLE_MOD_ON, Vehicle.Handle, Type);
            set => Call(Hash.TOGGLE_VEHICLE_MOD, Vehicle.Handle, Type, value);
        }

        public string LocalizedTypeName => Call<string>(Hash.GET_MOD_SLOT_NAME, Vehicle.Handle, Type);
    }
}