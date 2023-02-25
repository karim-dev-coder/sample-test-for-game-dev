using System;

public interface IWeapon : ICloneable
{
    public string Id { get; }
    public float Damage { get; }
    bool CanShoot();
    void Shoot(IEntity target);
}