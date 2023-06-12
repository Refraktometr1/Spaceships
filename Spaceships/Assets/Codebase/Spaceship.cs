using System.Collections.Generic;

namespace Codebase
{
    public class Spaceship
    {
        public ShipType Type;
        public int Hp;
        public int Speed;
        public List<ShipSlot> Slots;
        private int _level;
    }
}