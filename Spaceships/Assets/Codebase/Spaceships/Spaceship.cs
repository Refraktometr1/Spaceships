using System.Collections.Generic;
using UnityEngine;

namespace Codebase.Spaceships
{
    public class Spaceship : MonoBehaviour
    {
        public ShipType Type;
        public int Hp;
        public int Speed;
        public List<ShipSlotItem> Slots;
        private int _level;
    }
}