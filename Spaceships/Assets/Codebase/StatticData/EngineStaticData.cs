using Codebase.Spaceships;
using UnityEngine;

namespace Codebase.StaticData
{
    [CreateAssetMenu(fileName = "EngineStaticData", menuName = "Static Data/Engine")]
    public class EngineStaticData : ScriptableObject
    {
        public ShipSlotItemType ShipSlotItemType;
        public SlotType SlotType;
        public int MovePower;
        public int Hp;
        public Sprite Sprite;
    }
}