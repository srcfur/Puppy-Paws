using System.Collections.Generic;
using UnityEngine;

public static class ItemRegistry
{
    private static Dictionary<string, ItemFactory> allFactories = new Dictionary<string, ItemFactory>();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns>Inventory ready gameobject, may be null if error parsing</returns>
    public static GameObject? getItemInventory( ItemData data )
    {
        if(!allFactories.ContainsKey( data.Class ))
        {
            Debug.LogError("No class : " + data.Class);
            return null;
        }
        GameObject itemInventory = new GameObject();
        allFactories[data.Class].Inventory(itemInventory, data);
        return itemInventory;
    }
}
public interface ItemFactory
{
    public void Inventory(GameObject item, ItemData data);
}