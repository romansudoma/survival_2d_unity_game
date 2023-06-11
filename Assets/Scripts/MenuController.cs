using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartPressed()
    {
        SceneManager.LoadScene(1);
        Debug.Log("start");
    }

    public void ExitPressed()
    {
        Application.Quit();
        Debug.Log("exit");
    }

    public void PausePressed()
    {
        SceneManager.LoadScene(0);
        Debug.Log("pause");
    }
}
