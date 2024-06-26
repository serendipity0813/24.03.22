using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : CharacterActionController
{
    private Camera _camera;
    [SerializeField] private SpriteRenderer characterRenderer;

    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        if(moveInput.x < 0)
            characterRenderer.flipX = true;
        else if(moveInput.x > 0) 
            characterRenderer.flipX = false;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 WorldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (WorldPos - (Vector2)transform.position).normalized;

        if (newAim.magnitude >= 0.9f)
        {
            CallLookEvent(newAim);
        }
    }

    public void OnAttack(InputValue value)
    {
        IsAttacking = value.isPressed;
    }
}
