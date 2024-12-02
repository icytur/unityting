using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public Button[] inventorySlots; // Buttons representing the player's inventory slots

    public void AddItem(Sprite itemSprite)
    {
        foreach (Button slot in inventorySlots)
        {
            if (slot.image.sprite == null) // Find an empty slot
            {
                slot.image.sprite = itemSprite; // Add the item
                return;
            }
        }
        Debug.Log("Player inventory is full!");
    }
}
