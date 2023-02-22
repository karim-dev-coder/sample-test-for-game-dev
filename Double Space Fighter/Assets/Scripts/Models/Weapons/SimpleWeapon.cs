using System;

public class SimpleWeapon : IWeapon
{
    public float Damage => _baseDamage;
    public float Cooldown { get; private set; }

    private readonly float _baseCooldown;
    private readonly float _baseDamage;

    public SimpleWeapon(float damage, float cooldown)
    {
        _baseDamage = damage;
        _baseCooldown = cooldown;
    }

    public bool CanShoot()
    {
        return Cooldown == 0;
    }

    public void Shoot(IEntity target)
    {
        target.DealDamage(Damage);
        Cooldown = _baseCooldown;
    }

    public void Update(float dt)
    {
        Math.Clamp(Cooldown, 0, Math.Abs(Cooldown));
        if (Cooldown > 0)
        {
            Cooldown -= dt;
        }
    }
}