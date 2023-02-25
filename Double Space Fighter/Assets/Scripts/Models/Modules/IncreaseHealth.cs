public class IncreaseHealth : IModule, IStatModifier<Health>
{
    public string Id { get; }
    private readonly float _increaseValue;

    public IncreaseHealth(string id, float increaseValue)
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
        return $"+{_increaseValue} Health";
    }
}