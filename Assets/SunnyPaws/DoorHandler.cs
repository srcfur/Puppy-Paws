
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour, InteractionInterest
{
    private List<GameObject> gameObjectsInArea = new List<GameObject>();
    public bool canInteract(PlayerController controller)
    {
        return gameObjectsInArea.Contains(controller.gameObject);
    }

    public GameObject getGameObject()
    {
        return gameObject;
    }

    public void interact(PlayerController controller)
    {
        RoomHandler.singleton.LoadRoomDefinition(new RoomDefinition() { scene_id = "TEST_WC" });
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InteractionRegistry.singleton.Register(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        InteractionRegistry.singleton.Unregister(this);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        gameObjectsInArea.Add(collision.gameObject);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        gameObjectsInArea.Remove(collision.gameObject);
    }
}
