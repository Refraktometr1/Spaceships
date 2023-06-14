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
        
        public void DoShoot()
        {
        }
    }
}