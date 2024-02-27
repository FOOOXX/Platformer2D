using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    private readonly float _amountHeal = 1;

    public float AmountHeal => _amountHeal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Health>(out Health health))
        {
            health.Heal(AmountHeal);

            Destroy(gameObject);
        }
    }
}
