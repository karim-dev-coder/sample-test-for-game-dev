using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] private List<SpaceShipController> _spaceShips;

    [Header("Debug")] [SerializeField] private bool _manualUpdate;
    private readonly StringBuilder _lastTickLogs = new StringBuilder();

    private void Update()
    {
        if (_manualUpdate)
        {
            return;
        }

        var dt = Time.deltaTime;
        InternalUpdate(dt);
    }

    private void InternalUpdate(float dt)
    {
        foreach (var ship in _spaceShips)
        {
            ship.BehaviourUpdateTick(dt);
        }

        foreach (var ship in _spaceShips)
        {
            ship.ModelUpdateTick(dt);
        }
    }

    private void OnGUI()
    {
        if (!_manualUpdate)
        {
            return;
        }

        if (GUILayout.Button("Update Tick (1 sec)"))
        {
            _lastTickLogs.Clear();
            Application.logMessageReceived += OnLogMessageReceived;
            InternalUpdate(1);
            Application.logMessageReceived -= OnLogMessageReceived;
        }

        GUILayout.TextArea(_lastTickLogs.ToString(), GUILayout.ExpandWidth(true));
    }

    private void OnLogMessageReceived(string condition, string stacktrace, LogType type)
    {
        _lastTickLogs.AppendLine(condition);
    }
}