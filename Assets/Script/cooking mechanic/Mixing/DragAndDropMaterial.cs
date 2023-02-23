using UnityEngine;

public class DragAndDropMaterial : MonoBehaviour
{
    private bool _isDragging = false;
    private Vector3 _mousePosition;
    private Vector3 _defaultPosition;
    private bool _onBowl;

    private void Awake()
    {
        _defaultPosition = transform.position;
    }

    private void OnMouseDown()
    {
        if (!_onBowl)
        {
            _isDragging = true;
        }
    }

    private void OnMouseUp()
    {
        _isDragging = false;
    }

    private void FixedUpdate()
    {
        if (_isDragging)
        {
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _mousePosition.z = transform.position.z;
            transform.position = _mousePosition;
        }
        else
        {
            if (!_onBowl)
            {
                transform.position = _defaultPosition;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mixing/Bowl"))
        {
            _onBowl = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mixing/Bowl"))
        {
            _onBowl = false;
        }
    }
}
