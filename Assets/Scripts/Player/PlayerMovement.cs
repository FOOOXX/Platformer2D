using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerAnimation))]

public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private PlayerAnimation _playerAnimation;

    private RaycastHit2D _hit;
    private LayerMask _groundMask;

    private readonly float _moveSpeed = 3f;
    private readonly float _jumpForce = 6.5f;
    private readonly float _rayDistance = 0.5f;

    private float _horizontalDirection;
    private float _verticalDirection;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerAnimation = GetComponent<PlayerAnimation>();

        _groundMask = LayerMask.GetMask("Ground");
    }

    private void FixedUpdate()
    {
        _horizontalDirection = Input.GetAxisRaw(Horizontal);
        _verticalDirection = Input.GetAxisRaw(Vertical);

        if (_horizontalDirection != 0)
            Move();

        if (IsGround() == true && _verticalDirection != 0)
            Jump();

        _playerAnimation.Move(_horizontalDirection);
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(_horizontalDirection * _moveSpeed, _rigidbody2D.velocity.y);

        if (_horizontalDirection > 0 && _spriteRenderer.flipX)
            Flip();
        else if (_horizontalDirection < 0 && !_spriteRenderer.flipX)
            Flip();
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(_jumpForce * new Vector2(0f, _verticalDirection), ForceMode2D.Impulse);
    }

    private void Flip()
    {
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }

    private bool IsGround()
    {
        _hit = Physics2D.Raycast(_rigidbody2D.position, Vector2.down, _rayDistance, _groundMask);

        return _hit.collider != null;
    }
}
