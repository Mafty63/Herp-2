using UnityEngine;

public class IngredientHandler : MonoBehaviour
{
    private GameObject _currentIngredient;
    [SerializeField] private IngredientSO _ingredientSO;
    [SerializeField] private Transform _summonPost;

    private void Awake()
    {
        _currentIngredient = Instantiate(_ingredientSO.slicedMaterial[_ingredientSO.totalSliced], _summonPost.position, Quaternion.identity);
    }
    void Update()
    {
        if (_ingredientSO.sliced)
        {
            Destroy(_currentIngredient);
            _currentIngredient = Instantiate(_ingredientSO.slicedMaterial[_ingredientSO.totalSliced], _summonPost.position, Quaternion.identity);
            _ingredientSO.sliced = false;
        }
        if (_ingredientSO.totalSliced >= 4)
        {
            _ingredientSO.totalSliced = 0;
        }
    }
}
