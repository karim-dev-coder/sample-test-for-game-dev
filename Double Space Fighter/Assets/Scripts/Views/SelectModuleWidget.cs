using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectModuleWidget : UIBehaviour
{
    [SerializeField] private SpaceShipController _spaceShip;
    [SerializeField] private int _moduleIndex;
    [SerializeField] private Dropdown _dropdown;

    private readonly List<string> _optionValueToModuleId = new List<string>();

    protected override void Start()
    {
        _dropdown.options.Clear();

        foreach (var moduleId in ModuleRepository.All())
        {
            var newOptionValue = _dropdown.options.Count;
            _optionValueToModuleId.Insert(newOptionValue, moduleId);

            var moduleName = ModuleRepository.GetName(moduleId);
            _dropdown.options.Add(new Dropdown.OptionData(moduleName));
        }

        // Hack for update dropdown from code.
        _dropdown.value = -1;
    }

    private void Update()
    {
        var slot = _spaceShip.Model.ModuleSlots[_moduleIndex];
        var selectedValueOption = _optionValueToModuleId.FindIndex(id => slot.Module.Id == id);

        _dropdown.value = selectedValueOption;
    }
}