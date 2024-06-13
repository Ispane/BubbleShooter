using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ShootingRay : MonoBehaviour
{
    public int DefaultLenght;
    public int MaxReflectionCount;

    private List<Vector3> _hitPoints = new List<Vector3>();
    private LineRenderer _lineRenderer;
    private Camera _mainCamera;
    private Canvas _pauseCanvas, _endGameCanvas;

    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _mainCamera = Camera.main;

        _pauseCanvas = GameObject.Find("PauseCanvas").GetComponent<Canvas>();
        _endGameCanvas = GameObject.Find("EndGameCanvas").GetComponent<Canvas>();
    }

    void Update()
    {
        if (!_endGameCanvas.enabled && !_pauseCanvas.enabled)
        {
            if (Input.touchCount == 0 || !Input.GetMouseButton(0))
            {
                _lineRenderer.enabled = false;
            }

            if (Input.touchCount > 0 || Input.GetMouseButton(0))
            {
                _lineRenderer.enabled = true;
                RaycastWithReflection();
            }
        }  
    }

    private void RaycastWithReflection()
    {
        var mouseScreenPos = Input.mousePosition;
        var startingScreenPos = _mainCamera.WorldToScreenPoint(transform.position);
        mouseScreenPos.x -= startingScreenPos.x;
        mouseScreenPos.y -= startingScreenPos.y;
        var angle = Mathf.Atan2(mouseScreenPos.y, mouseScreenPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        _hitPoints.Clear();
        _hitPoints.Add(transform.position);

        Ray2D ray2D = new Ray2D(transform.position, transform.right);
        while (_hitPoints.Count <= MaxReflectionCount)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(ray2D.origin, ray2D.direction);
            if (hitInfo.collider != null)
            {
                _hitPoints.Add(hitInfo.point);
                ray2D.origin = hitInfo.point - ray2D.direction * 0.01f;
                ray2D.direction = Vector2.Reflect(ray2D.direction, hitInfo.normal);
            }
            else
            {
                _hitPoints.Add(ray2D.origin + ray2D.direction * DefaultLenght);
                break;
            }
        }

        _lineRenderer.positionCount = _hitPoints.Count;
        _lineRenderer.SetPositions(_hitPoints.ToArray());
    }
}
