using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public GameObject openUIPrompt; // The "Press E to Open" UI
    public GameObject chestInventoryPanel; // The chest's inventory panel
    public GameObject playerInventoryPanel; // The player's inventory panel

    private bool isPlayerNearby = false;

    void Start()
    {
        openUIPrompt.SetActive(false); 
        chestInventoryPanel.SetActive(false); 
        playerInventoryPanel.SetActive(false); 
    }

    void Update()
    {
        // Check for "E" key to open the chest
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ToggleChestInventory();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure it's the player
        {
            isPlayerNearby = true;
            openUIPrompt.SetActive(true); // Show the "Press E" prompt
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            openUIPrompt.SetActive(false); // Hide the prompt
        }
    }

    private void ToggleChestInventory()
    {
        bool isActive = chestInventoryPanel.activeSelf;

        // Toggle the chest inventory panel and the player's inventory panel
        chestInventoryPanel.SetActive(!isActive);
        playerInventoryPanel.SetActive(!isActive);
    }
}
