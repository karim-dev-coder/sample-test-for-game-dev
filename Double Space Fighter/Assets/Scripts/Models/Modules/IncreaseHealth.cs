public class IncreaseHealth : IModule
{
    public string Id { get; }
    private readonly float _increaseValue;

    public IncreaseHealth(string id, float increaseValue)
    {
        Id = id;
        _increaseValue = increaseValue;
    }

    public override string ToString()
    {
        return $"Increase {_increaseValue} Health";
    }
}