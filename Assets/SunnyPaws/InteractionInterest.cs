using UnityEngine;

public interface InteractionInterest
{
    public GameObject getGameObject();
    public bool canInteract(PlayerController controller);
    public void interact(PlayerController controller);
}
