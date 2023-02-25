using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpaceShipDescriptionView : UIBehaviour
{
    [SerializeField] private SpaceShipController _spaceShip;
    [SerializeField] private Text _text;

    private readonly StringBuilder _descriptionSb = new StringBuilder();

    private void Update()
    {
        _descriptionSb.Clear();

        _descriptionSb.AppendLine($"{_spaceShip.Model.Name} (Target: {_spaceShip.Behaviour.Target})");
        foreach (var stat in _spaceShip.Model.Stats)
        {
            _descriptionSb.AppendLine(stat.ToString());
        }

        foreach (var slot in _spaceShip.Model.WeaponSlots)
        {
            _descriptionSb.AppendLine(slot.Weapon.ToString());
        }

        foreach (var slot in _spaceShip.Model.ModuleSlots)
        {
            _descriptionSb.AppendLine(slot.Module.ToString());
        }

        _text.text = _descriptionSb.ToString();
    }
}