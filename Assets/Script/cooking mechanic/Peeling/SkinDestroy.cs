using UnityEngine;

public class SkinDestroy : MonoBehaviour
{
    void Awake()
    {
        Destroy(gameObject, 5);
    }
}
