using UnityEngine;
using UnityEngine.UI;

public class SelectedObject : MonoBehaviour
{
    [SerializeField] private string _symbol;

    private BubblesQueue _bubblesQueue;
    private Shooting _shooting;

    private void Start()
    {
        _bubblesQueue = GameObject.Find("BubblesQueue").GetComponent<BubblesQueue>();
        _shooting = GameObject.Find("BubblesSpawn").GetComponent<Shooting>();

        GetComponentInChildren<Text>().text = _symbol;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _bubblesQueue.AddNewBubble(_symbol);
        _shooting.AddNewBubble(_symbol);

        Destroy(gameObject);
    }
}
