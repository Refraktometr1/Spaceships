using Codebase.ShipGuns;

namespace Codebase
{
    public class ShipGun : ShipSlotItem, IDamageable, IShooting
    {
        private DamageType _bulletType;
        private int Damage;
        private int _chargeStorageSize;
        private int _reloadTime;
        
        
        public void DoShoot()
        {
        }

        public void ApplyDamage(int damage, DamageType type)
        {
        }
    }

    public interface IShooting
    {
        void DoShoot();
    }
}