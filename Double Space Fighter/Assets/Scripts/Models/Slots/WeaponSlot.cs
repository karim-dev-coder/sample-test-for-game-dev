public class WeaponSlot : ISlot<IWeapon>
{
    public IWeapon Weapon { get; private set; }

    public void Set(IWeapon weapon)
    {
        Weapon = weapon;
    }
}