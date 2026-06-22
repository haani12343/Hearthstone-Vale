using TMPro;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI infoText;
    private void Awake()
    {
        Instance = this;
    }
    public void ShowMessage(string message)
    {
        infoText.text = message;
    }
}