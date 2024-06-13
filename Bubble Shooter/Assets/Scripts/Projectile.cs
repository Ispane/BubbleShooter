using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour
{
    public string symbol;

    private BubblesQueue _bubblesQueue;
    private Shooting _shooting;

    private float _timeLeft = 0;
    private bool _timerOn = true;

    private void Start()
    {
        _bubblesQueue = GameObject.Find("BubblesQueue").GetComponent<BubblesQueue>();
        _shooting = GameObject.Find("BubblesSpawn").GetComponent<Shooting>();

        GetComponentInChildren<Text>().text = symbol;
    }

    private void FixedUpdate()
    {
        if (_timerOn)
        {
            if (_timeLeft < 2f)
                _timeLeft += Time.fixedDeltaTime;
            else
                _timerOn = false;
        }
        else
        {
            _bubblesQueue.AddNewBubble(symbol);
            _shooting.AddNewBubble(symbol);

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Equation")
        {
            collision.collider.GetComponent<Equation>().MissingSymbol = symbol;
            collision.collider.GetComponent<Equation>().SetMissingSymbol();

            BubbleDestroy();
        }
    }

    private void BubbleDestroy()
    {
        Destroy(gameObject);
    }
}
