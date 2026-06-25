using System.Collections;
using UnityEngine;
public class MarketTrigger : MonoBehaviour
{
public GameObject collectSuppliesText;
public GameObject supplyPanel;
public AudioSource pickupSound;
private bool playerInMarket = false;
private bool collecting = false;
void Update()
{
    if (playerInMarket && !collecting)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(CollectSupplies());
        }
    }
}
IEnumerator CollectSupplies()
{
    collecting = true;
    collectSuppliesText.SetActive(false);
    supplyPanel.SetActive(true);
    yield return new WaitForSeconds(3f);
    if (pickupSound != null)
    {
        pickupSound.Play();
    }
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    if (player != null)
    {
        PlayerInventory inventory = player.GetComponent<PlayerInventory>();
        if (inventory != null)
        {
            inventory.hasSupplies = true;
        }
    }
    InventoryUI.Instance.ShowSupply();
    Debug.Log("Supplies Collected!");
    supplyPanel.SetActive(false);
    collecting = false;
}
private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        playerInMarket = true;

        if (!collecting)
        {
            collectSuppliesText.SetActive(true);
        }
    }
}
private void OnTriggerExit(Collider other)
{
    if (other.CompareTag("Player"))
    {
        playerInMarket = false;
        collectSuppliesText.SetActive(false);
    }
}
}
