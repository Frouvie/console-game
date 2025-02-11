using System.Collections.Generic;
using UnityEngine;

public class CommandParser : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Dictionary<string, ICommand> _commands;

    private void Awake()
    {
        _commands = new Dictionary<string, ICommand>()
        {
            {"left", new MoveLeftCommand()},
            {"right", new MoveRightCommand()},
            {"stop", new MoveStopCommand()},
            {"jump", new JumpCommand()},
            {"attack", new AttackCommand()},
            {"interact", new InteractCommand()}
        };
    }

    public void ExecuteCommand(string command)
    {
        if (!_commands.ContainsKey(command.ToLower()))
        {
            return;
        }

        _commands[command.ToLower()].Execute(_player);
    }
}
