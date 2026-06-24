using System.Collections;
using UnityEngine;
public class Village : MonoBehaviour
{
    public string villageName;
    public GameObject deliverText;
    public GameObject deliveryPanel;
    private bool playerInVillage = false;
    private bool delivering = false;
    void Update()
    {
        if (playerInVillage && !delivering)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(DeliverSupplies());
            }
        }
    }
    IEnumerator DeliverSupplies()
    {
        PlayerInventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        PlayerMoney money = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoney>();
        if (inventory == null || money == null)
            yield break;
        if (!inventory.hasSupplies)
        {
            UIManager.Instance.ShowMessage("You don't have any supplies!");
            yield break;
        }
        if (DeliveryManager.Instance.currentVillage != villageName)
        {
            UIManager.Instance.ShowMessage("This village doesn't need supplies right now!");
            yield break;
        }
        delivering = true;
        deliverText.SetActive(false);
        deliveryPanel.SetActive(true);
        yield return new WaitForSeconds(3f);
        inventory.hasSupplies = false;
        money.coins += 10;
        UIManager.Instance.ShowMessage(
            "Delivered to " + villageName +
            "! Coins: " + money.coins
        );
        deliveryPanel.SetActive(false);
        DeliveryManager.Instance.DeliveryCompleted();
        delivering = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInVillage = true;
            deliverText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInVillage = false;
            deliverText.SetActive(false);
        }
    }
}