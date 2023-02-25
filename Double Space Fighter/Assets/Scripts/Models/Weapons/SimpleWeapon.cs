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

    public void Shoot(IEntity target, IStatModifierService modifierService)
    {
        target.DealDamage(Damage);

        var reduceCooldownPercent = modifierService.GetAppliableModifierValue<WeaponCooldownReduce>();
        Cooldown = _baseCooldown * (1 - reduceCooldownPercent);
    }

    public void Update(float dt)
    {
        if (Cooldown > 0)
        {
            var reduceInSec = 1;
            Cooldown -= dt * reduceInSec;
        }

        Cooldown = Math.Clamp(Cooldown, 0, Math.Abs(Cooldown));
    }

    public object Clone()
    {
        return MemberwiseClone();
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