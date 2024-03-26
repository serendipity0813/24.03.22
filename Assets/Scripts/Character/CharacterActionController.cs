using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActionController : MonoBehaviour
{
    protected CharacterStatsHandler stats { get; private set; }

    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    private float _timeSinceLastAttack; 
    protected bool IsAttacking { get; set; }

    protected virtual void Awake()
    {
        stats = GetComponent<CharacterStatsHandler>();
    }

    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (stats.CurrentStates.attackSO == null)
            return;

        if(_timeSinceLastAttack <= stats.CurrentStates.attackSO.delay)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }
        else if(IsAttacking && _timeSinceLastAttack > stats.CurrentStates.attackSO.delay)
        {
            CallAttackEvent();
            _timeSinceLastAttack = 0;
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        //direction의 값이 NULL인지 체크한 후 OnMoveEvent 실행
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
}
