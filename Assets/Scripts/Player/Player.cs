using UnityEngine;

[RequireComponent(typeof(Wallet))]
[RequireComponent (typeof(Health))]

public class Player : MonoBehaviour
{
    private readonly float _damage;

    private Wallet _wallet;
    private Health _health;

    public float Damage => _damage;

    private void Start()
    {
        _wallet = GetComponent<Wallet>();
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _wallet.Add(coin.Amount);
            Destroy(collision.gameObject);
        }

        if(collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _health.TakeDamage(enemy.Damage);
        }
    }
}
