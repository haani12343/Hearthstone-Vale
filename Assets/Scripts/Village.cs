using UnityEngine;
public class Village : MonoBehaviour
{
    public string villageName;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            PlayerMoney money = other.GetComponent<PlayerMoney>();
            if (inventory == null || money == null)
                return;
            if (!inventory.hasSupplies)
            {
                UIManager.Instance.ShowMessage("You don't have any supplies!");
                return;
            }
            if (DeliveryManager.Instance.currentVillage != villageName)
            {
                UIManager.Instance.ShowMessage("This village doesn't need supplies right now!");
                return;
            }
            inventory.hasSupplies = false;
            money.coins += 10;
            UIManager.Instance.ShowMessage(
                "Delivered to " + villageName +
                "! Coins: " + money.coins
            );
            DeliveryManager.Instance.PickNewVillage();
        }
    }
}