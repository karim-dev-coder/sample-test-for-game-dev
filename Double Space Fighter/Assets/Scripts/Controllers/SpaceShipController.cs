using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] private string _name = "Some Spaceship";
    [SerializeField] private SpaceShipFactory.Params _params = SpaceShipFactory.Params.Default;

    public SpaceShip Model { get; private set; }
    private AggressiveBehaviour _behaviour;

    void Start()
    {
        Model = SpaceShipFactory.Create(_name, _params);
        _behaviour = new AggressiveBehaviour(Model);

        Model.WeaponSlots[0].Set(WeaponRepository.Get("weapon_5_dmg_3_cd"));
        Model.ModuleSlots[0].Set(ModuleRepository.Get("increase_50_health"));

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