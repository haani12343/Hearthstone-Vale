using TMPro;
using UnityEngine;
public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI statsText;
    public PlayerInventory inventory;
    public PlayerMoney money;
    void Update()
    {
        statsText.text =
         "Coins: " + money.coins +
         "\nSupplies: " + (inventory.hasSupplies ? "Yes" : "No");
    }
}