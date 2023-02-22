using UnityEngine;
using UnityEngine.UI;

public class SlicingTimer : MonoBehaviour
{
    private Slider _slider;
    [Header("Coutdown time in second")]
    [SerializeField] private float _timer;
    private float _currentTime;


    void Awake()
    {
        _currentTime = 0;
        _slider = this.gameObject.transform.GetChild(0).GetComponent<Slider>();
        _slider.maxValue = _timer;
    }
    void Update()
    {
        _slider.value = _currentTime;
        _currentTime += Time.deltaTime;
        _slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Color.green, Color.red, _slider.normalizedValue);
    }
}
