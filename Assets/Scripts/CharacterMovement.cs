using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private CharacterActionController _characterController;

    private Vector2 _moveDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _characterController = GetComponent<CharacterActionController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _characterController.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(_moveDirection);
    }

    private void Move(Vector2 direction)
    {
        _moveDirection = direction;
        Debug.Log("3");
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5;
        _rigidbody.velocity = direction;
    }

}
