using UnityEngine;

namespace Mixing.Ingredient
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

            _ingredientSO = SceneHandler.instance.getIngredientSO();
        }

        private void Start()
        {
            _currentIngredient = Instantiate(_ingredientSO.mixingMaterial, _summonPost.position, Quaternion.identity);
        }
    }
}
