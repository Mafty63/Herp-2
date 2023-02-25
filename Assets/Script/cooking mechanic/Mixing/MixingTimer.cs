using UnityEngine;
using UnityEngine.UI;

namespace Mixing.Timer
{
    public class MixingTimer : MonoBehaviour
    {
        public static MixingTimer instance;
        private Slider _slider;
        [Header("Coutdown time in second")]
        [SerializeField] private float _timer;
        private float _currentTime;
        [SerializeField] private GameObject _gameOver;


        void Awake()
        {
            //If we don't currently have a game control...
            if (instance == null)
                //...set this one to be it...
                instance = this;
            //...otherwise...
            else if (instance != this)
                //...destroy this one because it is a duplicate.
                Destroy(gameObject);
            // Start is called before the first frame update

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

        public void plusCurrentTime(float plus)
        {
            _currentTime += plus;
        }
    }
}
