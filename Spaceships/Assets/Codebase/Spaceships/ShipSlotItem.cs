using System;
using Codebase.ShipGuns;
using UnityEngine;

namespace Codebase.Spaceships
{
    [Serializable]
    public class ShipSlotItem : MonoBehaviour, IRegenerable, IShieldable, IDamageable
    {
        public SlotType SlotType;
        public int Level;
        public ShipSlotItemType SlotItemType;
        public int EnergyShield;
        public int RegeneratorHp;
        
        public int GetRegeneratorHp() => RegeneratorHp;

        public int GetEnergyShield() => EnergyShield;
        
        public void ApplyDamage(int damage, DamageType type)
        {
        }
    }
}