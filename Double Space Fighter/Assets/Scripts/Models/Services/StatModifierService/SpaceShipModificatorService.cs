using System.Linq;

public class SpaceShipModificatorService : IStatModifierService
{
    private readonly SpaceShip _spaceShip;

    public SpaceShipModificatorService(SpaceShip spaceShip)
    {
        _spaceShip = spaceShip;
    }

    public float GetAppliableValue<TStat>() where TStat : IStat
    {
        var applicableValue = _spaceShip.ModuleSlots
            .Select(slot => slot.Module)
            .OfType<IStatModifier<TStat>>()
            .Sum(modifier => modifier.GetApplicatorValue());

        return applicableValue;
    }
}