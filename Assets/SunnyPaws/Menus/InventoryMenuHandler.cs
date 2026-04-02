using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuHandler : MenuHandler
{
    public Sprite InventoryHoverSprite;
    public Sprite TestSprite;
    public GameObject CreateInventoryObject()
    {
        GameObject invObject = new GameObject("InventoryObject");
        GameObject itemObject = new GameObject("ItemObject");
        itemObject.transform.SetParent(invObject.transform);
        Image SelectionSprite = invObject.AddComponent<Image>();
        SelectionSprite.sprite = InventoryHoverSprite;
        SelectionSprite.type = Image.Type.Sliced;

        Image ItemSprite = itemObject.AddComponent<Image>();
        SelectionSprite.type = Image.Type.Simple;
        ItemSprite.sprite = TestSprite;

        invObject.transform.SetParent(transform.Find("Inventory/InventoryRegion"));

        return invObject;
    }
    public override void CloseMenu()
    {
        
    }

    public override void OpenMenu()
    {
        CreateInventoryObject();
    }
}