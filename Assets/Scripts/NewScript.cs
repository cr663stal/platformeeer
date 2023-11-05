using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewScript : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5.0f;
    [SerializeField] private float _speed = 5.0f;
    private Rigidbody2D _rigidbody2D;
    private bool _isGrounded = true;
    private float _moving;

    private void Awake() // ссылка
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    } 

    private void Start()
    {
       
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(new Vector2(0, _jumpForce));
    }

    private void Update()
    {   
        _moving = Input.GetAxis("Horizontal");
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && _isGrounded)
        {
            Jump();
        }
        Move();

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
    private void FixedUpdate()
    {
        
    }
    private void Move()
    {
        Vector2 VectorX = new Vector2(_moving * _speed, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = VectorX;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ColorCharge>())
        {
            collision.gameObject.GetComponent<ColorCharge>().ChangeSprite();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ColorCharge>())
        {
            collision.gameObject.GetComponent<ColorCharge>().ResetSprite();
        }
    }
}
