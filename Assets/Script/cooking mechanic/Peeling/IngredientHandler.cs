using UnityEngine;

namespace Peeling.Ingredient
{
    public class IngredientHandler : MonoBehaviour
    {
        public static IngredientHandler instance;
        private GameObject _currentIngredient;
        [SerializeField] private IngredientSO _ingredientSO;
        [SerializeField] private Transform _summonPost;
        private bool _changeSide;
        private int _oneBeat;

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
            _ingredientSO.totalPeeled = 0;
            _oneBeat = 0;
            _changeSide = false;
            _currentIngredient = Instantiate(_ingredientSO.peelingMaterialSide1[_ingredientSO.totalPeeled], _summonPost.position, Quaternion.identity);
        }
        void Update()
        {
            if (!_changeSide)
            {
                if (_ingredientSO.peeled)
                {
                    Destroy(_currentIngredient);
                    _currentIngredient = Instantiate(_ingredientSO.peelingMaterialSide1[_ingredientSO.totalPeeled], _summonPost.position, Quaternion.identity);
                    _ingredientSO.peeled = false;
                }
                if (_ingredientSO.totalPeeled == (_ingredientSO.peelingMaterialSide1.Count - 1))
                {
                    _ingredientSO.totalPeeled = 0;
                }
            }
            else
            {
                if (_ingredientSO.peeled || _oneBeat == 0) // one beat is used to trigger summon one time after fliping
                {
                    Destroy(_currentIngredient);
                    _currentIngredient = Instantiate(_ingredientSO.peelingMaterialSide2[_ingredientSO.totalPeeled], _summonPost.position, Quaternion.identity);
                    _ingredientSO.peeled = false;
                    _oneBeat = 1;
                }
                if (_ingredientSO.totalPeeled == (_ingredientSO.peelingMaterialSide2.Count - 1))
                {
                    _ingredientSO.totalPeeled = 0;
                    SceneHandler.instance.NextStep();
                }
            }
        }

        public IngredientSO getIngredientSO()
        {
            return _ingredientSO;
        }

        public void changeSide()
        {
            _changeSide = true;
        }
    }
}
