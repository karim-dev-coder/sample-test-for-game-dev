using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    private readonly SpaceShip _model = new SpaceShip();
    private AggressiveBehaviour _behaviour;

    void Start()
    {
        _model.WeaponSlots[0].Set(new SimpleWeapon(5, 3));
        _behaviour = new AggressiveBehaviour(Model);

        _model.ModuleSlots[0].Set(new IncreaseHealth(30));
    public void UpdateTick(float dt)
    {
        Model.Update(dt);
        _behaviour.Update(dt);
    }

    {
    }
}