using UnityEngine;
using Peeling.Ingredient;

namespace Peeling.LineController
{
    [RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
    public class LineController : MonoBehaviour
    {
        private Vector3 _currentMousePosition;
        private Vector3 _firstMousePosition;
        private Vector3 _mouseDelta;
        [SerializeField] private float _minMouseDeltaOnLine;
        [SerializeField] private Transform _skinSummonPost;
        private IngredientSO _ingredientSO;
        private bool _onLine;

        private void Awake()
        {
            _ingredientSO = IngredientHandler.instance.getIngredientSO();
        }
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && _onLine)
            {
                // Mendapatkan posisi pointer mouse di dunia game
                _firstMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else if (Input.GetMouseButtonUp(0) && _onLine)
            {
                // Jika tombol kiri mouse tidak ditekan, reset posisi mouse
                _currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                _mouseDelta = _currentMousePosition - _firstMousePosition;
            }
            else
            {
                _mouseDelta.y = 100;
            }

            if (_onLine && _mouseDelta.y <= _minMouseDeltaOnLine)
            {
                Instantiate(_ingredientSO.skinPrefab, _skinSummonPost.position, Quaternion.Euler(0f, 0f, 90f));
                _ingredientSO.totalPeeled++;
                _ingredientSO.peeled = true;
            }

        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Peeling/Knive"))
            {
                _onLine = true;
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Peeling/Knive"))
            {
                _onLine = false;
            }
        }
    }
}