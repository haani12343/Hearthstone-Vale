using UnityEngine;
public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance;
    public string currentVillage;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        PickNewVillage();
    }
    public void PickNewVillage()
    {
        if (Random.Range(0, 2) == 0)
            currentVillage = "Village 1st";
        else
        currentVillage = "Village 2nd";
        UIManager.Instance.ShowMessage(currentVillage + " needs supplies!");
    }
}