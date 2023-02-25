using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpaceShip : IEntity
{
    public string Name { get; }

    public List<IStat> Stats { get; } = new();
    public List<WeaponSlot> WeaponSlots { get; } = new();
    public List<ModuleSlot> ModuleSlots { get; } = new();

    public IEnumerable<IWeapon> Weapons => WeaponSlots.OfType<WeaponSlot>().Select(slot => slot.Weapon);

    public SpaceShip(string name)
    {
        Name = name;
    }

    public void Update(float dt)
    {
        foreach (var stat in Stats)
        {
            if (stat is IUpdatableStat updatableStat)
            {
                updatableStat.Update(dt);
            }
        }
    }

    public void DealDamage(float damage)
    {
        Debug.Log($"{this} take damage '{damage}'");
    }

    public override string ToString()
    {
        return $"'{Name}'";
    }
}