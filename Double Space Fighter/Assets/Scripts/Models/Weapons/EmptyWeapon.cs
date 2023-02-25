public class EmptyWeapon : IWeapon
{
    public const string ID = "empty";
    public string Id { get; } = ID;

    public float Damage => 0;


    public bool CanShoot()
    {
        return false;
    }

    public void Shoot(IEntity target)
    {
        return;
    }

    public object Clone()
    {
        return this;
    }

    public override string ToString()
    {
        return "Empty weapon";
    }
}