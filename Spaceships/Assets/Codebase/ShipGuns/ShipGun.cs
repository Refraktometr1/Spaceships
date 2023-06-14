using System.Collections.Generic;
using Codebase.ShipGuns;
using Codebase.Spaceships;

namespace Codebase
{
    public class ShipGun : ShipSlotItem, IShooting
    {
        public ShipSlotItemType ShipSlotItemType;
        public List<GunBarrel> Barrels;
        public int Hp;


        public ShipGun(ShipSlotItemType shipSlotItemType, List<GunBarrel> barrels, int hp, int level, int energyShield, int regeneratorHp)
        {
            ShipSlotItemType = shipSlotItemType;
            Barrels = barrels;
            Hp = hp;
            Level = level;
            EnergyShield = energyShield;
            RegeneratorHp = regeneratorHp;
        }

        public void DoShoot()
        {
        }
    }
}