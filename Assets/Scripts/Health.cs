using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] [Range(5, 10)] private float _maxValue;

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

            if (_currentValue <= 0f) 
                gameObject.SetActive(false);
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
        CurrentValue -= damage;
    }
}
