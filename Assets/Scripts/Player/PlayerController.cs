using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded = true;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _rigidbody2D.AddForce(new Vector2(0, _jumpForce));
        }
    }

    public void Move(float moving)
    {
        Vector2 VectorX = new Vector2(moving * _speed, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = VectorX;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isGrounded = true;
        }

    }
}
