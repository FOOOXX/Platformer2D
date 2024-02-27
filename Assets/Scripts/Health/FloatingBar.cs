using UnityEngine;
using UnityEngine.UI;

public class FloatingBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;

    private void Start()
    {
        _slider.maxValue = 1;
        _slider.minValue = 0;
    }

    private void OnEnable()
    {
        _health.HealthChanged += UpdateBar;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateBar;
    }

    public void UpdateBar(float health)
    {
        _slider.value = health / _health.MaxValue;
    }
}
