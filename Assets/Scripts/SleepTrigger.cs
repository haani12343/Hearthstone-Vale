using System.Collections;
using UnityEngine;
public class SleepTrigger : MonoBehaviour
{
    public GameObject sleepText;
    public GameObject sleepPanel;
    public DayNightCycle dayNightCycle;
    bool playerInBedArea = false;
    bool sleeping = false;
    void Update()
    {
        if (playerInBedArea && !sleeping)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Sleep());
            }
        }
    }
    IEnumerator Sleep()
    {
        sleeping = true;
        sleepText.SetActive(false);
        sleepPanel.SetActive(true);
        yield return new WaitForSeconds(5f);
        dayNightCycle.SleepFor8Hours();
        sleepPanel.SetActive(false);
        sleeping = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInBedArea = true;
            sleepText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInBedArea = false;
            sleepText.SetActive(false);
        }
    }
}