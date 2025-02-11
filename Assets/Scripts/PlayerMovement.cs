using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float _moveSpeed;

    [Header("Jump")]
    [SerializeField] private float _jumpPower;
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private LayerMask _groundMask;

    private Rigidbody2D _rb;
    private Vector2 _moveDirection;
    private bool _isFacingRight = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveInternal();
        Flip();
    }

    private void MoveInternal()
    {
        _rb.velocity = new Vector2(_moveDirection.x * _moveSpeed, _rb.velocity.y);
    }

    private void Flip()
    {
        if (_isFacingRight && _moveDirection.x < 0 || !_isFacingRight && _moveDirection.x > 0)
        {
            _isFacingRight = !_isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheckPoint.position, _groundCheckRadius, _groundMask);
    }

    public void Move(Vector2 direction)
    {
        _moveDirection = direction;
    }

    public void Jump()
    {
        if (!IsGrounded())
        {
            return;
        }

        _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
    }
}
