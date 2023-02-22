public class Health : IStat
{
    public string Name => "Health";
    public float Value => _baseValue;

    private readonly float _baseValue;

    public Health(float baseValue)
    {
        _baseValue = baseValue;
    }
}