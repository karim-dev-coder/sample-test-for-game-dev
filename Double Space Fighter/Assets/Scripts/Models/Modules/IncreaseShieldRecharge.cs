public class IncreaseShieldRecharge : IModule, IStatModifier
{
    public string Id { get; }
    private readonly float _increaseRechargePercent;

    public IncreaseShieldRecharge(string id, float increaseRechargePercent)
    {
        Id = id;
        _increaseRechargePercent = increaseRechargePercent;
    }

    public float GetApplicatorValue()
    {
        return _increaseRechargePercent;
    }

    public override string ToString()
    {
        return $"-{_increaseRechargePercent * 100}% shield recharge";
    }
}