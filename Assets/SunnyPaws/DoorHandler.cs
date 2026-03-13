
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour, InteractionInterest
{
    [SerializeField] private RoomDefinition target_room;
    [SerializeField] private Vector3 target_position;
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
        RoomHandler.singleton.LoadRoomDefinition(target_room);
        controller.transform.position = target_position;
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
