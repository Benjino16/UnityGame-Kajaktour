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

    public override bool Use(PlayerStats playerStats)
    {
        playerStats.ModifyEnergy(energyRestore);
        return true;
    }
}
