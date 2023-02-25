public interface IUpdatableStat : IStat
{
    void Update(float dt, IStatModifierService modifierService);
}