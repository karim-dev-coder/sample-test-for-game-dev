using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] private List<SpaceShipController> _spaceShips;

    [Header("Debug")] [SerializeField] private bool _manualUpdate;
    [SerializeField] private float _debugDt = 1;

    private readonly StringBuilder _lastTickLogs = new StringBuilder();
    private bool _isGameOver;

    private void Update()
    {
        if (_isGameOver)
        {
            return;
        }

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

        foreach (var ship in _spaceShips)
        {
            if (ship.Model.Stats.Health.Value <= 0)
            {
                Debug.Log($"{ship} has been destroyed");
                _isGameOver = true;
            }
        }
    }

    private void OnGUI()
    {
        if (!_manualUpdate)
        {
            return;
        }

        if (GUILayout.Button($"Update Tick ({_debugDt} sec)"))
        {
            _lastTickLogs.Clear();
            Application.logMessageReceived += OnLogMessageReceived;
            InternalUpdate(_debugDt);
            Application.logMessageReceived -= OnLogMessageReceived;
        }

        GUILayout.TextArea(_lastTickLogs.ToString(), GUILayout.ExpandWidth(true));
    }

    private void OnLogMessageReceived(string condition, string stacktrace, LogType type)
    {
        _lastTickLogs.AppendLine(condition);
    }
}