using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectWeaponWidget : UIBehaviour
{
    [SerializeField] private SpaceShipController _spaceShip;
    [SerializeField] private int _weaponIndex;
    [SerializeField] private Dropdown _dropdown;

    private readonly List<string> _optionValueToWeaponId = new List<string>();

    protected override void Start()
    {
        _dropdown.options.Clear();

        foreach (var weaponId in WeaponRepository.All())
        {
            var newOptionValue = _dropdown.options.Count;
            _optionValueToWeaponId.Insert(newOptionValue, weaponId);

            var weaponName = WeaponRepository.GetName(weaponId);
            _dropdown.options.Add(new Dropdown.OptionData(weaponName));
        }

        // Hack for update dropdown from code.
        _dropdown.value = -1;
    }

    private void Update()
    {
        var slot = _spaceShip.Model.WeaponSlots[_weaponIndex];
        var selectedValueOption = _optionValueToWeaponId.FindIndex(id => slot.Weapon.Id == id);

        _dropdown.value = selectedValueOption;
    }
}