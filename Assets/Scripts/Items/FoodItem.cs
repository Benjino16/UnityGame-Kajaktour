using UnityEngine;


[CreateAssetMenu(fileName = "New Food Item", menuName = "Inventory/Food Item")]
public class FoodItem : Item
{
    [Space]
    [Header("Food Settings:")]
    public float energyRestore;
    public void Awake()
    {
        type = ItemType.Food;
    }
}
