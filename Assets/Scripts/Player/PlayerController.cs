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

    //[SerializeField] private StatesCharacter _state = StatesCharacter.Walking;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpOffset = 5;
    [SerializeField] private float _speed;
    [SerializeField] private float _verticalBlockUp;
    [SerializeField] private float _verticalBlockDown;
    private bool _isRightDirection;


    private Rigidbody _rigidbody;
    private Transform _transform;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        
    }

    public void Jump()
    {
        if (!CheckGround())
        {
            _rigidbody.AddForce(new Vector2(_rigidbody.velocity.x, _jumpForce));
        }
    }

    public void Movement(float directoinHorizontal, float directionVertical)
    {
        
        Vector3 value = new Vector3(directoinHorizontal, 0, directionVertical);
        
        if (CheckVerticalBlock(directionVertical))
        {
            value.z = 0;
        }
        
        _rigidbody.MovePosition(_transform.position + value * _speed * Time.deltaTime);

        if ((directoinHorizontal > 0 && !_isRightDirection) || (directoinHorizontal < 0 && _isRightDirection))
        {
            Flip();
        }
    }

    private bool CheckVerticalBlock(float direction)
    {
        if (direction > 0 && _transform.position.z >= _verticalBlockUp)
        {
            return true;
        }
        if (direction < 0 && _transform.position.z <= _verticalBlockDown) 
        {
            return true;
        }

        return false;
    }

    public void Move(float moving, bool isJumpPressed)
    {
        
    }

    private void Flip()
    {
        _isRightDirection = !_isRightDirection;

        Vector3 scale = _transform.localScale;
        scale.x *= -1;
        _transform.localScale = scale;
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
