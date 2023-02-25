public interface IHaveCooldown
{
    public float Cooldown { get; }
    void Update(float dt);
}