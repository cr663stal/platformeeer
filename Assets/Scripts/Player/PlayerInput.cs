using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        InputJump(); 
    }

    private void FixedUpdate()
    {
        InputMovement();
    }

    

    private void InputMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        _playerController.Movement(horizontal, vertical);
    }

    private void InputJump()
    {
        bool isJump = Input.GetButtonDown("Jump");
        if (isJump)
        {
            _playerController.Jump();
        }
    }

    private void InputRun()
    {
        
    }

    private void InputSit()
    {

    }

    private void InputPickUp()
    {

    }

    private void InputUse()
    {

    }

    private void InputLook()
    {

    }

    private void InputFire()
    {

    }
}
