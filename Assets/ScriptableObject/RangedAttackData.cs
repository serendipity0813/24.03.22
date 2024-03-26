using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="RangedAttackData", menuName = "SO/Attack/Ranged", order =1)]
public class RangedAttackData : ScriptableObject
{
    [Header("Ranged Attack Data")]
    public string bulletNameTag;
    public float duration;
    public float spread;
    public int numberOfBulletPerShot;
    public float multipleBulletAngle;
    public Color BulletColor;
}
