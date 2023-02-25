using System.Collections.Generic;

public static class WeaponRepository
{
    private static readonly Dictionary<string, IWeapon> _repository = new()
    {
        [EmptyWeapon.ID] = new EmptyWeapon(),
        ["weapon_5_dmg_3_cd"] = new SimpleWeapon("weapon_5_dmg_3_cd", 5, 3)
    };

    public static IWeapon Create(string id)
    {
        return (IWeapon) _repository[id].Clone();
    }

    public static string GetName(string id)
    {
        return _repository[id].ToString();
    }

    public static Dictionary<string, IWeapon>.KeyCollection All()
    {
        return _repository.Keys;
    }
}