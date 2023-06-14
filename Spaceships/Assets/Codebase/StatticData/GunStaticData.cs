using UnityEngine;
using System.Collections.Generic;
using Codebase.Spaceships;

namespace Codebase.StaticData
{
    [CreateAssetMenu(fileName = "GunStaticData", menuName = "Static Data/Gun")]
    public class GunStaticData: ScriptableObject
    {
        public ShipSlotItemType ShipSlotItemType;
        public SlotType SlotType;
        public List<GunBarrel> Barrels;
        public int Hp = 0;
        private int EnergyShield = 0;
    }
}