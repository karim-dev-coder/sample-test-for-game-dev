using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpaceShip : IEntity
{
    public string Name { get; }
    public SpaceShipModificatorService ModificatorService { get; }

    public StatsCollection Stats { get; } = new();
    public List<WeaponSlot> WeaponSlots { get; } = new();
    public List<ModuleSlot> ModuleSlots { get; } = new();

    public IEnumerable<IWeapon> Weapons => WeaponSlots.OfType<WeaponSlot>().Select(slot => slot.Weapon);

    public SpaceShip(string name)
    {
        Name = name;
        ModificatorService = new SpaceShipModificatorService(this);
    }

    public void Update(float dt)
    {
        foreach (var stat in Stats)
        {
            if (stat is IUpdatableStat updatableStat)
            {
                updatableStat.Update(dt, ModificatorService);
            }
        }

        foreach (var weapon in Weapons)
        {
            if (weapon is IHaveCooldown cooldownWeapon)
            {
                cooldownWeapon.Update(dt);
            }
        }
    }

    public void DealDamage(float damage)
    {
        Debug.Log($"{this} take damage '{damage}'");

        var oldShield = Stats.Shield.Value;
        var oldHealth = Stats.Health.Value;

        var reducedDamage = Stats.Shield.ReduceDamage(damage);
        Stats.Health.TakeDamage(reducedDamage);

        if (reducedDamage < damage) Debug.Log($"{this}: Shield reduce '{damage - reducedDamage}' damage");
        if (reducedDamage == damage)
            Debug.Log($"{this}: Shield does not reduce damage");
        if (oldShield > Stats.Shield.Value)
            Debug.Log($"{this}: Shield -{oldShield - Stats.Shield.Value}");

        if (oldHealth > Stats.Health.Value)
            Debug.Log($"{this}: Health -{oldHealth - Stats.Health.Value}");
        if (oldHealth == Stats.Health.Value)
            Debug.Log($"{this}: Health does not changed");
    }

    public override string ToString()
    {
        return $"'{Name}'";
    }
}