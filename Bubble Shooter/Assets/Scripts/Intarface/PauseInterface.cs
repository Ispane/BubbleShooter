using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseInterface : MonoBehaviour
{
    private Canvas _pauseCanvas;

    private void Start()
    {
        _pauseCanvas = GameObject.Find("PauseCanvas").GetComponent<Canvas>();
        _pauseCanvas.enabled = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        _pauseCanvas.enabled = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _pauseCanvas.enabled = false;
    }

    public void Exit()
    {
        Time.timeScale = 1;
        _pauseCanvas.enabled = false;
        SceneManager.LoadScene("Levels");
    }
}
