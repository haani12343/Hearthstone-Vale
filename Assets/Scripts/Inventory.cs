using UnityEngine;
public class InventoryUI : MonoBehaviour
{
    public static InventoryUI Instance;
    public GameObject supplyIcon;
    private void Awake()
    {
        Instance = this;
    }
    public void ShowSupply()
    {
        supplyIcon.SetActive(true);
    }
    public void HideSupply()
    {
        supplyIcon.SetActive(false);
    }
}