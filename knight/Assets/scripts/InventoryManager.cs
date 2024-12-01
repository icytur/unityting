using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel; // Reference to the Inventory Panel

    private bool isInventoryOpen = false; // Tracks if the inventory is open

    // Toggles the inventory panel visibility
    public void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        inventoryPanel.SetActive(isInventoryOpen);
    }
}
