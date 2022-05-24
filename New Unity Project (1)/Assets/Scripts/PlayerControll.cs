using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerControll : MonoBehaviour
{
    private GameControl _gameControl;
    private PlayerInput _playerInput;
    private Camera _mainCamera;
    private Vector2  _moveInput;
    private Rigidbody _rigidbody;
    public float moveMutiplier;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        _gameControl = new GameControl();
        
        _playerInput = GetComponent<PlayerInput>();

        _mainCamera = Camera.main;

        _playerInput.onActionTriggered += OnActionTriggered;
    }

    private void OneDisable() 
    {
        _playerInput.onActionTriggered -= OnActionTriggered;
    }

    private void OnActionTriggered(InputAction.CallbackContext obj)
    {
        if (obj.action.name.CompareTo(_gameControl.gameplay.move.name) != 0)
        {
            _moveInput = obj.ReadValue<Vector2>();
        }
    }

    private void Move()
    {
      _rigidbody.AddForce((_mainCamera.transform.forward * _moveInput.y + _mainCamera.transform.right * _moveInput.x ) * moveMutiplier * Time.deltaTime);  
    }

    private void FixedUpdate()
    {
        Move();
    }
} 
