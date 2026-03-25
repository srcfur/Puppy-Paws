using UnityEngine;

public class InventoryScreen : MonoBehaviour
{
    public static InventoryScreen instance;
    private Inventory currentInventory;
    private ItemStack heldStack;
    private GameObject heldobject;
    public bool IsOpen { get; private set; } = false;


    private void Start()
    {
        instance = this;
    }
    public void OpenInventory(Inventory inventory)
    {
        IsOpen = true; 
        currentInventory = inventory;
    }
    /// <summary>
    /// Called internally when an item starts being dragged
    /// </summary>
    /// <param name="gameobject"></param>
    /// <param name="stackindex"></param>
    public void DragObjectCallback(GameObject gameobject, int stackindex)
    {
        //Weird, not happening!
        if (currentInventory == null) return;
        //We won't pick you up because we already have a held item!
        if (heldStack != null) return;

        heldStack = currentInventory.Get(stackindex);
        //Make sure it's actually real :3
        if(heldStack == null) return;
        heldobject = gameobject;
        Debug.Log("Dragging " + gameobject.name);
    }
}
