using UnityEngine;
using Smoothing.Ingredient;

namespace Smoothing.TouchKnive
{
    [RequireComponent(typeof(Animator), typeof(BoxCollider2D))]
    public class TouchKnive : MonoBehaviour
    {
        private Animator _animator;
        private IngredientSO _ingredientSO;
        enum kniveCond
        {
            vertical,
            horizontal
        }
        [SerializeField] private kniveCond _kniveCondition = kniveCond.vertical;


        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _ingredientSO = IngredientHandler.instance.getIngredientSO();
        }


        private void OnMouseDown()
        {
            if (_kniveCondition == kniveCond.horizontal)
            {
                _animator.SetTrigger("Smash Knive");
            }
            else
            {
                _animator.SetTrigger("Smash1 Knive");
            }
        }

        public void Smoothing()
        {
            _ingredientSO.totalSmothing++;
            _ingredientSO.smoothing = true;
        }
    }
}

