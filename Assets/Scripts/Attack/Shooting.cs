
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private CharacterActionController _controller;
    private BulletManager _bulletManager;

    [SerializeField] private Transform bulletSpawnPosition;
    private Vector2 _aimDirection = Vector2.right;

    public GameObject BulletPrefab;

    private void Awake()
    {
        _controller = GetComponent<CharacterActionController>();
    }

    void Start()
    {
        _bulletManager = BulletManager.instance;
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim; 
    }

    private void OnAim(Vector2 newDirection)
    {
        _aimDirection = newDirection;
    }

    private void OnShoot(AttackSO attackSO)
    {
        RangedAttackData rangedAttackData = attackSO as RangedAttackData;
        float bulletAngleSpace = rangedAttackData.multipleBulletAngle;
        int numberOfBulletPerShot = rangedAttackData.numberOfBulletPerShot;

        float minAngle = -(numberOfBulletPerShot / 2f) * bulletAngleSpace + 0.5f * rangedAttackData.multipleBulletAngle;

        for(int i=0; i<numberOfBulletPerShot; i++)
        {
            float angle = minAngle + bulletAngleSpace * i;
            float randomSpread = Random.Range(-rangedAttackData.spread, rangedAttackData.spread);
            angle += randomSpread;
            MakeBullet(rangedAttackData, angle);
        }

    }

    private void MakeBullet(RangedAttackData rangedAttackData, float angle)
    {
        _bulletManager.ShootBullet(bulletSpawnPosition.position, RotateVector2(_aimDirection, angle), rangedAttackData);
    }

    private Vector2 RotateVector2(Vector2 v, float degree)
    {
        return Quaternion.Euler(0, 0, degree) * v;
    }
}
