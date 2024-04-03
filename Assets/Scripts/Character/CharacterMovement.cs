using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    private CharacterActionController _characterController;
    private CharacterStatsHandler _stats;
    private Vector2 _moveDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private Vector2 _knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterActionController>();
        _stats = GetComponent<CharacterStatsHandler>(); 
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _characterController.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(_moveDirection);
        if(knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    private void Move(Vector2 direction)
    {
        _moveDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * _stats.CurrentStates.speed;

        _rigidbody.velocity = direction;
        
        if(knockbackDuration > 0.0f)
        {
            direction += _knockback;
        }
    }

    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        _knockback = -(other.position - transform.position).normalized * power;
    }


}
