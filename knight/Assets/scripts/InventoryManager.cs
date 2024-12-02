using UnityEngine;
using System.Collections;


public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel; // Reference to the Inventory Panel
    private Animator animator;        // Animator for the Inventory Panel
    private bool isInventoryOpen = false; // Tracks if the inventory is open

    void Start()
    {
        animator = inventoryPanel.GetComponent<Animator>();
    }

    public void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;

        if (isInventoryOpen)
        {
            inventoryPanel.SetActive(true);
            animator.Play("OpenInventory");
        }
        else
        {
            animator.Play("CloseInventory");
            StartCoroutine(HidePanelAfterAnimation());
        }
    }

    private IEnumerator HidePanelAfterAnimation()
    {
        yield return new WaitForSeconds(0.3f); // Match the animation duration
        inventoryPanel.SetActive(false);
    }
}
