using Codebase.Spaceships;
using UnityEngine;

namespace Codebase.StaticData
{
    [CreateAssetMenu(fileName = "ItemStaticData", menuName = "Static Data/Item")]
    public class ItemStaticData : ScriptableObject
    {
        public ShipSlotItemType ShipSlotItemType;
        public SlotType SlotType;
        public int Hp;
        public int EnergyShield;
        public int RegeneratorHp; 
        public Sprite Sprite;
    }
}