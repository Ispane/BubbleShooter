using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Marks : MonoBehaviour
{
    [SerializeField] private GameObject _textPrefab;

    private void Start()
    {
        for (int i = 0; i < LoadSaveData.marks.Count; i++)
        {
            var levelMark = Instantiate(_textPrefab, transform) as GameObject;
            if (LoadSaveData.marks[i] != 0)
                levelMark.GetComponent<Text>().text = $"Уровень {i + 1} - оценка: {LoadSaveData.marks[i]}";
            else
                levelMark.GetComponent<Text>().text = $"Уровень {i + 1} - оценки нет";
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (LoadSaveData.marks[i] != 0)
                transform.GetChild(i).gameObject.GetComponent<Text>().text = $"Уровень {i + 1} - оценка: {LoadSaveData.marks[i]}";
            else
                transform.GetChild(i).gameObject.GetComponent<Text>().text = $"Уровень {i + 1} - оценки нет";
        }
    }

    public static void ChangeMark(int mark, string levelNumber)
    {
        for (int i = 0; i < LoadSaveData.marks.Count; i++)
        {
            if ((i+1).ToString() == levelNumber)
                LoadSaveData.marks[i] = mark;
        }
    }

    public void ReturnBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
