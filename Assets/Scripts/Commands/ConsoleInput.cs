using UnityEngine;

public class ConsoleInput : MonoBehaviour
{
    [SerializeField] private CommandParser _commandParser;

    public void OnEndEdit(string command)
    {
        _commandParser.ExecuteCommand(command);
    }
}
