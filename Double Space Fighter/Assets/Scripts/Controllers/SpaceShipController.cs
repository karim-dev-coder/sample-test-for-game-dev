using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    [SerializeField] private string _name = "Some Spaceship";
    [SerializeField] private SpaceShipFactory.Params _params = SpaceShipFactory.Params.Default;

    public SpaceShip Model { get; private set; }
    public AggressiveBehaviour Behaviour { get; private set; }

    void Start()
    {
        Model = SpaceShipFactory.Create(_name, _params);
        Behaviour = new AggressiveBehaviour(Model);

        Model.WeaponSlots[0].Set(WeaponRepository.Create("weapon_5_dmg_3_cd"));
        Model.ModuleSlots[0].Set(ModuleRepository.Get("increase_50_health"));

        Debug.Log($"{Model} module initialized");
    }

    public void BehaviourUpdateTick(float dt)
    {
        Behaviour.Update(dt);
    }

    public void ModelUpdateTick(float dt)
    {
        Model.Update(dt);
    }

    public override string ToString()
    {
        return Model.ToString();
    }
}