public interface IWeapon
{
    public float Damage { get; }
    public float Cooldown { get; }
    bool CanShoot();
    void Shoot(IEntity target);
    void Update(float dt);
}