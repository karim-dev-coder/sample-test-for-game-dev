using System;

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
        public int CountWeaponSlots;
        public int CountModuleSlots;

        public static Params Default =>
            new()
            {
                Health = 100,
                Shield = new ShieldParams(100, 1),
                CountWeaponSlots = 1,
                CountModuleSlots = 1
            };
    }

    public static SpaceShip Create(string name, Params param)
    {
        var spaceShip = new SpaceShip(name);

        spaceShip.Stats.Add(new Health(param.Health));
        spaceShip.Stats.Add(new Shield(param.Shield.Value, param.Shield.RechargeInSec));

        for (var i = 0; i < param.CountWeaponSlots; i++)
        {
            spaceShip.WeaponSlots.Add(new WeaponSlot());
        }

        for (var i = 0; i < param.CountModuleSlots; i++)
        {
            spaceShip.ModuleSlots.Add(new ModuleSlot());
        }

        return spaceShip;
    }
}