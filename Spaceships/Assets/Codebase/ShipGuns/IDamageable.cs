namespace Codebase.ShipGuns
{
    public interface IDamageable
    {
        void ApplyDamage(int damage, DamageType type);
    }
}