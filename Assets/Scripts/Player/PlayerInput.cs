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
        
        float direction = Input.GetAxis("Horizontal");
        bool isJump = Input.GetButtonDown("Jump");
        
        _playerController.Move(direction, isJump);       
    }

}
