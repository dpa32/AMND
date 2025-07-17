using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public void Update()
    {
        if(Input.anyKey)
        {
            Debug.Log("here");
            SceneManager.LoadScene("MainPlayScene");
        }
    }
}
