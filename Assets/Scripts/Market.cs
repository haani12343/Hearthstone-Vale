using UnityEngine;
public class Market : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.hasSupplies = true;
                UIManager.Instance.ShowMessage("Supplies Collected!");
            }
        }
    }
}