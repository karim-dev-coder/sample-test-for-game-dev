public class Shield : IUpdatableStat
{
    public string Name => "Shield";
    public float Value { get; }

    private float _baseValue;

    public Shield(float baseValue)
    {
        _baseValue = baseValue;
    }

    public void Update(double dt)
    {
        throw new System.NotImplementedException();
    }
}