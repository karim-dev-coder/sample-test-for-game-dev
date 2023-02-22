public class AggressiveBehaviour
{
    public IEntity Target { get; set; }

    private readonly SpaceShip _spaceShip;

    public AggressiveBehaviour(SpaceShip spaceShip)
    {
        _spaceShip = spaceShip;
    }

    public void Update(float dt)
    {
        if (Target != null)
        {
            _spaceShip.ShootIfCan(Target);
        }
    }
}