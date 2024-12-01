using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventory_panel; // Reference to the Inventory Panel

    private bool isInventoryOpen = false; // Tracks if the inventory is open

    // Toggles the inventory panel visibility
    public void ToggleInventory()
    {   
        Debug.Log("Button clicked! Toggling inventory.");
        isInventoryOpen = !isInventoryOpen;
        inventory_panel.SetActive(isInventoryOpen);
    }
}
