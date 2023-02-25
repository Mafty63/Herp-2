using UnityEngine;
using Mixing.Timer;

public class DragAndDropMaterial : MonoBehaviour
{
    private bool _isDragging = false;
    private Vector3 _mousePosition;
    private Vector3 _defaultPosition;
    private bool _onBowl;
    [SerializeField] private string _materialName;
    private bool _onPosition;

    private void Awake()
    {
        _defaultPosition = transform.position;
        _onPosition = false;
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
        if (_isDragging) // if dragging
        {
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _mousePosition.z = transform.position.z;
            transform.position = _mousePosition;
        }
        else    // if dropped
        {
            if (!_onBowl)
            {
                transform.position = _defaultPosition;
            }
            else
            {
                if (!_onPosition)
                {
                    if (_materialName.ToUpper() == MaterialOrder.instance.getCurrentMaterialName())
                    {
                        MaterialOrder.instance.nextMaterial();
                        _onPosition = true;
                    }
                    else
                    {
                        transform.position = _defaultPosition;
                        MixingTimer.instance.plusCurrentTime(5);
                    }
                }
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
