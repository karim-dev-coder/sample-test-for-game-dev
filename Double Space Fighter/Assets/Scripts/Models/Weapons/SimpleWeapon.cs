using System;

public class SimpleWeapon : IWeapon, IHaveCooldown
{
    public string Id { get; }
    public float Damage => _baseDamage;
    public float Cooldown { get; private set; }

    private readonly float _baseCooldown;
    private readonly float _baseDamage;

    public SimpleWeapon(string id, float damage, float cooldown)
    {
        Id = id;
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
        if (Cooldown > 0)
        {
            Cooldown -= dt;
        }

        Cooldown = Math.Clamp(Cooldown, 0, Math.Abs(Cooldown));
    }

    }

    public override string ToString()
    {
        if (Cooldown > 0)
        {
            return $"Weapon: Reload '{Cooldown}' (dmg: {Damage})";
        }

        return $"Weapon: {Damage} (cd: {_baseCooldown})";
    }
}