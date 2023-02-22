using UnityEngine;

[RequireComponent(typeof(Animator), typeof(BoxCollider2D))]
public class TouchKnive : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private GameObject _knivePrefab;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {
        _animator.SetTrigger("Tilt Knive");
    }


    public void destroyKnive()
    {
        Destroy(gameObject);
        Instantiate(_knivePrefab, transform.position, Quaternion.identity);
    }
}

