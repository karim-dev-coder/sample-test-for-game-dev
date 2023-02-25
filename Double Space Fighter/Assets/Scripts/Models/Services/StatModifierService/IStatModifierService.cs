public interface IStatModifierService
{
    float GetAppliableValue<TStat>() where TStat : IStat;
    float GetAppliableModifierValue<TStatModifier>() where TStatModifier : IStatModifier;
}