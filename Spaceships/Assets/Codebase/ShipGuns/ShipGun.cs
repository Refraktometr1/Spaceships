using System.Collections.Generic;
using Codebase.ShipGuns;
using UnityEditor;

namespace Codebase
{
    public class ShipGun : ShipSlotItem, IDamageable, IShooting
    {
        public ShipSlotItemType ShipSlotItemType;
        public List<GunBarrel> Barrels;
        public int Hp;
        
        
        
        public void DoShoot()
        {
        }

        public void ApplyDamage(int damage, DamageType type)
        {
        }
    }
}