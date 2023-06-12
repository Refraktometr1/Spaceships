using System;
using Codebase.ShipGuns;

namespace Codebase
{
    [Serializable]
    public class GunBarrel 
    {
        public DamageType BulletType;
        public int Cooldown;
        public int ChargeStorageSize;
    }
}