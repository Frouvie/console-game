using UnityEngine;

public class MoveLeftCommand : ICommand
{
    public void Execute(GameObject gameObject)
    {
        PlayerMovement playerMovement = gameObject.GetComponent<PlayerMovement>();

        if (playerMovement == null)
        {
            Debug.Log($"There's no need component on object {gameObject.name}");
        }

        playerMovement.Move(Vector2.left);
    }
}
