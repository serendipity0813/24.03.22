using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackData", menuName = "SO/Attack/Melee", order = 0)]
public class AttackSO : ScriptableObject
{
    [Header("Attack Info")]
    public float size;
    public float delay;
    public float power;
    public float speed;
    public LayerMask target;

    [Header("Knockback Info")]
    public bool IsOnKnockback;
    public float KnockbackPower;
    public float KnockbackTime;

}
