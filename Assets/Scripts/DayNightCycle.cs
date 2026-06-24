using UnityEngine;
public class DayNightCycle : MonoBehaviour
{
    [Header("Sun")]
    public Light sun;
    [Header("Skyboxes")]
    public Material daySkybox;
    public Material nightSkybox;
    [Header("Settings")]
    public float dayLength = 120f;
    private bool isNight = false;
    void Update()
    {
        sun.transform.Rotate(Vector3.right * (360f / dayLength) * Time.deltaTime);
        UpdateLighting();
    }
    void UpdateLighting()
    {
        float angle = sun.transform.eulerAngles.x;
        if (angle > 180f && !isNight)
        {
            isNight = true;
            RenderSettings.skybox = nightSkybox;
            RenderSettings.ambientLight = new Color(0.15f, 0.15f, 0.25f);
            sun.intensity = 0.2f;
        }
        if (angle <= 180f && isNight)
        {
            isNight = false;
            RenderSettings.skybox = daySkybox;
            RenderSettings.ambientLight = Color.white;
            sun.intensity = 1f;
        }
    }
    public bool IsNight()
    {
        return isNight;
    }
    public void SkipToMorning()
    {
        sun.transform.rotation = Quaternion.Euler(30f, 0f, 0f);
        isNight = false;
        RenderSettings.skybox = daySkybox;
        RenderSettings.ambientLight = Color.white;
        sun.intensity = 1f;
    }
    public void SleepFor8Hours()
    {
        sun.transform.Rotate(120f, 0f, 0f);
        UpdateLighting();
    }
}