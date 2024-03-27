using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    //[SerializeField] private ParticleSystem _impactParticleSystem;
    [SerializeField] private GameObject bullet;

    public static BulletManager instance;

    private void Awake()
    {
        if(instance == null)
        instance = this; 
    }

    public void ShootBullet(Vector2 startPosition, Vector2 direction, RangedAttackData attackData)
    {
        GameObject obj = Instantiate(bullet);

        obj.transform.position = startPosition;
        RangedAttackController attackController = obj.GetComponent<RangedAttackController>();

        attackController.InitializeAttack(direction, attackData, this);

        obj.SetActive(true);
    }
}
