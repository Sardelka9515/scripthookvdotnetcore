//
// Copyright (C) 2015 crosire & contributors
// License: https://github.com/crosire/scripthookvdotnet#license
//

namespace GTA
{
    public sealed class Style
    {
        #region Fields

        readonly Ped _ped;
        Dictionary<PedPropType, PedProp> _pedProps = new();
        Dictionary<PedComponentType, PedComponent> _pedComponents = new();

        #endregion

        internal Style(Ped ped)
        {
            _ped = ped;
        }

        public PedProp this[PedPropType propId]
        {
            get
            {
                if (!_pedProps.TryGetValue(propId, out PedProp prop))
                {
                    prop = new PedProp(_ped, propId);
                    _pedProps.Add(propId, prop);
                }

                return prop;
            }
        }

        public PedComponent this[PedComponentType componentId]
        {
            get
            {
                if (!_pedComponents.TryGetValue(componentId, out PedComponent variation))
                {
                    variation = new PedComponent(_ped, componentId);
                    _pedComponents.Add(componentId, variation);
                }

                return variation;
            }
        }

        public PedProp[] GetAllProps()
        {
            var props = new List<PedProp>();
            foreach (PedPropType propId in Enum.GetValues<PedPropType>())
            {
                PedProp prop = this[propId];
                if (prop.HasAnyVariations)
                {
                    props.Add(prop);
                }
            }

            return props.ToArray();
        }

        public PedComponent[] GetAllComponents()
        {
            var components = new List<PedComponent>();
            foreach (PedComponentType componentId in Enum.GetValues<PedComponentType>())
            {
                PedComponent component = this[componentId];
                if (component.HasAnyVariations)
                {
                    components.Add(component);
                }
            }

            return components.ToArray();
        }

        public IPedVariation[] GetAllVariations()
        {
            var variations = new List<IPedVariation>();
            variations.AddRange(GetAllComponents());
            variations.AddRange(GetAllProps());
            return variations.ToArray();
        }

        public IEnumerator<IPedVariation> GetEnumerator()
        {
            return (GetAllVariations() as IEnumerable<IPedVariation>).GetEnumerator();
        }

        public void ClearProps()
        {
            Call(Hash.CLEAR_ALL_PED_PROPS, _ped.Handle);
        }

        public void RandomizeProps()
        {
            Call(Hash.SET_PED_RANDOM_PROPS, _ped.Handle);
        }

        public void RandomizeOutfit()
        {
            switch ((PedHash)_ped.Model.Hash)
            {
                case PedHash.Michael:
                case PedHash.Franklin:
                case PedHash.Trevor:
                case PedHash.FreemodeMale01:
                case PedHash.FreemodeFemale01:
                    return; //these models freeze when randomized
            }

            Call(Hash.SET_PED_RANDOM_COMPONENT_VARIATION, _ped.Handle, false);
        }

        public void SetDefaultClothes()
        {
            Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, _ped.Handle);
        }
    }
}