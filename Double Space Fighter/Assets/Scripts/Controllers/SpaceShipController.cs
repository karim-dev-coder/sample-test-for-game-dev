using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] private string _name = "Some Spaceship";

    public SpaceShip Model { get; private set; }
    private AggressiveBehaviour _behaviour;

    void Start()
    {
        Model = new SpaceShip(_name);

        Model.WeaponSlots[0].Set(new SimpleWeapon(5, 3));

        Model.ModuleSlots[0].Set(new IncreaseHealth(30));
        _behaviour = new AggressiveBehaviour(Model);

        Debug.Log($"{Model} module initialized");
    }

    public void UpdateTick(float dt)
    {
        Model.Update(dt);
        _behaviour.Update(dt);
    }

    public override string ToString()
    {
        return Model.ToString();
    }
}