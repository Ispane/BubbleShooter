using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameCanvas : MonoBehaviour
{
    [SerializeField] private List<GameObject> _eqations = new List<GameObject>();

    public int _mistaceCount;
    public int _decidedCount;

    private int _mark;

    private Canvas _endGameCanvas;
    private Text _mistacesText;
    private Text _markText;
    private Text _textCurrentMark;
    private Text _textCurrentMistacesCount;

    private void Start()
    {
        _endGameCanvas = GameObject.Find("EndGameCanvas").GetComponent<Canvas>();
        _mistacesText = GameObject.Find("TextMistake").GetComponent<Text>();
        _markText = GameObject.Find("TextMark").GetComponent<Text>();
        _textCurrentMark = GameObject.Find("TextCurrentMark").GetComponent<Text>();
        _textCurrentMistacesCount = GameObject.Find("TextCurrentMistacesCount").GetComponent<Text>();

        _endGameCanvas.enabled = false;
    }

    private void Update()
    {
        if (_mistaceCount == 0)
            _mark = 5;
        if (_mistaceCount > 0 && _mistaceCount <= 2)
            _mark = 4;
        if (_mistaceCount > 2 && _mistaceCount <= 4)
            _mark = 3;
        if (_mistaceCount > 4)
            _mark = 2;

        _textCurrentMistacesCount.text = $"ќшибок: {_mistaceCount}";
        _textCurrentMark.text = $"ќценка: {_mark}";

        if (_eqations.Count == _decidedCount)
        {
            _endGameCanvas.enabled = true;

            Marks.ChangeMark(_mark, SceneManager.GetActiveScene().name);
            LoadSaveData.SaveData();

            _mistacesText.text = $"ќшибок: {_mistaceCount}";
            _markText.text = $"ќценка: {_mark}";
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("Levels");
    }
}
