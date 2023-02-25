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

        _descriptionSb.AppendLine(_spaceShip.Model.Name);
        foreach (var stat in _spaceShip.Model.Stats)
        {
            _descriptionSb.AppendLine(stat.ToString());
        }

        foreach (var slot in _spaceShip.Model.WeaponSlots)
        {
            var label = $"Weapon: {slot.Weapon}";
            _descriptionSb.AppendLine(label);
        }

        foreach (var slot in _spaceShip.Model.ModuleSlots)
        {
            var label = $"Module: {slot.Module}";
            _descriptionSb.AppendLine(label);
        }

        _text.text = _descriptionSb.ToString();
    }
}