public class WeaponCooldownReduce : IModule, IStatModifier
{
    public string Id { get; }
    private readonly float _decreasePercent;

    public WeaponCooldownReduce(string id, float decreasePercent)
    {
        Id = id;
        _decreasePercent = decreasePercent;
    }

    public float GetApplicatorValue()
    {
        return _decreasePercent;
    }

    public override string ToString()
    {
        return $"-{_decreasePercent * 100}% weapon cooldown";
    }
}