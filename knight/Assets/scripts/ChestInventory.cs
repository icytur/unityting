using UnityEngine;
using UnityEngine.UI;

public class ChestInventory : MonoBehaviour
{
    public Button[] itemSlots; // Buttons representing items in the chest
    public PlayerInventory playerInventory; // Reference to the player's inventory

    public void TransferItemToPlayer(int slotIndex)
    {
        if (itemSlots[slotIndex].image.sprite != null) // Ensure there's an item in the slot
        {
            // Transfer the item to the player's inventory
            playerInventory.AddItem(itemSlots[slotIndex].image.sprite);

            // Clear the chest slot
            itemSlots[slotIndex].image.sprite = null;
        }
    }
}
