using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RangedAttackController : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;

    private RangedAttackData _attackData;
    private float _currentDuration;
    private Vector2 _direction;
    private bool _isReady;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private TrailRenderer _trailRenderer;
    private BulletManager _bulletManager;

    public bool fxOnDestroy;

    private void Awake()
    {
        _bulletManager = BulletManager.instance;
        _rigidbody = GetComponent<Rigidbody2D>();
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if (!_isReady)
        {
            return;
        }

        _currentDuration += Time.deltaTime;

        if(_currentDuration > _attackData.duration)
        {
            DestroyBullet(transform.position, false);
        }

        _rigidbody.velocity = _direction * _attackData.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(levelCollisionLayer.value == (levelCollisionLayer.value | (1 << collision.gameObject.layer))) 
        { 
            DestroyBullet(collision.ClosestPoint(transform.position) - _direction*0.2f, fxOnDestroy);
        }
        else if(_attackData.target.value == (_attackData.target.value | (1 << collision.gameObject.layer)))
        {
            HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
            if(healthSystem != null)
            {
                healthSystem.ChangeHealth(-_attackData.power);
                if(_attackData.IsOnKnockback)
                {
                    CharacterMovement movement = collision.GetComponent<CharacterMovement>();

                    if(movement != null)
                    {
                        movement.ApplyKnockback(transform, _attackData.KnockbackPower, _attackData.KnockbackTime);
                    }
                }

            }
            DestroyBullet(collision.ClosestPoint(transform.position) - _direction * 0.2f, fxOnDestroy);
        }
    }

    public void InitializeAttack(Vector2 direction, RangedAttackData attackData, BulletManager bulletManager)
    {
        _bulletManager = bulletManager;
        _attackData = attackData;
        _direction = direction;

        UpdateBulletSprite();
        _trailRenderer.Clear();
        _currentDuration = 0;

        transform.right = _direction;

        _isReady = true;


    }

    private void UpdateBulletSprite()
    {
        transform.localScale = Vector3.one * _attackData.size;
    }

    private void DestroyBullet(Vector3 position, bool createFx)
    {
        if(createFx) 
        {

        }
        gameObject.SetActive(false);
    }



 
}
