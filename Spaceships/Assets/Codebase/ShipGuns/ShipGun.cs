using System.Collections.Generic;
using Codebase.ShipGuns;

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