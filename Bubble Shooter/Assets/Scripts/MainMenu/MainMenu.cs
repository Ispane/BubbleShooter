using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Levels");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Marks()
    {
        SceneManager.LoadScene("Marks");
    }
}
