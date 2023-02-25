public interface IWeapon
{
    public string Id { get; }
    public float Damage { get; }
    bool CanShoot();
    void Shoot(IEntity target);
}