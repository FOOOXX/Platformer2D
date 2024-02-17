using UnityEngine;

[RequireComponent (typeof(Health))]

public class Enemy : MonoBehaviour
{
    [SerializeField] [Range(1, 4)] private float _damage;

    private Health _health;

    public float Damage => _damage;

    private void Start()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
            _health.TakeDamage(player.Damage);
    }
}
