using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ContactEnemyController : EnemyController
{
    [SerializeField][Range(0f, 100f)] private float followRange;
    [SerializeField] private string targetTag = "Player";
    private bool _isCollidingWithTarget;
    private HealthSystem _healthSystem;
    private HealthSystem _collidingTargetHealthSystem;
    private CharacterMovement _collidingMovement;

    protected override void Start()
    {
        base.Start();

        _healthSystem = GetComponent<HealthSystem>();
        _healthSystem.OnDamage += OnDamage;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        Vector2 direction = Vector2.zero;

        if(DistanceToTarget() < followRange)
        {
            direction = DirectionToTarget();
        }

        if (_isCollidingWithTarget)
        {
            ApplyHealthChange();
        }
        CallMoveEvent(direction);
        Rotate(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject receiver = collision.gameObject;

        if(!receiver.CompareTag(targetTag)) { return; }

        IsAttacking = true;
        _collidingTargetHealthSystem = receiver.GetComponent<HealthSystem>();
        if(_collidingTargetHealthSystem != null)
        {
            _isCollidingWithTarget = true;
        }
        _collidingMovement = receiver.GetComponent<CharacterMovement>();

    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        IsAttacking = false;
        if (!collision.CompareTag(targetTag)) { return; }
        _isCollidingWithTarget = false;
    }
    private void ApplyHealthChange()
    {
        AttackSO attackSO = stats.CurrentStates.attackSO;
        bool hasBeenChanged = _collidingTargetHealthSystem.ChangeHealth(-attackSO.power);

        if(attackSO.IsOnKnockback && _collidingMovement != null)
        {
            _collidingMovement.ApplyKnockback(transform, attackSO.KnockbackPower, attackSO.KnockbackTime);
        }
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;

    }

    private void OnDamage()
    {
        followRange = 100f;
    }
   
}
