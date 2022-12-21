//
// Copyright (C) 2015 crosire & contributors
// License: https://github.com/crosire/scripthookvdotnet#license
//

using GTA.Math;

namespace GTA
{
    public sealed class Vehicle : Entity
    {
        #region Fields

        VehicleDoorCollection _doors;
        VehicleModCollection _mods;
        VehicleWheelCollection _wheels;
        VehicleWindowCollection _windows;

        #endregion

        internal Vehicle(int handle) : base(handle)
        {
        }

        /// <summary>
        /// Repair all damage to this <see cref="Vehicle"/> instantaneously.
        /// </summary>
        public void Repair()
        {
            Call(Hash.SET_VEHICLE_FIXED, Handle);
            IsConsideredDestroyed = false;
        }

        /// <summary>
        /// Explode this <see cref="Vehicle"/> instantaneously.
        /// </summary>
        public void Explode()
        {
            Call(Hash.EXPLODE_VEHICLE, Handle, true, false);
        }

        /// <summary>
        /// Determines if this <see cref="Vehicle"/> exists.
        /// You should ensure <see cref="Vehicle"/>s still exist before manipulating them or getting some values for them on every tick, since some native functions may crash the game if invalid entity handles are passed.
        /// </summary>
        /// <returns><see langword="true" /> if this <see cref="Vehicle"/> exists; otherwise, <see langword="false" /></returns>
        public new bool Exists()
        {
            return EntityType == EntityType.Vehicle;
        }

        #region Styling

        public bool IsConvertible => Call<bool>(Hash.IS_VEHICLE_A_CONVERTIBLE, Handle, 0);
        public bool IsBig => Call<bool>(Hash.IS_BIG_VEHICLE, Handle);

        public bool HasBulletProofGlass =>
            NativeMemory.HasVehicleFlag(Model.Hash, NativeMemory.VehicleFlag2.HasBulletProofGlass);

        public bool HasLowriderHydraulics => Game.Version >= GameVersion.v1_0_505_2_Steam &&
                                             NativeMemory.HasVehicleFlag(Model.Hash,
                                                 NativeMemory.VehicleFlag2.HasLowriderHydraulics);

        public bool HasDonkHydraulics => Game.Version >= GameVersion.v1_0_505_2_Steam &&
                                         NativeMemory.HasVehicleFlag(Model.Hash,
                                             NativeMemory.VehicleFlag2.HasLowriderDonkHydraulics);

        public bool HasParachute => Game.Version >= GameVersion.v1_0_505_2_Steam &&
                                    Call<bool>(Hash.GET_VEHICLE_HAS_PARACHUTE, Handle);

        public bool HasRocketBoost => Game.Version >= GameVersion.v1_0_944_2_Steam &&
                                      Call<bool>(Hash.GET_HAS_ROCKET_BOOST, Handle);

        public bool IsParachuteDeployed => Game.Version >= GameVersion.v1_0_1011_1_Steam &&
                                           Call<bool>(Hash.IS_VEHICLE_PARACHUTE_DEPLOYED, Handle);

        public bool IsRocketBoostActive
        {
            get => Game.Version >= GameVersion.v1_0_944_2_Steam && Call<bool>(Hash.IS_ROCKET_BOOST_ACTIVE, Handle);
            set
            {
                if (Game.Version < GameVersion.v1_0_944_2_Steam)
                    throw new GameVersionNotSupportedException(GameVersion.v1_0_944_2_Steam, nameof(Vehicle),
                        nameof(IsRocketBoostActive));
                Call(Hash.SET_ROCKET_BOOST_ACTIVE, Handle, value);
            }
        }


        public float DirtLevel
        {
            get => Call<float>(Hash.GET_VEHICLE_DIRT_LEVEL, Handle);
            set => Call(Hash.SET_VEHICLE_DIRT_LEVEL, Handle, value);
        }

        public VehicleModCollection Mods => _mods ?? (_mods = new VehicleModCollection(this));

        public VehicleWheelCollection Wheels => _wheels ?? (_wheels = new VehicleWheelCollection(this));

        public VehicleWindowCollection Windows => _windows ?? (_windows = new VehicleWindowCollection(this));

        public void Wash()
        {
            DirtLevel = 0f;
        }

        public bool IsExtraOn(int extra)
        {
            return Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, Handle, extra);
        }

        public bool ExtraExists(int extra)
        {
            return Call<bool>(Hash.DOES_EXTRA_EXIST, Handle, extra);
        }

        public void ToggleExtra(int extra, bool toggle)
        {
            Call(Hash.SET_VEHICLE_EXTRA, Handle, extra, !toggle);
        }

        #endregion

        #region Configuration

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is a regular automobile.
        /// </summary>
        public bool IsRegularAutomobile => Type == VehicleType.Automobile;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is an amphibious automobile.
        /// </summary>
        public bool IsAmphibiousAutomobile => Type == VehicleType.AmphibiousAutomobile;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is a submarine car.
        /// </summary>
        public bool IsSubmarineCar => Type == VehicleType.SubmarineCar;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is an automobile.
        /// </summary>
        public bool IsAutomobile
        {
            get
            {
                var vehicleType = Type;
                return (vehicleType == VehicleType.Automobile || vehicleType == VehicleType.AmphibiousAutomobile ||
                        vehicleType == VehicleType.SubmarineCar);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is a regular quad bike.
        /// </summary>
        public bool IsRegularQuadBike => Type == VehicleType.QuadBike;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is an amphibious quad bike.
        /// </summary>
        public bool IsAmphibiousQuadBike => Type == VehicleType.AmphibiousQuadBike;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is a quad bike.
        /// </summary>
        public bool IsQuadBike
        {
            get
            {
                var vehicleType = Type;
                return (vehicleType == VehicleType.QuadBike || vehicleType == VehicleType.AmphibiousQuadBike);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is an amphibious vehicle.
        /// </summary>
        public bool IsAmphibious
        {
            get
            {
                var vehicleType = Type;
                return (vehicleType == VehicleType.AmphibiousAutomobile ||
                        vehicleType == VehicleType.AmphibiousQuadBike);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is a trailer.
        /// </summary>
        public bool IsTrailer => Type == VehicleType.Trailer;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is a plane.
        /// </summary>
        public bool IsPlane => Type == VehicleType.Plane;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is a helicopter.
        /// </summary>
        public bool IsHelicopter => Type == VehicleType.Helicopter;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is a helicopter.
        /// </summary>
        public bool IsBlimp => Type == VehicleType.Blimp;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is an aircraft.
        /// </summary>
        public bool IsAircraft
        {
            get
            {
                var vehicleType = Type;
                return (vehicleType == VehicleType.Plane || vehicleType == VehicleType.Helicopter ||
                        vehicleType == VehicleType.Blimp);
            }
        }

        private bool IsHeliOrBlimp
        {
            get
            {
                var vehicleType = Type;
                return ((uint)vehicleType - 8) <= 1;
            }
        }

        private bool IsRotaryWingAircraft
        {
            get
            {
                var vehicleType = Type;
                return ((uint)vehicleType - 8) <= 2;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is a motorcycle.
        /// </summary>
        public bool IsMotorcycle => Type == VehicleType.Motorcycle;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is a bicycle.
        /// </summary>
        public bool IsBicycle => Type == VehicleType.Bicycle;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is a bike.
        /// </summary>
        public bool IsBike
        {
            get
            {
                var vehicleType = Type;
                return (vehicleType == VehicleType.Motorcycle || vehicleType == VehicleType.Bicycle);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is a boat.
        /// </summary>
        public bool IsBoat => Type == VehicleType.Motorcycle;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is a train.
        /// </summary>
        public bool IsTrain => Type == VehicleType.Train;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is a submarine.
        /// </summary>
        public bool IsSubmarine => Type == VehicleType.Submarine;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Vehicle"/> can pretend it has the same <see cref="Ped"/>s.
        /// Set to <see langword="false"/> to prevent this <see cref="Vehicle"/> from creating new <see cref="Ped"/>s as its occupants.
        /// </summary>
        /// <remarks>
        /// <see cref="Vehicle"/>s do not pretend occupants regardless of this value if <see cref="Entity.PopulationType"/> is set to
        /// <see cref="EntityPopulationType.Permanent"/> or <see cref="EntityPopulationType.Mission"/>.
        /// </remarks>
        public bool CanPretendOccupants
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.DisablePretendOccupantOffset == 0)
                {
                    return false;
                }

                return !NativeMemory.IsBitSet(address + NativeMemory.DisablePretendOccupantOffset, 7);
            }
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.DisablePretendOccupantOffset == 0)
                {
                    return;
                }

                // SET_DISABLE_PRETEND_OCCUPANTS changes the value only if the population type is set to 6 or 7, so change the value manually
                if (value)
                {
                    NativeMemory.ClearBit(address + NativeMemory.DisablePretendOccupantOffset, 7);
                }
                else
                {
                    NativeMemory.SetBit(address + NativeMemory.DisablePretendOccupantOffset, 7);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Vehicle"/> was stolen.
        /// </summary>
        public bool IsStolen
        {
            get => Call<bool>(Hash.IS_VEHICLE_STOLEN, Handle);
            set => Call(Hash.SET_VEHICLE_IS_STOLEN, Handle, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Vehicle"/> is wanted by the police.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this <see cref="Vehicle"/> is wanted by the police; otherwise, <see langword="false" />.
        /// </value>
        public bool IsWanted
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.IsWantedOffset == 0)
                {
                    return false;
                }

                return NativeMemory.IsBitSet(address + NativeMemory.IsWantedOffset, 3);
            }
            set => Call(Hash.SET_VEHICLE_IS_WANTED, Handle, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Vehicle"/> needs to be hotwired to start.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this <see cref="Vehicle"/> needs to be hotwired to start; otherwise, <see langword="false" />.
        /// </value>
        public bool NeedsToBeHotwired
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.NeedsToBeHotwiredOffset == 0)
                {
                    return false;
                }

                return NativeMemory.IsBitSet(address + NativeMemory.NeedsToBeHotwiredOffset, 2);
            }
            set => Call(Hash.SET_VEHICLE_NEEDS_TO_BE_HOTWIRED, Handle, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Vehicle"/> was previously owned by a <see cref="Player"/>.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if this <see cref="Vehicle"/> was previously owned by a <see cref="Player"/>; otherwise, <see langword="false" />.
        /// </value>
        public bool PreviouslyOwnedByPlayer
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.PreviouslyOwnedByPlayerOffset == 0)
                {
                    return false;
                }

                return NativeMemory.IsBitSet(address + NativeMemory.PreviouslyOwnedByPlayerOffset, 1);
            }
            set => Call(Hash.SET_VEHICLE_HAS_BEEN_OWNED_BY_PLAYER, Handle, value);
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> allows <see cref="Ped"/>s to rappel.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if this <see cref="Vehicle"/> allows <see cref="Ped"/>s to rappel; otherwise, <see langword="false" />.
        /// </value>
        public bool AllowRappel => Game.Version >= GameVersion.v1_0_757_2_Steam
            ? Call<bool>(Hash.DOES_VEHICLE_ALLOW_RAPPEL, Handle)
            : NativeMemory.HasVehicleFlag(Model.Hash, NativeMemory.VehicleFlag1.AllowsRappel);

        /// <summary>
        /// Gets a value indicating whether <see cref="Ped"/>s can stand on this <see cref="Vehicle"/> regardless of <see cref="Vehicle"/>s speed.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if <see cref="Ped"/>s can stand on this <see cref="Vehicle"/> regardless of <see cref="Vehicle"/>s speed; otherwise, <see langword="false" />.
        /// </value>
        public bool CanStandOnTop => NativeMemory.HasVehicleFlag(Model.Hash, NativeMemory.VehicleFlag1.CanStandOnTop);

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> can jump.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if this <see cref="Vehicle"/> can jump; otherwise, <see langword="false" />.
        /// </value>
        public bool CanJump =>
            Game.Version >= GameVersion.v1_0_944_2_Steam && Call<bool>(Hash.GET_CAR_HAS_JUMP, Handle);

        /// <summary>
        /// Gets the display name of this <see cref="Vehicle"/>.
        /// <remarks>Use <see cref="Game.GetLocalizedString(string)"/> to get the localized name.</remarks>
        /// </summary>
        public string DisplayName => GetModelDisplayName(base.Model);

        /// <summary>
        /// Gets the localized name of this <see cref="Vehicle"/>
        /// </summary>
        public string LocalizedName => Game.GetLocalizedString(DisplayName);

        /// <summary>
        /// Gets the display name of this <see cref="Vehicle"/>s <see cref="VehicleClass"/>.
        /// <remarks>Use <see cref="Game.GetLocalizedString(string)"/> to get the localized class name.</remarks>
        /// </summary>
        public string ClassDisplayName => GetClassDisplayName(ClassType);

        /// <summary>
        /// Gets the localized name of this <see cref="Vehicle"/>s <see cref="VehicleClass"/>.
        /// </summary>
        public string ClassLocalizedName => Game.GetLocalizedString(ClassDisplayName);

        /// <summary>
        /// Gets the class of this <see cref="Vehicle"/>.
        /// </summary>
        public VehicleClass ClassType => Call<VehicleClass>(Hash.GET_VEHICLE_CLASS, Handle);

        /// <summary>
        /// Gets the type of this <see cref="Vehicle"/>.
        /// </summary>
        public VehicleType Type
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.VehicleTypeOffsetInCVehicle == 0)
                {
                    return VehicleType.None;
                }

                return (VehicleType)NativeMemory.ReadInt32(address + NativeMemory.VehicleTypeOffsetInCVehicle);
            }
        }

        public float LodMultiplier
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.VehicleLodMultiplierOffset == 0)
                {
                    return 0.0f;
                }

                return NativeMemory.ReadFloat(address + NativeMemory.VehicleLodMultiplierOffset);
            }
            set => Call(Hash.SET_VEHICLE_LOD_MULTIPLIER, Handle, value);
        }

        public HandlingData HandlingData
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.HandlingDataOffset == 0)
                {
                    return new HandlingData(IntPtr.Zero);
                }

                return new HandlingData(NativeMemory.ReadAddress(MemoryAddress + NativeMemory.HandlingDataOffset));
            }
        }

        #endregion

        #region Health

        /// <summary>
        /// Gets or sets this <see cref="Vehicle"/>s body health.
        /// </summary>
        public float BodyHealth
        {
            get => Call<float>(Hash.GET_VEHICLE_BODY_HEALTH, Handle);
            set => Call(Hash.SET_VEHICLE_BODY_HEALTH, Handle, value);
        }

        /// <summary>
        /// Gets or sets this <see cref="Vehicle"/> engine health.
        /// </summary>
        public float EngineHealth
        {
            get => Call<float>(Hash.GET_VEHICLE_ENGINE_HEALTH, Handle);
            set => Call(Hash.SET_VEHICLE_ENGINE_HEALTH, Handle, value);
        }

        /// <summary>
        /// Gets or sets this <see cref="Vehicle"/> petrol tank health.
        /// </summary>
        public float PetrolTankHealth
        {
            get => Call<float>(Hash.GET_VEHICLE_PETROL_TANK_HEALTH, Handle);
            set => Call(Hash.SET_VEHICLE_PETROL_TANK_HEALTH, Handle, value);
        }

        /// <summary>
        /// Gets or sets the engine health for this heli.
        /// </summary>
        public float HeliEngineHealth
        {
            get
            {
                if (!IsHeliOrBlimp)
                {
                    return 0.0f;
                }

                return Call<float>(Hash.GET_HELI_TAIL_BOOM_HEALTH, Handle);
            }
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.HeliTailBoomHealthOffset == 0 || !IsHeliOrBlimp)
                {
                    return;
                }

                NativeMemory.WriteFloat(address + NativeMemory.HeliTailBoomHealthOffset, value);
            }
        }

        /// <summary>
        /// Gets or sets the main rotor health for this heli.
        /// </summary>
        public float HeliMainRotorHealth
        {
            get
            {
                if (!IsHeliOrBlimp)
                {
                    return 0.0f;
                }

                return Call<float>(Hash.GET_HELI_MAIN_ROTOR_HEALTH, Handle);
            }
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.HeliMainRotorHealthOffset == 0 || !IsHeliOrBlimp)
                {
                    return;
                }

                NativeMemory.WriteFloat(address + NativeMemory.HeliMainRotorHealthOffset, value);
            }
        }

        /// <summary>
        /// Gets or sets the tail rotor health for this heli.
        /// </summary>
        public float HeliTailRotorHealth
        {
            get
            {
                if (!IsHeliOrBlimp)
                {
                    return 0.0f;
                }

                return Call<float>(Hash.GET_HELI_TAIL_ROTOR_HEALTH, Handle);
            }
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.HeliTailRotorHealthOffset == 0 || !IsHeliOrBlimp)
                {
                    return;
                }

                NativeMemory.WriteFloat(address + NativeMemory.HeliTailRotorHealthOffset, value);
            }
        }

        #endregion

        #region Radio

        /// <summary>
        /// Turns this <see cref="Vehicle"/>s radio on or off
        /// </summary>
        public bool IsRadioEnabled
        {
            set => Call(Hash.SET_VEHICLE_RADIO_ENABLED, Handle, value);
        }

        /// <summary>
        /// Sets this <see cref="Vehicle"/>s radio station.
        /// </summary>
        public RadioStation RadioStation
        {
            set
            {
                if (value == RadioStation.RadioOff)
                {
                    Call(Hash.SET_VEH_RADIO_STATION, Handle, "OFF");
                }
                else if (Enum.IsDefined(typeof(RadioStation), value))
                {
                    Call(Hash.SET_VEH_RADIO_STATION, Handle, Game.radioNames[(int)value]);
                }
            }
        }

        #endregion

        #region Engine

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Vehicle"/>s engine is running.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if this <see cref="Vehicle"/>s engine is running; otherwise, <see langword="false" />.
        /// </value>
        public bool IsEngineRunning
        {
            get => Call<bool>(Hash.GET_IS_VEHICLE_ENGINE_RUNNING, Handle);
            set => Call(Hash.SET_VEHICLE_ENGINE_ON, Handle, value, true);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Vehicle"/>s engine is currently starting.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if this <see cref="Vehicle"/>s engine is starting; otherwise, <see langword="false" />.
        /// </value>
        public bool IsEngineStarting
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.IsEngineStartingOffset == 0)
                {
                    return false;
                }

                return NativeMemory.IsBitSet(address + NativeMemory.IsEngineStartingOffset, 5);
            }
        }

        public bool CanEngineDegrade
        {
            set => Call(Hash.SET_VEHICLE_ENGINE_CAN_DEGRADE, Handle, value);
        }

        /// <summary>
        /// Gets the engine temperature of this <see cref="Vehicle"/>.
        /// </summary>
        public float EngineTemperature
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.EngineTemperatureOffset == 0)
                {
                    return 0.0f;
                }

                return NativeMemory.ReadFloat(address + NativeMemory.EngineTemperatureOffset);
            }
        }

        public float EnginePowerMultiplier
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.EngineTemperatureOffset == 0)
                {
                    return 0.0f;
                }

                return NativeMemory.ReadFloat(address + NativeMemory.EnginePowerMultiplierOffset);
            }
            set => Call(Hash.MODIFY_VEHICLE_TOP_SPEED, Handle, value);
        }

        public float EngineTorqueMultiplier
        {
            set => Call(Hash.SET_VEHICLE_CHEAT_POWER_INCREASE, Handle, value);
        }

        /// <summary>
        /// Gets or sets this <see cref="Vehicle"/> oil level.
        /// If this value is above zero, this value decreases instead of <see cref="EngineHealth"/> when the engine emits black smoke.
        /// </summary>
        public float OilLevel
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.OilLevelOffset == 0)
                {
                    return 0.0f;
                }

                return NativeMemory.ReadFloat(address + NativeMemory.OilLevelOffset);
            }
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.OilLevelOffset == 0)
                {
                    return;
                }

                NativeMemory.WriteFloat(address + NativeMemory.OilLevelOffset, value);
            }
        }

        /// <summary>
        /// Gets the oil volume of this <see cref="Vehicle"/>.
        /// </summary>
        public float OilVolume
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero)
                {
                    return 0.0f;
                }

                return HandlingData.OilVolume;
            }
        }

        /// <summary>
        /// Gets or sets this <see cref="Vehicle"/> fuel level.
        /// </summary>
        public float FuelLevel
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.FuelLevelOffset == 0)
                {
                    return 0.0f;
                }

                return NativeMemory.ReadFloat(address + NativeMemory.FuelLevelOffset);
            }
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.FuelLevelOffset == 0)
                {
                    return;
                }

                NativeMemory.WriteFloat(address + NativeMemory.FuelLevelOffset, value);
            }
        }

        /// <summary>
        /// Gets the petrol tank volume of this <see cref="Vehicle"/>.
        /// </summary>
        public float PetrolTankVolume
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero)
                {
                    return 0.0f;
                }

                return HandlingData.PetrolTankVolume;
            }
        }

        #endregion

        #region Performance & Driving

        /// <summary>
        /// Gets or sets the gears value of this <see cref="Vehicle"/>.
        /// </summary>
        [Obsolete(
            "Vehicle.Gears is obsolete, please use Vehicle.HighGear for the high gear value and Vehicle.CurrentGear for the current gear value instead.")]
        public int Gears
        {
            get => HighGear;
            set => HighGear = value;
        }

        public int HighGear
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.HighGearOffset == 0)
                {
                    return 0;
                }

                return NativeMemory.ReadByte(address + NativeMemory.HighGearOffset);
            }
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.HighGearOffset == 0)
                {
                    return;
                }

                if (Game.Version >= GameVersion.v1_0_1604_0_Steam)
                {
                    if (value > 10)
                    {
                        throw new ArgumentOutOfRangeException("value", "Values must be between 0 and 10, inclusive.");
                    }
                }
                else if (value > 7)
                {
                    throw new ArgumentOutOfRangeException("value", "Values must be between 0 and 7, inclusive.");
                }

                NativeMemory.WriteByte(address + NativeMemory.HighGearOffset, (byte)value);
            }
        }

        /// <summary>
        /// Gets or sets the next gear value of this <see cref="Vehicle"/>.
        /// </summary>
        public int NextGear
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.NextGearOffset == 0)
                {
                    return 0;
                }

                return NativeMemory.ReadByte(address + NativeMemory.NextGearOffset);
            }
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.NextGearOffset == 0)
                {
                    return;
                }

                NativeMemory.WriteByte(address + NativeMemory.NextGearOffset, (byte)value);
            }
        }

        /// <summary>
        /// Gets or sets the current gear this <see cref="Vehicle"/> is using.
        /// </summary>
        public int CurrentGear
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.GearOffset == 0)
                {
                    return 0;
                }

                return NativeMemory.ReadByte(address + NativeMemory.GearOffset);
            }
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.GearOffset == 0)
                {
                    return;
                }

                NativeMemory.WriteByte(address + NativeMemory.GearOffset, (byte)value);
            }
        }

        /// <summary>
        /// Gets or sets the current turbo value of this <see cref="Vehicle"/>.
        /// </summary>
        public float Turbo
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.TurboOffset == 0)
                {
                    return 0.0f;
                }

                return NativeMemory.ReadFloat(address + NativeMemory.TurboOffset);
            }
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.TurboOffset == 0)
                {
                    return;
                }

                NativeMemory.WriteFloat(address + NativeMemory.TurboOffset, value);
            }
        }

        /// <summary>
        /// Gets or sets the current clutch of this <see cref="Vehicle"/>.
        /// </summary>
        public float Clutch
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.ClutchOffset == 0)
                {
                    return 0.0f;
                }

                return NativeMemory.ReadFloat(address + NativeMemory.ClutchOffset);
            }
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.ClutchOffset == 0)
                {
                    return;
                }

                NativeMemory.WriteFloat(address + NativeMemory.ClutchOffset, value);
            }
        }

        /// <summary>
        /// Gets or sets the current throttle of this <see cref="Vehicle"/>.
        /// </summary>
        public float Throttle
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.AccelerationOffset == 0)
                {
                    return 0.0f;
                }

                return NativeMemory.ReadFloat(address + NativeMemory.AccelerationOffset);
            }
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.AccelerationOffset == 0)
                {
                    return;
                }

                NativeMemory.WriteFloat(address + NativeMemory.AccelerationOffset, value);
            }
        }

        /// <summary>
        /// Gets or sets the current brake power of this <see cref="Vehicle"/>.
        /// </summary>
        public float BrakePower
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.BrakePowerOffset == 0)
                {
                    return 0.0f;
                }

                return NativeMemory.ReadFloat(address + NativeMemory.BrakePowerOffset);
            }
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.BrakePowerOffset == 0)
                {
                    return;
                }

                NativeMemory.WriteFloat(address + NativeMemory.BrakePowerOffset, value);
            }
        }

        /// <summary>
        /// Gets or sets the current throttle power of this <see cref="Vehicle"/>.
        /// </summary>
        public float ThrottlePower
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.ThrottlePowerOffset == 0)
                {
                    return 0.0f;
                }

                return NativeMemory.ReadFloat(address + NativeMemory.ThrottlePowerOffset);
            }
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.ThrottlePowerOffset == 0)
                {
                    return;
                }

                NativeMemory.WriteFloat(address + NativeMemory.ThrottlePowerOffset, value);
            }
        }

        /// <summary>
        /// Gets the maximum brake power of this <see cref="Vehicle"/>.
        /// </summary>
        public float MaxBraking => Call<float>(Hash.GET_VEHICLE_MAX_BRAKING, Handle);

        /// <summary>
        /// Gets the maximum traction of this <see cref="Vehicle"/>.
        /// </summary>
        public float MaxTraction => Call<float>(Hash.GET_VEHICLE_MAX_TRACTION, Handle);

        /// <summary>
        /// Gets the speed the drive wheels are turning at, This is the value used for the dashboard speedometers(after being converted to mph).
        /// </summary>
        public float WheelSpeed
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.WheelSpeedOffset == 0)
                {
                    return 0.0f;
                }

                return NativeMemory.ReadFloat(address + NativeMemory.WheelSpeedOffset);
            }
        }

        /// <summary>
        /// Sets this <see cref="Vehicle"/>s forward speed.
        /// </summary>
        /// <value>
        /// The forward speed in m/s.
        /// </value>
        public float ForwardSpeed
        {
            set
            {
                if (IsTrain)
                {
                    Call(Hash.SET_TRAIN_SPEED, Handle, value);
                    Call(Hash.SET_TRAIN_CRUISE_SPEED, Handle, value);
                }
                else
                {
                    Call(Hash.SET_VEHICLE_FORWARD_SPEED, Handle, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the blades speed for this heli.
        /// </summary>
        public float HeliBladesSpeed
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.HeliBladesSpeedOffset == 0 || !IsRotaryWingAircraft)
                {
                    return 0.0f;
                }

                return NativeMemory.ReadFloat(address + NativeMemory.HeliBladesSpeedOffset);
            }
            set
            {
                if (!IsRotaryWingAircraft)
                {
                    return;
                }

                Call(Hash.SET_HELI_BLADES_SPEED, Handle, value);
            }
        }

        /// <summary>
        /// Gets or sets the current RPM of this <see cref="Vehicle"/>.
        /// </summary>
        /// <value>
        /// The current RPM between <c>0.0f</c> and <c>1.0f</c>.
        /// </value>
        public float CurrentRPM
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.CurrentRPMOffset == 0)
                {
                    return 0.0f;
                }

                return NativeMemory.ReadFloat(address + NativeMemory.CurrentRPMOffset);
            }
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.CurrentRPMOffset == 0)
                {
                    return;
                }

                NativeMemory.WriteFloat(address + NativeMemory.CurrentRPMOffset, value);
            }
        }

        /// <summary>
        /// Gets the acceleration of this <see cref="Vehicle"/>.
        /// </summary>
        public float Acceleration
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.AccelerationOffset == 0)
                {
                    return 0.0f;
                }

                return NativeMemory.ReadFloat(address + NativeMemory.AccelerationOffset);
            }
        }

        /// <summary>
        /// Gets or sets the steering angle of this <see cref="Vehicle"/>.
        /// </summary>
        /// <value>
        /// The steering angle in degrees.
        /// </value>
        public float SteeringAngle
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.SteeringAngleOffset == 0)
                {
                    return 0.0f;
                }

                return (float)(NativeMemory.ReadFloat(address + NativeMemory.SteeringAngleOffset) *
                               (180.0 / System.Math.PI));
            }
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.SteeringAngleOffset == 0)
                {
                    return;
                }

                // Need to add 10 degrees to the value for it to apply correctly for some reason
                NativeMemory.WriteFloat(address + NativeMemory.SteeringAngleOffset,
                    (float)((value + (value > 0 ? 10 : -10)) * (System.Math.PI / 180.0)));
            }
        }

        /// <summary>
        /// Gets or sets the steering scale of this <see cref="Vehicle"/>.
        /// </summary>
        public float SteeringScale
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.SteeringScaleOffset == 0)
                {
                    return 0.0f;
                }

                return NativeMemory.ReadFloat(address + NativeMemory.SteeringScaleOffset);
            }
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.SteeringScaleOffset == 0)
                {
                    return;
                }

                NativeMemory.WriteFloat(address + NativeMemory.SteeringScaleOffset, value);
            }
        }

        #endregion

        #region Alarm

        /// <summary>
        /// Sets a value indicating whether this <see cref="Vehicle"/> has an alarm set.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this <see cref="Vehicle"/> has an alarm set; otherwise, <see langword="false" />.
        /// </value>
        public bool IsAlarmSet
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.AlarmTimeOffset == 0)
                {
                    return false;
                }

                return (ushort)NativeMemory.ReadInt16(address + NativeMemory.AlarmTimeOffset) ==
                       ushort.MaxValue; //The alarm is set when the value is 0xFFFF
            }
            set => Call(Hash.SET_VEHICLE_ALARM, Handle, value);
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> is sounding its alarm.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this <see cref="Vehicle"/> is sounding its alarm; otherwise, <see langword="false" />.
        /// </value>
        public bool IsAlarmSounding => Call<bool>(Hash.IS_VEHICLE_ALARM_ACTIVATED, Handle);

        /// <summary>
        /// Gets or sets time left before this <see cref="Vehicle"/> alarm stops.
        /// If greater than zero, the vehicle alarm will be sounding.
        /// the value is up to 65534.
        /// </summary>
        /// <value>
        /// The time left before this <see cref="Vehicle"/> alarm stops.
        /// </value>
        public int AlarmTimeLeft
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.AlarmTimeOffset == 0)
                {
                    return 0;
                }

                ushort alarmTime = (ushort)NativeMemory.ReadInt16(address + NativeMemory.AlarmTimeOffset);
                return alarmTime != ushort.MaxValue ? alarmTime : 0;
            }
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || (ushort)value == ushort.MaxValue || NativeMemory.AlarmTimeOffset == 0)
                {
                    return;
                }

                NativeMemory.WriteInt16(address + NativeMemory.AlarmTimeOffset, (short)value);
            }
        }

        /// <summary>
        /// Starts sounding the alarm on this <see cref="Vehicle"/>.
        /// </summary>
        public void StartAlarm()
        {
            Call(Hash.START_VEHICLE_ALARM, Handle);
        }

        #endregion

        #region Siren & Horn

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> has a siren.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this <see cref="Vehicle"/> has a siren; otherwise, <see langword="false" />.
        /// </value>
        public bool HasSiren => Bones.Contains("siren1");

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Vehicle"/> has its siren turned on.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this <see cref="Vehicle"/> has its siren turned on; otherwise, <see langword="false" />.
        /// </value>
        public bool IsSirenActive
        {
            get => Call<bool>(Hash.IS_VEHICLE_SIREN_ON, Handle);
            set => Call(Hash.SET_VEHICLE_SIREN, Handle, value);
        }

        /// <summary>
        /// Sets a value indicating whether the siren on this <see cref="Vehicle"/> plays sounds.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if the siren on this <see cref="Vehicle"/> plays sounds; otherwise, <see langword="false" />.
        /// </value>
        public bool IsSirenSilent
        {
            set => Call(Hash.SET_VEHICLE_HAS_MUTED_SIRENS, Handle, value);
        }

        /// <summary>
        /// Sounds the horn on this <see cref="Vehicle"/>.
        /// </summary>
        /// <param name="duration">The duration in milliseconds to sound the horn for.</param>
        public void SoundHorn(int duration)
        {
            Call(Hash.START_VEHICLE_HORN, Handle, duration, Game.GenerateHash("HELDDOWN"), 0);
        }

        #endregion

        #region Lights

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Vehicle"/> has its lights on.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this <see cref="Vehicle"/> has its lights on; otherwise, <see langword="false" />.
        /// </value>
        public bool AreLightsOn
        {
            get
            {
                bool lightState1, lightState2;
                unsafe
                {
                    Call(Hash.GET_VEHICLE_LIGHTS_STATE, Handle, &lightState1, &lightState2);
                }

                return lightState1;
            }
            set => Call(Hash.SET_VEHICLE_LIGHTS, Handle, value ? 3 : 4);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Vehicle"/> has its high beams on.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this <see cref="Vehicle"/> has its high beams on; otherwise, <see langword="false" />.
        /// </value>
        public bool AreHighBeamsOn
        {
            get
            {
                bool lightState1, lightState2;
                unsafe
                {
                    Call(Hash.GET_VEHICLE_LIGHTS_STATE, Handle, &lightState1, &lightState2);
                }

                return lightState2;
            }
            set => Call(Hash.SET_VEHICLE_FULLBEAM, Handle, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Vehicle"/> has its interior lights on.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this <see cref="Vehicle"/> has its interior lights on; otherwise, <see langword="false" />.
        /// </value>
        public bool IsInteriorLightOn
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.IsInteriorLightOnOffset == 0)
                {
                    return false;
                }

                return NativeMemory.IsBitSet(address + NativeMemory.IsInteriorLightOnOffset, 6);
            }
            set => Call(Hash.SET_VEHICLE_INTERIORLIGHT, Handle, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Vehicle"/> has its search light on.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this <see cref="Vehicle"/> has its search light on; otherwise, <see langword="false" />.
        /// </value>
        public bool IsSearchLightOn
        {
            get => Call<bool>(Hash.IS_VEHICLE_SEARCHLIGHT_ON, Handle);
            set => Call(Hash.SET_VEHICLE_SEARCHLIGHT, Handle, value, 0);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Vehicle"/> has its taxi light on.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this <see cref="Vehicle"/> has its taxi light on; otherwise, <see langword="false" />.
        /// </value>
        public bool IsTaxiLightOn
        {
            get => Call<bool>(Hash.IS_TAXI_LIGHT_ON, Handle);
            set => Call(Hash.SET_TAXI_LIGHTS, Handle, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Vehicle"/> has its left indicator light on.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this <see cref="Vehicle"/> has its left indicator light on; otherwise, <see langword="false" />.
        /// </value>
        public bool IsLeftIndicatorLightOn
        {
            get => NativeMemory.IsBitSet(MemoryAddress + NativeMemory.IsInteriorLightOnOffset, 0);
            set => Call(Hash.SET_VEHICLE_INDICATOR_LIGHTS, Handle, true, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Vehicle"/> has its right indicator light on.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this <see cref="Vehicle"/> has its right indicator light on; otherwise, <see langword="false" />.
        /// </value>
        public bool IsRightIndicatorLightOn
        {
            get => NativeMemory.IsBitSet(MemoryAddress + NativeMemory.IsInteriorLightOnOffset, 1);
            set => Call(Hash.SET_VEHICLE_INDICATOR_LIGHTS, Handle, false, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Vehicle"/> has its brake light on.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this <see cref="Vehicle"/> has its brake light on; otherwise, <see langword="false" />.
        /// </value>
        public bool AreBrakeLightsOn
        {
            set => Call(Hash.SET_VEHICLE_BRAKE_LIGHTS, Handle, value);
        }

        public float LightsMultiplier
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.VehicleLightsMultiplierOffset == 0)
                {
                    return 0.0f;
                }

                return NativeMemory.ReadFloat(address + NativeMemory.VehicleLightsMultiplierOffset);
            }
            set => Call(Hash.SET_VEHICLE_LIGHT_MULTIPLIER, Handle, value);
        }

        #endregion

        #region Damaging

        /// <summary>
        /// <para>
        /// Gets or sets a value indicating whether this <see cref="Vehicle"/> is considered destroyed.
        /// Will be set to <see langword="true"/> when <see cref="Vehicle"/>s are exploded or sinking for a short time.
        /// </para>
        /// <para>
        /// <see cref="Entity.IsDead"/> will return <see langword="true"/> and <see cref="IsDriveable"/> will return <see langword="false"/> if this value is set to <see langword="true"/>.
        /// Does not affect if this <see cref="Vehicle"/> will rendered scorched.
        /// </para>
        /// </summary>
        /// <remarks>
        /// Many features of <see cref="Vehicle"/> will be disabled when this value is set to <see langword="true"/>.
        /// For example, <see cref="Ped"/>s cannot enter <see cref="Vehicle"/>s considered destroyed or start the engines of them. <see cref="Ped"/>s cannot use weapons of them.
        /// The player cannot unflip <see cref="Vehicle"/>s considered destroyed.
        /// </remarks>
        public bool IsConsideredDestroyed
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero)
                {
                    // Return true if the entity does not exist, just like IS_ENTITY_DEAD will return true in the same condition
                    return true;
                }

                return (NativeMemory.ReadByte(address + 0xD8) & 7) == 3;
            }
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero)
                {
                    return;
                }

                var targetValue = NativeMemory.ReadByte(address + 0xD8) & 0xF8;

                if (value)
                    targetValue |= 3;

                NativeMemory.WriteByte(address + 0xD8, (byte)targetValue);
            }
        }

        public bool IsDamaged => Call<bool>(Hash.GET_DOES_VEHICLE_HAVE_DAMAGE_DECALS, Handle);

        public bool IsDriveable
        {
            get => Call<bool>(Hash.IS_VEHICLE_DRIVEABLE, Handle, 0);
            set => Call(Hash.SET_VEHICLE_UNDRIVEABLE, Handle, !value);
        }

        public bool IsLeftHeadLightBroken
        {
            get => Call<bool>(Hash.GET_IS_LEFT_VEHICLE_HEADLIGHT_DAMAGED, Handle);
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.IsHeadlightDamagedOffset == 0)
                {
                    return;
                }

                if (value)
                {
                    NativeMemory.SetBit(address + NativeMemory.IsHeadlightDamagedOffset, 0);
                }
                else
                {
                    NativeMemory.ClearBit(address + NativeMemory.IsHeadlightDamagedOffset, 0);
                }
            }
        }

        public bool IsRightHeadLightBroken
        {
            get => Call<bool>(Hash.GET_IS_RIGHT_VEHICLE_HEADLIGHT_DAMAGED, Handle);
            set
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.IsHeadlightDamagedOffset == 0)
                {
                    return;
                }

                if (value)
                {
                    NativeMemory.SetBit(address + NativeMemory.IsHeadlightDamagedOffset, 1);
                }
                else
                {
                    NativeMemory.ClearBit(address + NativeMemory.IsHeadlightDamagedOffset, 1);
                }
            }
        }

        public bool IsRearBumperBrokenOff => Call<bool>(Hash.IS_VEHICLE_BUMPER_BROKEN_OFF, Handle, false);

        public bool IsFrontBumperBrokenOff => Call<bool>(Hash.IS_VEHICLE_BUMPER_BROKEN_OFF, Handle, true);

        public bool IsAxlesStrong
        {
            set => Call<bool>(Hash.SET_VEHICLE_HAS_STRONG_AXLES, Handle, value);
        }

        public bool CanTiresBurst
        {
            get => Call<bool>(Hash.GET_VEHICLE_TYRES_CAN_BURST, Handle);
            set => Call(Hash.SET_VEHICLE_TYRES_CAN_BURST, Handle, value);
        }

        public bool CanWheelsBreak
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.CanWheelBreakOffset == 0)
                {
                    return false;
                }

                return !NativeMemory.IsBitSet(address + NativeMemory.CanWheelBreakOffset, 6);
            }
            set => Call(Hash.SET_VEHICLE_WHEELS_CAN_BREAK, Handle, value);
        }

        public bool CanBeVisiblyDamaged
        {
            set => Call(Hash.SET_VEHICLE_CAN_BE_VISIBLY_DAMAGED, Handle, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Vehicle"/> drops money when destroyed.
        /// Only works when the vehicle model is a car, quad bikes or trikes (strictly when the internal vehicle class is CAutomobile or derived class from CAutomobile).
        /// </summary>
        /// <value>
        /// <see langword="true" /> if this <see cref="Vehicle"/> drops money when destroyed; otherwise, <see langword="false" />.
        /// </value>
        public bool DropsMoneyOnExplosion
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.VehicleDropsMoneyWhenBlownUpOffset == 0)
                {
                    return false;
                }

                // Check if the vehicle class is CAutomobile or a subclass of it
                if ((uint)Type <= 10)
                {
                    return NativeMemory.IsBitSet(address + NativeMemory.VehicleDropsMoneyWhenBlownUpOffset, 1);
                }

                return false;
            }
            set => Call(Hash.SET_VEHICLE_DROPS_MONEY_WHEN_BLOWN_UP, Handle, value);
        }

        public void ApplyDamage(Vector3 position, float damageAmount, float radius)
        {
            Call(Hash.SET_VEHICLE_DAMAGE, position.X, position.Y, position.Z, damageAmount, radius);
        }

        #endregion

        #region Doors & Locks

        public bool HasRoof => Call<bool>(Hash.DOES_VEHICLE_HAVE_ROOF, Handle);

        public VehicleRoofState RoofState
        {
            get => Call<VehicleRoofState>(Hash.GET_CONVERTIBLE_ROOF_STATE, Handle);
            set
            {
                switch (value)
                {
                    case VehicleRoofState.Closed:
                        Call(Hash.RAISE_CONVERTIBLE_ROOF, Handle, true);
                        Call(Hash.RAISE_CONVERTIBLE_ROOF, Handle, false);
                        break;
                    case VehicleRoofState.Closing:
                        Call(Hash.RAISE_CONVERTIBLE_ROOF, Handle, false);
                        break;
                    case VehicleRoofState.Opened:
                        Call(Hash.LOWER_CONVERTIBLE_ROOF, Handle, true);
                        Call(Hash.LOWER_CONVERTIBLE_ROOF, Handle, false);
                        break;
                    case VehicleRoofState.Opening:
                        Call(Hash.LOWER_CONVERTIBLE_ROOF, Handle, false);
                        break;
                }
            }
        }

        public VehicleLockStatus LockStatus
        {
            get => Call<VehicleLockStatus>(Hash.GET_VEHICLE_DOOR_LOCK_STATUS, Handle);
            set => Call(Hash.SET_VEHICLE_DOORS_LOCKED, Handle, value);
        }

        public VehicleLandingGearState LandingGearState
        {
            get => Call<VehicleLandingGearState>(Hash.GET_LANDING_GEAR_STATE, Handle);
            set
            {
                int state = 0;
                switch (value)
                {
                    case VehicleLandingGearState.Deploying:
                        state = 0;
                        break;
                    case VehicleLandingGearState.Retracting:
                        state = 1;
                        break;
                    case VehicleLandingGearState.Deployed:
                        state = 2;
                        break;
                    case VehicleLandingGearState.Retracted:
                        state = 3;
                        break;
                    case VehicleLandingGearState.Broken:
                        state = 4;
                        break;
                    default:
                        return;
                }

                Call(Hash.CONTROL_LANDING_GEAR, Handle, state);
            }
        }

        public VehicleDoorCollection Doors => _doors ?? (_doors = new VehicleDoorCollection(this));

        #endregion

        #region Burnout

        public bool IsInBurnout => Call<bool>(Hash.IS_VEHICLE_IN_BURNOUT, Handle);

        public bool IsBurnoutForced
        {
            set => Call<bool>(Hash.SET_VEHICLE_BURNOUT, Handle, value);
        }

        /// <summary>
        /// Sets a value indicating whether the Handbrake on this <see cref="Vehicle"/> is forced on.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if the Handbrake on this <see cref="Vehicle"/> is forced on; otherwise, <see langword="false" />.
        /// </value>
        public bool IsHandbrakeForcedOn
        {
            set => Call(Hash.SET_VEHICLE_HANDBRAKE, Handle, value);
        }

        #endregion

        #region Occupants

        public Ped Driver => GetPedOnSeat(VehicleSeat.Driver);

        public Ped GetPedOnSeat(VehicleSeat seat)
        {
            var ped = new Ped(Call<int>(Hash.GET_PED_IN_VEHICLE_SEAT, Handle, seat));
            return ped.Exists() ? ped : null;
        }

        public Ped[] Occupants
        {
            get
            {
                Ped driver = Driver;

                if (driver == null)
                {
                    return Passengers;
                }

                var result = new Ped[PassengerCount + 1];
                result[0] = driver;

                for (int i = 0, j = 0, seats = PassengerCapacity; i < seats && j < result.Length; i++)
                {
                    if (!IsSeatFree((VehicleSeat)i))
                    {
                        result[j++ + 1] = GetPedOnSeat((VehicleSeat)i);
                    }
                }

                return result;
            }
        }

        public Ped[] Passengers
        {
            get
            {
                var result = new Ped[PassengerCount];
                if (result.Length == 0)
                {
                    return result;
                }

                for (int i = 0, j = 0, seats = PassengerCapacity; i < seats && j < result.Length; i++)
                {
                    if (!IsSeatFree((VehicleSeat)i))
                    {
                        result[j++] = GetPedOnSeat((VehicleSeat)i);
                    }
                }

                return result;
            }
        }

        public int PassengerCount => Call<int>(Hash.GET_VEHICLE_NUMBER_OF_PASSENGERS, Handle, false, true);

        public int PassengerCapacity => Call<int>(Hash.GET_VEHICLE_MAX_NUMBER_OF_PASSENGERS, Handle);

        public Ped CreatePedOnSeat(VehicleSeat seat, Model model)
        {
            if (!IsSeatFree(seat))
            {
                throw new ArgumentException("The VehicleSeat selected was not free", nameof(seat));
            }

            if (!model.IsPed || !model.Request(1000))
            {
                return null;
            }

            return new Ped(Call<int>(Hash.CREATE_PED_INSIDE_VEHICLE, Handle, 26, model.Hash, seat, 1, 1));
        }

        public Ped CreateRandomPedOnSeat(VehicleSeat seat)
        {
            if (!IsSeatFree(seat))
            {
                throw new ArgumentException("The VehicleSeat selected was not free", nameof(seat));
            }

            if (seat == VehicleSeat.Driver)
            {
                return new Ped(Call<int>(Hash.CREATE_RANDOM_PED_AS_DRIVER, Handle, true));
            }
            else
            {
                int pedHandle = Call<int>(Hash.CREATE_RANDOM_PED, 0f, 0f, 0f);
                Call(Hash.SET_PED_INTO_VEHICLE, pedHandle, Handle, seat);

                return new Ped(pedHandle);
            }
        }

        public bool IsSeatFree(VehicleSeat seat)
        {
            return Call<bool>(Hash.IS_VEHICLE_SEAT_FREE, Handle, seat);
        }

        #endregion

        #region Positioning

        public bool IsStopped => Call<bool>(Hash.IS_VEHICLE_STOPPED, Handle);

        public bool IsStoppedAtTrafficLights => Call<bool>(Hash.IS_VEHICLE_STOPPED_AT_TRAFFIC_LIGHTS, Handle);

        public bool IsOnAllWheels => Call<bool>(Hash.IS_VEHICLE_ON_ALL_WHEELS, Handle);

        public bool PlaceOnGround()
        {
            return Call<bool>(Hash.SET_VEHICLE_ON_GROUND_PROPERLY, Handle);
        }

        public void PlaceOnNextStreet()
        {
            Vector3 currentPosition = Position;
            Vector3 newPosition;
            float heading;
            long unkn;

            for (int i = 1; i < 40; i++)
            {
                unsafe
                {
                    Call(Hash.GET_NTH_CLOSEST_VEHICLE_NODE_WITH_HEADING, currentPosition.X, currentPosition.Y,
                        currentPosition.Z, i, &newPosition, &heading, &unkn, 1, 0x40400000, 0);
                }

                if (!Call<bool>(Hash.IS_POINT_OBSCURED_BY_A_MISSION_ENTITY, newPosition.X, newPosition.Y, newPosition.Z,
                        5.0f, 5.0f, 5.0f, 0))
                {
                    Position = newPosition;
                    PlaceOnGround();
                    Heading = heading;
                    break;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether peds can use this <see cref="Vehicle"/> for cover.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if peds can use this <see cref="Vehicle"/> for cover; otherwise, <see langword="false" />.
        /// </value>
        public bool ProvidesCover
        {
            get
            {
                var address = MemoryAddress;
                if (address == IntPtr.Zero || NativeMemory.VehicleProvidesCoverOffset == 0)
                {
                    return false;
                }

                return NativeMemory.IsBitSet(address + NativeMemory.VehicleProvidesCoverOffset, 2);
            }
            set => Call(Hash.SET_VEHICLE_PROVIDES_COVER, Handle, value);
        }

        #endregion

        #region Towing

        /// <summary>
        /// Gets a value indicating whether this <see cref="Vehicle"/> has forks.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this <see cref="Vehicle"/> has forks; otherwise, <see langword="false" />.
        /// </value>
        public bool HasForks => Bones.Contains("forks");

        public bool HasTowArm => Bones.Contains("tow_arm");

        public float TowArmPosition
        {
            set => Call(Hash.SET_VEHICLE_TOW_TRUCK_ARM_POSITION, Handle, value);
        }

        public void TowVehicle(Vehicle vehicle, bool rear)
        {
            Call(Hash.ATTACH_VEHICLE_TO_TOW_TRUCK, Handle, vehicle.Handle, rear, 0f, 0f, 0f);
        }

        public void DetachFromTowTruck()
        {
            Call(Hash.DETACH_VEHICLE_FROM_ANY_TOW_TRUCK, Handle);
        }

        public void DetachTowedVehicle()
        {
            Vehicle vehicle = TowedVehicle;

            if (vehicle != null)
            {
                Call(Hash.DETACH_VEHICLE_FROM_TOW_TRUCK, Handle, vehicle.Handle);
            }
        }

        public Vehicle TowedVehicle
        {
            get
            {
                var veh = new Vehicle(Call<int>(Hash.GET_ENTITY_ATTACHED_TO_TOW_TRUCK, Handle));
                return veh.Exists() ? veh : null;
            }
        }

        #endregion

        #region Carbobob

        public bool HasBombBay => Bones.Contains("door_hatch_l") && Bones.Contains("door_hatch_r");

        public void OpenBombBay()
        {
            if (HasBombBay)
            {
                Call(Hash.OPEN_BOMB_BAY_DOORS, Handle);
            }
        }

        public void CloseBombBay()
        {
            if (HasBombBay)
            {
                Call(Hash.CLOSE_BOMB_BAY_DOORS, Handle);
            }
        }

        public void SetHeliYawPitchRollMult(float mult)
        {
            if (IsHeliOrBlimp && mult >= 0.0f && mult <= 1.0f)
            {
                Call(Hash.SET_HELI_CONTROL_LAGGING_RATE_SCALAR, Handle, mult);
            }
        }

        public void DropCargobobHook(CargobobHook hook)
        {
            if (Model.IsCargobob)
            {
                Call(Hash.CREATE_PICK_UP_ROPE_FOR_CARGOBOB, Handle, hook);
            }
        }

        public void RetractCargobobHook()
        {
            if (Model.IsCargobob)
            {
                Call(Hash.REMOVE_PICK_UP_ROPE_FOR_CARGOBOB, Handle);
            }
        }

        public bool IsCargobobHookActive()
        {
            if (Model.IsCargobob)
            {
                return Call<bool>(Hash.DOES_CARGOBOB_HAVE_PICK_UP_ROPE, Handle) ||
                       Call<bool>(Hash.DOES_CARGOBOB_HAVE_PICKUP_MAGNET, Handle);
            }

            return false;
        }

        public bool IsCargobobHookActive(CargobobHook hook)
        {
            if (Model.IsCargobob)
            {
                switch (hook)
                {
                    case CargobobHook.Hook:
                        return Call<bool>(Hash.DOES_CARGOBOB_HAVE_PICK_UP_ROPE, Handle);
                    case CargobobHook.Magnet:
                        return Call<bool>(Hash.DOES_CARGOBOB_HAVE_PICKUP_MAGNET, Handle);
                }
            }

            return false;
        }

        public void CargoBobMagnetGrabVehicle()
        {
            if (IsCargobobHookActive(CargobobHook.Magnet))
            {
                Call(Hash.SET_CARGOBOB_PICKUP_MAGNET_ACTIVE, Handle, true);
            }
        }

        public void CargoBobMagnetReleaseVehicle()
        {
            if (IsCargobobHookActive(CargobobHook.Magnet))
            {
                Call(Hash.SET_CARGOBOB_PICKUP_MAGNET_ACTIVE, Handle, false);
            }
        }

        #endregion

        #region Task

        /// <summary>
        /// Checks if this <see cref="Vehicle"/> is being brought to a halt.
        /// </summary>
        public bool IsBeingBroughtToHalt => Game.Version >= GameVersion.v1_0_1493_0_Steam &&
                                            Call<bool>(Hash.IS_VEHICLE_BEING_BROUGHT_TO_HALT, Handle);

        /// <summary>
        /// Starts the task to decelerate this <see cref="Vehicle"/> until it comes to rest, possibly in an unphysically short distance.
        /// </summary>
        /// <param name="stoppingDistance">The distance from the initial coords at which the vehicle should come to rest.</param>
        /// <param name="timeToStopFor">The length of time in seconds to hold the car at rest after stopping.</param>
        /// <param name="controlVerticalVelocity">
        /// If <see langword="false" />, the task allows gravity to act normally in the Z direction.
        /// If <see langword="true" />,  the task will also arrest the car's vertical velocity.
        /// </param>
        public void BringToHalt(float stoppingDistance, int timeToStopFor, bool controlVerticalVelocity = false)
        {
            Call(Hash.BRING_VEHICLE_TO_HALT, Handle, stoppingDistance, timeToStopFor, controlVerticalVelocity);
        }

        /// <summary>
        /// Stops bringing this <see cref="Vehicle"/> to a halt.
        /// </summary>
        public void StopBringingToHalt()
        {
            if (Game.Version < GameVersion.v1_0_1103_2_Steam)
                throw new GameVersionNotSupportedException(GameVersion.v1_0_1103_2_Steam, nameof(Vehicle),
                    nameof(StopBringingToHalt));

            Call(Hash.STOP_BRINGING_VEHICLE_TO_HALT, Handle);
        }

        /// <summary>
        /// Gets active vehicle mission type.
        /// </summary>
        public VehicleMissionType GetActiveMissionType()
        {
            return Call<VehicleMissionType>(Hash.GET_ACTIVE_VEHICLE_MISSION_TYPE, Handle);
        }

        #endregion

        #region Special Abilities

        /// <summary>
        /// Open the vehicle's parachute (if any)
        /// </summary>
        /// <param name="allowPlayerToCancel">Whether to allow the player to cancel parachuting before the vehicle lands</param>
        public void StartParachuting(bool allowPlayerToCancel)
        {
            if (Game.Version < GameVersion.v1_0_944_2_Steam)
                throw new GameVersionNotSupportedException(GameVersion.v1_0_944_2_Steam, nameof(Vehicle),
                    nameof(StartParachuting));

            if (HasParachute)
            {
                Call((Hash)0x0BFFB028B3DD0A97, Handle, allowPlayerToCancel);
            }
        }

        #endregion

        public static string GetModelDisplayName(Model vehicleModel)
        {
            return Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, vehicleModel.Hash);
        }

        public static string GetClassDisplayName(VehicleClass vehicleClass)
        {
            return "VEH_CLASS_" + ((int)vehicleClass).ToString();
        }

        public static string GetModelMakeName(Model vehicleModel)
        {
            return NativeMemory.GetVehicleMakeName(vehicleModel.Hash);
        }

        public static VehicleClass GetModelClass(Model vehicleModel)
        {
            return Call<VehicleClass>(Hash.GET_VEHICLE_CLASS_FROM_NAME, vehicleModel.Hash);
        }

        public static VehicleType GetModelType(Model vehicleModel)
        {
            return (VehicleType)NativeMemory.GetVehicleType(vehicleModel);
        }

        public static int[] GetAllModelValues()
        {
            var allModels = new List<int>();
            for (int i = 0; i < 0x20; i++)
            {
                allModels.AddRange(NativeMemory.VehicleModels[i].ToArray());
            }

            return allModels.ToArray();
        }

        public static VehicleHash[] GetAllModels()
        {
            var allModels = new List<VehicleHash>();
            for (int i = 0; i < 0x20; i++)
            {
                allModels.AddRange(Array.ConvertAll(NativeMemory.VehicleModels[i].ToArray(),
                    item => (VehicleHash)item));
            }

            return allModels.ToArray();
        }

        /// <summary>
        /// Gets an <c>array</c> of all loaded <see cref="VehicleHash"/>s that is appropriate to spawn as ambient vehicles.
        /// All the model hashes of the elements are loaded and the <see cref="Vehicle"/>s with the model hashes can be spawned immediately.
        /// </summary>
        public static VehicleHash[] GetAllLoadedModelsAppropriateForAmbientVehicles()
        {
            return NativeMemory.GetLoadedAppropriateVehicleHashes()
                .Select(x => (VehicleHash)x)
                .ToArray();
        }

        public static VehicleHash[] GetAllModelsOfClass(VehicleClass vehicleClass)
        {
            return Array.ConvertAll(NativeMemory.VehicleModels[(int)vehicleClass].ToArray(), item => (VehicleHash)item);
        }

        public static VehicleHash[] GetAllModelsOfType(VehicleType vehicleType)
        {
            return Array.ConvertAll(NativeMemory.VehicleModelsGroupedByType[(int)vehicleType].ToArray(),
                item => (VehicleHash)item);
        }
    }
}