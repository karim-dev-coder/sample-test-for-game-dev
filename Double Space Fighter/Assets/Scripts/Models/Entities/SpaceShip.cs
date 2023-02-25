﻿using System.Collections.Generic;
using System.Linq;

public class SpaceShip
{
    public List<IStat> Stats { get; } = new List<IStat>()
    {
        new Health(100),
        new Shield(80)
    };

    public IEnumerable<IWeapon> Weapons => WeaponSlots.OfType<WeaponSlot>().Select(slot => slot.Weapon);

    public readonly List<WeaponSlot> WeaponSlots = new List<WeaponSlot>()
    {
        new WeaponSlot()
    };

    public readonly List<ModuleSlot> ModuleSlots = new List<ModuleSlot>()
    {
        new ModuleSlot()
    };

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
}