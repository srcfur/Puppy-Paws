using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction action;
    float playerMovementSpeed = 1.0f;
    Vector3 playerDesiredMovementDirection = Vector3.zero;

    public RoomHandler current_room;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        action = InputSystem.actions["Move"];
    }

    // Update is called once per frame
    void Update()
    {
        playerDesiredMovementDirection = new Vector3(action.ReadValue<Vector2>().x, action.ReadValue<Vector2>().y, 0);
        using (InteractionRegistry.InteractionsResult allInteractionsSortedByDistance = InteractionRegistry.singleton.getAllInterests().sortByDistance(transform.position))
        {
            if (allInteractionsSortedByDistance.count > 0)
            {
                if (InputSystem.actions["Interact"].WasPressedThisFrame() && allInteractionsSortedByDistance.interests[0].canInteract(this))
                {
                    allInteractionsSortedByDistance.interests[0].interact(this);
                }
                GetComponent<Animator>().SetBool("CanInteract", allInteractionsSortedByDistance.interests[0].canInteract(this));
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            using (InteractionRegistry.InteractionsResult allInteractionsSortedByDistance = InteractionRegistry.singleton.getAllInterests().sortByDistance(transform.position))
            {
                if (allInteractionsSortedByDistance.count > 0)
                {
                    InteractionInterest interest = allInteractionsSortedByDistance.interests[0];
                    Gizmos.DrawCube(interest.getGameObject().transform.position, Vector3.one * 0.1f);
                }
            }
        }
    }
    public void FixedUpdate()
    {
        transform.position += playerDesiredMovementDirection * Time.fixedDeltaTime * playerMovementSpeed;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }
}
