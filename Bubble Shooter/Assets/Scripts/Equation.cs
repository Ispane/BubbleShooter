using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Equation : MonoBehaviour
{
    public string MissingSymbol;
    [SerializeField] private List<string> _equation;
    [SerializeField] private GameObject _droppebleProjectilePrefab;

    private Text _text;
    private int _result;

    private BubblesQueue _bubblesQueue;
    private Shooting _shooting;

    private EndGameCanvas _endGameCanvas;

    private void Start()
    {
        _bubblesQueue = GameObject.Find("BubblesQueue").GetComponent<BubblesQueue>();
        _shooting = GameObject.Find("BubblesSpawn").GetComponent<Shooting>();
        _endGameCanvas = GameObject.Find("----UI----").GetComponent<EndGameCanvas>();

        _text = GetComponentInChildren<Text>();

        SetText();
    }

    public void SetMissingSymbol()
    {
        if (MissingSymbol != "+" && MissingSymbol != "-" && MissingSymbol != "*" && MissingSymbol != "/")
        {
            for (int i = 0; i < 1000; i++)
            {
                if (i.ToString() == MissingSymbol)
                {
                    for (int j = 0; j < _equation.Count; j++)
                    {
                        if (_equation[j] == "_")
                        {
                            _equation[j] = MissingSymbol;
                            if (!Calculations())
                            {
                                _equation[j] = "_";
                                _bubblesQueue.AddNewBubble(MissingSymbol);
                                _shooting.AddNewBubble(MissingSymbol);
                                _endGameCanvas._mistaceCount++;
                            }
                            else
                            {
                                _endGameCanvas._decidedCount++;
                                GetComponent<BoxCollider2D>().enabled= false;
                                GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);
                                _text.color = new Color(1, 1, 1, 0.3f);
                            }

                            break;
                        }
                    }
                    break;
                }
            }
        }

        SetText();
    }

    private void SetText()
    {
        _text.text = "";

        for (int i = 0; i < _equation.Count; i++)
        {
            _text.text += _equation[i];
        }
    }

    private bool Calculations()
    {
        _result = 0;
        List<int> list = new List<int>();

        for (int i = 0; i < _equation.Count; i++)
        {
            if (_equation[i] != "=" && _equation[i] != "+" && _equation[i] != "*" && _equation[i] != "/" && _equation[i] != "-")
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (_equation[i] == j.ToString())
                    {
                        list.Add(j);
                        break;
                    }
                }
            }
            else
                list.Add(0);
        }

        for (int j = 0; j < _equation.Count; j++)
        {
            if (_equation[j] == "*")
                _result += list[j - 1] * list[j + 1];
            if (_equation[j] == "/")
                _result += list[j - 1] / list[j + 1];
        }

        for (int j = 0; j < _equation.Count; j++)
        {
            if (_equation[j] == "+")
                _result += list[j - 1] + list[j + 1];
            if (_equation[j] == "-")
                _result += list[j - 1] - list[j + 1];
        }
        
        if(_result == list.Last())
            return true;
        else
            return false; 
    }
}
