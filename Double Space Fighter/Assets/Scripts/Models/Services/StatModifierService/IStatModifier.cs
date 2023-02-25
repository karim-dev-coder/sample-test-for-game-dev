public interface IStatModifier<TStat> where TStat : IStat
{
    float GetApplicatorValue();
}

public interface IStatModifier
{
    float GetApplicatorValue();
}