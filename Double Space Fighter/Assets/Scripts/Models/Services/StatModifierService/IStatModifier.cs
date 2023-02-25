public interface IStatModifier<TStat> where TStat : IStat
{
    float GetApplicatorValue();
}