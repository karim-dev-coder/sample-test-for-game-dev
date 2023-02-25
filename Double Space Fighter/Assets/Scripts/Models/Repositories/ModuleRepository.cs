using System.Collections.Generic;

public static class ModuleRepository
{
    private static readonly Dictionary<string, IModule> _repository = new()
    {
        [EmptyModule.ID] = new EmptyModule(),
        ["increase_50_health"] = new IncreaseHealth("increase_50_health", 50),
        ["increase_50_shield"] = new IncreaseShield("increase_50_shield", 50),
        ["decrease_20_percent_weapon_cooldown"] = new WeaponCooldownReduce("decrease_20_percent_weapon_cooldown", 0.9f),
    };

    public static IModule Get(string id)
    {
        return _repository[id];
    }

    public static string GetName(string id)
    {
        return _repository[id].ToString();
    }

    public static Dictionary<string, IModule>.KeyCollection All()
    {
        return _repository.Keys;
    }
}