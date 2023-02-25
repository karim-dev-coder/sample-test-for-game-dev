public class IncreaseShield : IModule, IStatModifier<Shield>
{
    public string Id { get; }
    private readonly float _increaseValue;

    public IncreaseShield(string id, float increaseValue)
    {
        Id = id;
        _increaseValue = increaseValue;
    }

    public float GetApplicatorValue()
    {
        return _increaseValue;
    }

    public override string ToString()
    {
        return $"+{_increaseValue} Shield";
    }
}