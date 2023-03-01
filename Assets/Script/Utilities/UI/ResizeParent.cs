using UnityEngine;
using System.Collections.Generic;

public class ResizeParent : MonoBehaviour
{
    private RectTransform _parentRectTransform;
    [SerializeField] private int _totalChild;
    private List<RectTransform> _childRectTransforms = new List<RectTransform>();
    private float _totalChildHeight;

    private void Awake()
    {
        _parentRectTransform = GetComponent<RectTransform>();
        for (int i = 0; i < _totalChild; i++)
        {
            _childRectTransforms.Add(transform.GetChild(i).gameObject.GetComponent<RectTransform>());
        }
    }
    public void expand(GameObject expand)
    {
        if (!expand.activeSelf)
        {
            expand.SetActive(true);
            for (int i = 0; i < _childRectTransforms.Count; i++)
            {
                _totalChildHeight += _childRectTransforms[i].rect.height;
            }

            // Menyesuaikan ukuran parent dengan total tinggi child
            _parentRectTransform.sizeDelta = new Vector2(_parentRectTransform.rect.width, _totalChildHeight);
        }
        else
        {
            expand.SetActive(false);
            _totalChildHeight = 0;
            _parentRectTransform.sizeDelta = new Vector2(_parentRectTransform.rect.width, _childRectTransforms[0].rect.height);
        }

    }
}
