﻿using System.Collections.Generic;

namespace Codebase.Spaceships
{
    public class Spaceship
    {
        public ShipType Type;
        public int Hp;
        public int Speed;
        public List<ShipSlotItem> Slots;
        private int _level;
    }
}