using UnityEngine;

public class Health : IStat
{
    public string Name => "Health";

    public float Value
    {
        get => Mathf.Lerp(0, MaxValue, _percent);
        private set => _percent = Mathf.InverseLerp(0, MaxValue, value);
    }

    public float MaxValue => _baseMaxValue + _modifierService.GetAppliableValue<Health>();

    private readonly IStatModifierService _modifierService;

    private readonly float _baseMaxValue;
    private float _percent = 1;

    public Health(float maxValue, IStatModifierService modifierService)
    {
        _modifierService = modifierService;
        _baseMaxValue = maxValue;
    }

    public void TakeDamage(float damage)
    {
        Value -= damage;
    }

    public override string ToString()
    {
        return $"{Name}: {Value} (max: {MaxValue})";
    }
}