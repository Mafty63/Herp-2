using UnityEngine;
using UnityEngine.UI;

namespace Mixing.Timer
{
    public class SlicingTimer : MonoBehaviour
    {
        private Slider _slider;
        [Header("Coutdown time in second")]
        [SerializeField] private float _timer;
        private float _currentTime;
        [SerializeField] private GameObject _gameOver;


        void Awake()
        {
            _currentTime = 0;
            _slider = this.gameObject.transform.GetChild(0).GetComponent<Slider>();
            _slider.maxValue = _timer;
            _gameOver.SetActive(false);
        }
        void Update()
        {
            _slider.value = _currentTime;
            _currentTime += Time.deltaTime;
            _slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Color.green, Color.red, _slider.normalizedValue);

            if (_currentTime >= _slider.maxValue)
            {
                _gameOver.SetActive(true);
            }
        }
    }
}
