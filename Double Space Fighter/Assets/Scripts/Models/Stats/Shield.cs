using System;
using UnityEngine;

public class Shield : IUpdatableStat
{
    public string Name => "Shield";

    public float Value
    {
        get => Mathf.Lerp(0, MaxValue, _percent);
        private set => _percent = Mathf.InverseLerp(0, MaxValue, value);
    }

    public float MaxValue => _baseMaxValue + _modifierService.GetAppliableValue<Shield>();
    public float RechargeInSec => _baseRechargeInSec;

    private readonly float _baseMaxValue;
    private readonly float _baseRechargeInSec;

    private readonly IStatModifierService _modifierService;
    private float _percent = 1;

    public Shield(float baseMaxValue, float rechargeInSec, IStatModifierService modifierService)
    {
        _baseRechargeInSec = rechargeInSec;
        _modifierService = modifierService;
        _baseMaxValue = baseMaxValue;
    }

    public void Update(float dt)
    {
        var rechargeValue = RechargeInSec * dt;
        Value += rechargeValue;
    }

    public override string ToString()
    {
        return $"{Name}: {Value} (max: {MaxValue})";
    }

    public float ReduceDamage(float damage)
    {
        var absorbedCapacity = Value;

        var absorbDamage = Math.Clamp(damage, 0, absorbedCapacity);
        damage -= absorbDamage;
        Value -= absorbDamage;

        return damage;
    }
}