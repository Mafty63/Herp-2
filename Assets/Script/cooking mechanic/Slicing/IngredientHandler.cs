using UnityEngine;

namespace Slicing.Ingredient
{
    public class IngredientHandler : MonoBehaviour
    {
        public static IngredientHandler instance;
        private GameObject _currentIngredient;
        [SerializeField] private IngredientSO _ingredientSO;
        [SerializeField] private Transform _summonPost;

        private void Awake()
        {
            //If we don't currently have a game control...
            if (instance == null)
                //...set this one to be it...
                instance = this;
            //...otherwise...
            else if (instance != this)
                //...destroy this one because it is a duplicate.
                Destroy(gameObject);

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

        public IngredientSO getIngredientSO()
        {
            return _ingredientSO;
        }
    }
}
