using UnityEngine;

public class SettingWindowController : MonoBehaviour
{
    [SerializeField]
    private GameObject window;
    void Start()
    {
        DisableWindow();
    }

    public void EnableWindow()
    {
        window.SetActive(true);
    }

    public void DisableWindow()
    {
        window.SetActive(false);
    }
}
