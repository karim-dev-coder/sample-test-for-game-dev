public interface IStatModifierService
{
    float GetAppliableValue<TStat>() where TStat : IStat;
}