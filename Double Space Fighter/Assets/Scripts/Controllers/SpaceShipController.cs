using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    private readonly SpaceShip _model = new SpaceShip();

    void Start()
    {
        _model.WeaponSlots[0].Set(new SimpleWeapon(5, 3));

        _model.ModuleSlots[0].Set(new IncreaseHealth(30));
    }

    void Update()
    {
        _model.Update(Time.deltaTime);
    }
}