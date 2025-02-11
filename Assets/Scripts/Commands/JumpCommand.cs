using UnityEngine;

public class JumpCommand : ICommand
{
    public void Execute(GameObject gameObject)
    {
        PlayerMovement playerMovement = gameObject.GetComponent<PlayerMovement>();

        if (playerMovement == null)
        {
            Debug.Log($"There's no need component on object {gameObject.name}");
        }

        playerMovement.Jump();
    }
}
