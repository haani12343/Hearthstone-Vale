using UnityEngine;
public class DayNightCycle : MonoBehaviour
{
    public float dayLength = 300f;
    void Update()
    {
      transform.Rotate(Vector3.right * (360f / dayLength) * Time.deltaTime);
    }
}