using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : CharacterAnimation
{
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int IsHit = Animator.StringToHash("IsHit");

    private HealthSystem _healthSystem;

    protected override void Awake()
    {
        base.Awake();
        //_healthSystem = GetComponent<HealthSystem>();
    }

    private void Start()
    {
        controller.OnAttackEvent += Attacking;
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 obj)
    {
        animator.SetBool(IsWalking, obj.magnitude > 0.5f);
    }

    private void Attacking(AttackSO sO)
    {
        animator.SetTrigger(Attack);
    }

    private void Hit()
    {
        animator.SetBool(IsHit, true);
    }

    private void invisibillityEnd()
    {
        animator.SetBool(IsHit, false);
    }

}
