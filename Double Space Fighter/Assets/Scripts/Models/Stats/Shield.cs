public class Shield : IUpdatableStat
{
    public string Name => "Shield";
    public float Value { get; }

    private float _baseValue;

    public Shield(float baseValue, float rechargeInSec)
    {
        _baseValue = baseValue;
    }

    public void Update(double dt)
    {
    }

    public override string ToString()
    {
        return $"{Name}: {Value} (base: {_baseValue})";
    }
}