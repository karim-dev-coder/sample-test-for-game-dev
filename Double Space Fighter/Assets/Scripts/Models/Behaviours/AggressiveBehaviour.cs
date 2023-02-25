using System.Linq;
using UnityEngine;

public class AggressiveBehaviour
{
    public IEntity Target { get; private set; }

    private readonly SpaceShip _spaceShip;

    public AggressiveBehaviour(SpaceShip spaceShip)
    {
        _spaceShip = spaceShip;
    }

    public void Update(float dt)
    {
        if (Target == null)
        {
            FindTarget();
            return;
        }

        TryShoot(Target);
    }

    private void TryShoot(IEntity Target)
    {
        foreach (var weapon in _spaceShip.Weapons.Where(weapon => weapon.CanShoot()))
        {
            Debug.Log($"{_spaceShip} shoot to {Target} from {weapon} weapon");
            weapon.Shoot(Target, _spaceShip.ModificatorService);
        }
    }

    private void FindTarget()
    {
        var target = GameObject.FindObjectsOfType<SpaceShipController>().FirstOrDefault(controller => controller.Model != _spaceShip);
        if (target)
        {
            Target = target.Model;
            Debug.Log($"{_spaceShip} find target. It is {Target}");
        }
    }
}