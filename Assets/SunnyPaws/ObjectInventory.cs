using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectInventory : MonoBehaviour, Inventory
{
    private const float INVENTORY_CURVE_MULTIPLIER = 0.2f; //0.2f is similar to Animal Crossing New Horizons
    private const float INVENTORY_SLOT_SPACING = 1.1f;


    public int InventorySize = 27;
    public Sprite inventory_slot_icon;
    public List<ItemStack> inventory_slots = new List<ItemStack>();
    private List<GameObject> tracked_objects = new List<GameObject>();
    private bool inventoryIsOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetInventorySize(InventorySize);
    }
    /// <summary>
    /// WILL DROP OLD SLOTS!
    /// </summary>
    /// <param name="size"></param>
    public void SetInventorySize(int size)
    {
        InventorySize = size;
        inventory_slots = new List<ItemStack>();
    }
    public int GetInventorySize()
    {
        return InventorySize;
    }

    public ItemStack Get(int index)
    {
        return inventory_slots[index];
    }

    public void Set(int index, ItemStack item)
    {
        inventory_slots[index] = item;
    }
}
