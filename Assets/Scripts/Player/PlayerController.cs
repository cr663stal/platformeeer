using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [System.Flags]
    public enum StatesCharacter 
    {
        Waiting = 1 << 0,
        Walking = 1 << 1,
        Clibing = 1 << 2,
        Flying = 1 << 3,
        Shooting = 1 << 4,
        Fithing = 1 << 5,
        Dieing = 1 << 6,
        Using = 1 << 7,
        CanNotWalk = Clibing | Fithing | Using | Dieing,
        CanNotShoot = Clibing | Fithing | Dieing | Using,
        CanNotFight = Shooting | Dieing | Using
    }
    /*
    [System.Flags]
    public enum States
    {
        StateA = 1 << 0,
        StateB = 1 << 1,
        StateC = 1 << 2,
        StateD = 1 << 3
    }*/

    [SerializeField] private StatesCharacter _state = StatesCharacter.Walking;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpOffset = 5;
    [SerializeField] private float _speed;


    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }

    private void Jump()
    {
        if (CheckGround())
        {
            _rigidbody2D.AddForce(new Vector2(_rigidbody2D.velocity.x, _jumpForce));
        }
    }

    private void HorizontalMovement(float directoin)
    {
        if ((_state & StatesCharacter.CanNotWalk) == 0)
        {
            _rigidbody2D.velocity = new Vector2(directoin * _speed, _rigidbody2D.velocity.y);
            //_state |= StatesCharacter.Walking;
        }

        else if(directoin < 0.1)
        {
            //_state ^= StatesCharacter.Walking; //в общем-то тут все плохо, моя концепция ломается.
        }
    }

    public void Move(float moving, bool isJumpPressed)
    {
        if (isJumpPressed)
        {
            Jump();
        }
        HorizontalMovement(moving);
    }

    private bool CheckGround()
    {
        bool isGrounded;
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _jumpOffset);
        
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        return isGrounded;
    }

    

    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
