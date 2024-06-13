using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private string _level;

    public void LoadLevel()
    {
        SceneManager.LoadScene(_level);
    }
}
