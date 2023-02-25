using System;

public class Health : IStat
{
    public string Name => "Health";
    public float Value => MaxValue - _reducedHealth;
    public float MaxValue => _baseMaxValue + _modifierService.GetAppliableValue<Health>();

    private readonly IStatModifierService _modifierService;

    private readonly float _baseMaxValue;
    private float _reducedHealth;

    public Health(float maxValue, IStatModifierService modifierService)
    {
        _modifierService = modifierService;
        _baseMaxValue = maxValue;
        _reducedHealth = 0;
    }

    public void TakeDamage(float damage)
    {
        // Guard.
        damage = Math.Clamp(damage, 0, Math.Abs(damage));
        _reducedHealth += damage;
    }

    public override string ToString()
    {
        return $"{Name}: {Value} (max: {MaxValue})";
    }
}