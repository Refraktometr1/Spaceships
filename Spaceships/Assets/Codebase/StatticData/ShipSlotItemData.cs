using System;
using Codebase.Spaceships;

namespace Codebase.StaticData
{
    [Serializable]
    public class ShipSlotItemData
    {
        public SlotType SlotType;
        public int Level;
        public ShipSlotItemType SlotItemType;
        internal int EnergyShield;
        internal int RegeneratorHp;
    }
}