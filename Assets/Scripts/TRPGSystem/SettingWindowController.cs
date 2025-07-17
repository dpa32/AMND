using UnityEngine;

public class SettingWindowController : MonoBehaviour
{
    [SerializeField]
    private GameObject window;
    void Start()
    {https://x.com/4determina_TION/status/1945735277030654028/quotes
        //DisableWindow();
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
