using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;

    private readonly float _speed = 1f;
    private readonly float _angle = 0f;

    private Transform _target;

    private Vector2 _boxSize;

    private void Start()
    {
        _boxSize = new Vector2(3f, 0.8f);
    }

    private void Update()
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position, _boxSize, _angle, _mask);

        if (collider != null && collider.TryGetComponent<Player>(out Player player))
            _target = player.transform;

        Move();
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, _boxSize);
    }
}
