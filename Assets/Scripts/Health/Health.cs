using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<float> HealthChanged;

    private readonly float _maxValue = 100;

    private float _currentValue;

    public float MaxValue => _maxValue;

    public float CurrentValue
    {
        get
        {
            return _currentValue;
        }
        private set
        {
            _currentValue = Mathf.Clamp(value, 0f, MaxValue);
            HealthChanged?.Invoke(_currentValue);

            if (_currentValue <= 0f)
                Die();
        }
    }

    private void Start()
    {
        CurrentValue = MaxValue;
    }

    public void Heal(float value)
    {
        CurrentValue += value;
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0f)
            return;

        CurrentValue -= damage;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
