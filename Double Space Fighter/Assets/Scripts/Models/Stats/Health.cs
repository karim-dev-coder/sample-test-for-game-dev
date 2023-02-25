using System;

public class Health : IStat
{
    public string Name => "Health";
    public float Value => _currentValue;

    private readonly float _maxValue;
    private float _currentValue;

    public Health(float maxValue)
    {
        _maxValue = maxValue;
        _currentValue = maxValue;
    }

    public void TakeDamage(float damage)
    {
        // Guard.
        damage = Math.Clamp(damage, 0, Math.Abs(damage));
        _currentValue -= damage;
    }

    public override string ToString()
    {
        return $"{Name}: {Value} (max: {_maxValue})";
    }
}