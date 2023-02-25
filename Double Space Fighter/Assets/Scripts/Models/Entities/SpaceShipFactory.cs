using System;
using System.Collections.Generic;

public static class SpaceShipFactory
{
    [Serializable]
    public struct ShieldParams
    {
        public float Value;
        public float RechargeInSec;

        public ShieldParams(float value, float rechargeInSec)
        {
            Value = value;
            RechargeInSec = rechargeInSec;
        }
    }

    [Serializable]
    public struct Params
    {
        public float Health;
        public ShieldParams Shield;
        public List<string> Weapons;
        public List<string> Modules;

        public static Params Default =>
            new()
            {
                Health = 100,
                Shield = new ShieldParams(100, 1),
                Weapons = new List<string>
                {
                    EmptyWeapon.ID
                },
                Modules = new List<string>
                {
                    EmptyModule.ID
                }
            };
    }

    public static SpaceShip Create(string name, Params param)
    {
        var spaceShip = new SpaceShip(name);

        spaceShip.Stats.Set(new Health(param.Health, spaceShip.ModificatorService));
        spaceShip.Stats.Set(new Shield(param.Shield.Value, param.Shield.RechargeInSec, spaceShip.ModificatorService));

        foreach (var id in param.Weapons)
        {
            spaceShip.WeaponSlots.Add(new WeaponSlot());
            var weapon = WeaponRepository.Create(id);
            spaceShip.WeaponSlots[^1].Set(weapon);
        }

        foreach (var id in param.Modules)
        {
            spaceShip.ModuleSlots.Add(new ModuleSlot());
            var module = ModuleRepository.Get(id);
            spaceShip.ModuleSlots[^1].Set(module);
        }

        return spaceShip;
    }
}