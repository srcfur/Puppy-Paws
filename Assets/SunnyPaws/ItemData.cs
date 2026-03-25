using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Sunny Paws/Item")]
public class ItemData : ScriptableObject
{
    public string Name;
    public string Description;
    public string Class;
    public Sprite InventorySprite;
}
