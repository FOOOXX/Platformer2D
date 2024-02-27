using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothingBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;

    private Coroutine _currentCoroutine;

    private void Start()
    {
        _slider.minValue = 0;
        _slider.maxValue = 1;
    }

    private void OnEnable()
    {
        _health.HealthChanged += UpdateBar;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateBar;

        if(_currentCoroutine != null )
            StopCoroutine(_currentCoroutine);
    }

    public void UpdateBar(float health)
    {
        SmoothTheChange(health);
    }

    private void SmoothTheChange(float target)
    {
        if(_currentCoroutine == null)
        {
            _currentCoroutine = StartCoroutine(Fill(target));
        }
        else
        {
            StopCoroutine(_currentCoroutine);
            _currentCoroutine = StartCoroutine(Fill(target));
        }
    }

    private IEnumerator Fill(float target)
    {
        target /= _health.MaxValue;

        while(_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, 0.01f);

            yield return null;
        }
    }
}
