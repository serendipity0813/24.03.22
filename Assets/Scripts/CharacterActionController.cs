using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterActionController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<Vector2> OnAttackEvent;

    public void CallMoveEvent(Vector2 direction)
    {
        //direction�� ���� NULL���� üũ�� �� OnMoveEvent ����
        OnMoveEvent?.Invoke(direction);
        Debug.Log("1");
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent(Vector2 direction)
    {

    }
}
