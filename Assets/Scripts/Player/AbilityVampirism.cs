using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]

public class AbilityVampirism : MonoBehaviour
{
    [SerializeField] private Health _enemyHealth;

    private Health _health;

    private LayerMask _enemyLayer;

    private readonly int _radiusCollider = 3;

    private void Start()
    {
        _health = GetComponent<Health>();

        _enemyLayer = LayerMask.GetMask("Enemy");
    }

    private void Update()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, _radiusCollider, _enemyLayer);

        if(Input.GetKey(KeyCode.Space) && collider != null && _health.CurrentValue != _health.MaxValue)
        {
            StartCoroutine(CountDown(6, 0.5f));
        }
    }

    private void ChangeAmountHealth(float amount)
    {
        _health.Heal(amount);

        _enemyHealth.TakeDamage(amount);
    }

    private IEnumerator CountDown(int delay, float amountHeartsRestored)
    {
        WaitForSeconds wait = new(delay);

        ChangeAmountHealth(amountHeartsRestored);

        yield return wait;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radiusCollider);
    }
}
