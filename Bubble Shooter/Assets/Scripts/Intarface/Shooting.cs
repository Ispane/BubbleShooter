using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _bubblePrefab;
    private List<Bubble> _bubblesQueueList = new List<Bubble>();
    private BubblesQueue _bubblesQueue;

    private Camera _mainCamera;
    private Text _projectileSymbol;
    private Canvas _pauseCanvas, _endGameCanvas;

    private float _timeLeft = 0f;
    private bool _timerOn = false;

    private void Start()
    {
        _mainCamera = Camera.main;
        _projectileSymbol = GetComponentInChildren<Text>();
        _bubblesQueue = GameObject.Find("BubblesQueue").GetComponent<BubblesQueue>();
        _bubblesQueueList = _bubblesQueue.GetComponent<BubblesQueue>()._bubbles; 
        _pauseCanvas = GameObject.Find("PauseCanvas").GetComponent<Canvas>();
        _endGameCanvas = GameObject.Find("EndGameCanvas").GetComponent<Canvas>();
    }

    private void FixedUpdate()
    {
        if (!_endGameCanvas.enabled && !_pauseCanvas.enabled)
        {
            if (_timerOn)
            {
                if (_timeLeft > 0)
                {
                    _timeLeft -= Time.fixedDeltaTime;
                }
                else
                {
                    _timeLeft = 0.5f;
                    _timerOn = false;
                }
            }
        }
    }

    private void Update()
    {
        if(_bubblesQueueList.Count > 0)
            _projectileSymbol.text = _bubblesQueueList.Last().Symbol;

        if (!_endGameCanvas.enabled && !_pauseCanvas.enabled)
        {
            if (!_timerOn)
            {
                if (Input.touchCount > 0)
                {
                    RotateToClick();

                    if (Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        if (_bubblesQueueList.Count > 0)
                        {
                            var bubble = Instantiate(_bubblePrefab) as GameObject;
                            _bubblesQueue.DestroyLastBubble();
                            bubble.transform.position = transform.position;
                            bubble.GetComponent<Projectile>().symbol = _bubblesQueueList.Last().Symbol;
                            _bubblesQueueList.Remove(_bubblesQueueList.Last());
                            bubble.GetComponent<Rigidbody2D>().velocity = transform.up * Time.fixedDeltaTime * 500;

                            _bubblesQueueList = _bubblesQueue.GetComponent<BubblesQueue>()._bubbles;

                            _timerOn = true;
                        }
                    }
                }
                else
                {
                    if (Input.GetMouseButton(0))
                    {
                        RotateToClick();
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        if (_bubblesQueueList.Count > 0)
                        {
                            var bubble = Instantiate(_bubblePrefab) as GameObject;
                            _bubblesQueue.DestroyLastBubble();
                            bubble.transform.position = transform.position;
                            bubble.GetComponent<Projectile>().symbol = _bubblesQueueList.Last().Symbol;
                            _bubblesQueueList.Remove(_bubblesQueueList.Last());
                            bubble.GetComponent<Rigidbody2D>().velocity = transform.up * Time.fixedDeltaTime * 500;

                            _bubblesQueueList = _bubblesQueue.GetComponent<BubblesQueue>()._bubbles;

                            _timerOn = true;
                        }
                    }
                }
            }
        }
    }

    public void AddNewBubble(string symbol)
    {
        Bubble bubble = new Bubble();
        bubble.Symbol = symbol;
        _bubblesQueueList.Add(bubble);
    }

    void RotateToClick()
    {
        var mouseScreenPos = Input.mousePosition;
        var startingScreenPos = _mainCamera.WorldToScreenPoint(transform.position);
        mouseScreenPos.x -= startingScreenPos.x;
        mouseScreenPos.y -= startingScreenPos.y;
        var angle = Mathf.Atan2(mouseScreenPos.y, mouseScreenPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
    }
}
