using System;
using Codebase.ShipGuns;

namespace Codebase.Spaceships
{
    [Serializable]
    public class ShipSlotItem : IRegenerable, IShieldable, IDamageable
    {
        public SlotType SlotType;
        public int Level;
        public ShipSlotItemType SlotItemType;
        private int EnergyShield;
        private int RegeneratorHp;
        
        public int GetRegeneratorHp() => RegeneratorHp;

        public int GetEnergyShield() => EnergyShield;
        
        public void ApplyDamage(int damage, DamageType type)
        {
        }
    }
}