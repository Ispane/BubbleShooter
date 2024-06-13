using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsInterface : MonoBehaviour
{
    public void ExitLevelsScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
