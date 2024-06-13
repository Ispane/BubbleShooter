using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BubblesQueue : MonoBehaviour
{
    [SerializeField] private GameObject _bubbleImage;

    public List<Bubble> _bubbles;

    private List<GameObject> _bImagePrefabs = new List<GameObject>();

    private void Awake()
    {
        QueueIntarface();
    }

    private void QueueIntarface()
    {
        for (int i = 0; i < _bubbles.Count; i++)
        {
            var bubble = Instantiate(_bubbleImage, transform) as GameObject;
            bubble.GetComponentInChildren<Text>().text = _bubbles[i].Symbol;
            _bImagePrefabs.Add(bubble as GameObject);
        }
    }

    public void DestroyLastBubble()
    {
        if (_bImagePrefabs != null)
        {
            Destroy(_bImagePrefabs.Last());
            _bImagePrefabs.Remove(_bImagePrefabs.Last());
        }        
    }

    public void AddNewBubble(string symbol)
    {
        var bubble = Instantiate(_bubbleImage, transform) as GameObject;
        bubble.GetComponentInChildren<Text>().text = symbol;
        _bImagePrefabs.Add(bubble as GameObject);
    }
}

public enum BubbleType
{
    Standart
}

[System.Serializable]
public class Bubble
{
    public string Symbol;
    public BubbleType BubbleTypeType;
}

