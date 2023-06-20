using System.Collections.Generic;
using Codebase.Spaceships;

namespace Codebase
{
    public class ShipGun : ShipSlotItem, IShooting
    {
        public List<GunBarrel> Barrels;
        public int Hp;

        public void DoShoot()
        {
        }
    }
}