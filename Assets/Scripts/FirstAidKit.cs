using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField][Range(1, 2)] private float _amountHeal;

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
