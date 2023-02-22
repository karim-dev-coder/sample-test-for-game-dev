public class IncreaseHealth : IModule
{
    private readonly float _increaseValue;

    public IncreaseHealth(float increaseValue)
    {
        _increaseValue = increaseValue;
    }
}