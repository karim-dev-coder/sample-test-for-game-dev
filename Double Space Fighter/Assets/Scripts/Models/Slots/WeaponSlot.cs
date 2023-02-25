public class WeaponSlot : ISlot<IWeapon>
{
    public IWeapon Weapon { get; private set; } = new EmptyWeapon();

    public void Set(IWeapon weapon)
    {
        Weapon = weapon;
    }
}