using UnityEngine;


public enum ItemType
{
    Food,
    Placeable,
    Gear
}

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("General Settings:")]
    new public string name = "New Item";
    public Sprite icon = null;
    public ItemType type;

    public virtual bool Use(PlayerStats playerStats)
    {
        Debug.Log("Using active item...");
        return false;
    }
    
}