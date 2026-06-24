using UnityEngine;
public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance;
    public string currentVillage;
    public GameObject village1Marker;
    public GameObject village2Marker;
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
        village1Marker.SetActive(false);
        village2Marker.SetActive(false);
        if (Random.Range(0, 2) == 0)
        {
            currentVillage = "Village 1st";
            village1Marker.SetActive(true);
        }
        else
        {
            currentVillage = "Village 2nd";
            village2Marker.SetActive(true);
        }
        UIManager.Instance.ShowMessage(currentVillage + " needs supplies!");
    }
    public void DeliveryCompleted()
    {
        village1Marker.SetActive(false);
        village2Marker.SetActive(false);
        PickNewVillage();
    }
}