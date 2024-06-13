using UnityEngine;

public class MovementEquation : MonoBehaviour
{
    private enum moveDirection
    {
        fromTopToBottom,
        fromBottomToTop,
        fromLeftToRight,
        fromRightToLeft,
        none
    }

    [SerializeField] private moveDirection _moveDirection;
    [SerializeField] private float _speed;
    [SerializeField] private float _distance = 0;
    private bool _timerOn = true;
    private float _time;

    private void FixedUpdate()
    {
        if(_moveDirection == moveDirection.fromTopToBottom)
        {
            RectTransform rect = transform as RectTransform;
            if (_timerOn)
            {
                _time += Time.fixedDeltaTime;
                if (_time >= _distance)
                {
                    _timerOn = false;
                    _time = 0;
                }
                rect.anchoredPosition += new Vector2(0, _speed);
            }
            else
            {
                _time += Time.fixedDeltaTime;
                if (_time >= _distance)
                {
                    _timerOn = true;
                    _time = 0;
                }
                rect.anchoredPosition -= new Vector2(0, _speed);
            }
        }
        else if (_moveDirection == moveDirection.fromBottomToTop)
        {
            RectTransform rect = transform as RectTransform;
            if (_timerOn)
            {
                _time += Time.fixedDeltaTime;
                if (_time >= _distance)
                {
                    _timerOn = false;
                    _time = 0;
                }
                rect.anchoredPosition -= new Vector2(0, _speed);
            }
            else
            {
                _time += Time.fixedDeltaTime;
                if (_time >= _distance)
                {
                    _timerOn = true;
                    _time = 0;
                }
                rect.anchoredPosition += new Vector2(0, _speed);
            }
        }
        else if(_moveDirection == moveDirection.fromLeftToRight)
        {
            RectTransform rect = transform as RectTransform;
            if (_timerOn)
            {
                _time += Time.fixedDeltaTime;
                if (_time >= _distance)
                {
                    _timerOn = false;
                    _time = 0;
                }
                rect.anchoredPosition += new Vector2(_speed, 0);
            }
            else
            {
                _time += Time.fixedDeltaTime;
                if (_time >= _distance)
                {
                    _timerOn = true;
                    _time = 0;
                }
                rect.anchoredPosition -= new Vector2(_speed, 0);
            }
        }
        else if (_moveDirection == moveDirection.fromRightToLeft)
        {
            RectTransform rect = transform as RectTransform;
            if (_timerOn)
            {
                _time += Time.fixedDeltaTime;
                if (_time >= _distance)
                {
                    _timerOn = false;
                    _time = 0;
                }
                rect.anchoredPosition -= new Vector2(_speed, 0);
            }
            else
            {
                _time += Time.fixedDeltaTime;
                if (_time >= _distance)
                {
                    _timerOn = true;
                    _time = 0;
                }
                rect.anchoredPosition += new Vector2(_speed, 0);
            }
        }
    }
}
