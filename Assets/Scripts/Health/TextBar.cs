using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthBarText : MonoBehaviour
{
    [SerializeField] private Health _health;

    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _health.HealthChanged += UpdateValue;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= UpdateValue;
    }

    private void UpdateValue(float health)
    {
        _text.text = $"{health} / {_health.MaxValue}";
    }
}
