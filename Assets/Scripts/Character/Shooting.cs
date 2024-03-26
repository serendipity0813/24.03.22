using System;
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
        _controller.OnAttackEvent += OnShoot;
        _controller.OnLookEvent += OnAim; 
    }

    private void OnAim(Vector2 newDirection)
    {
        _aimDirection = newDirection;
    }

    private void OnShoot()
    {
        MakeBullet();
    }

    private void MakeBullet()
    {
        Instantiate(BulletPrefab, bulletSpawnPosition.position, Quaternion.identity);
    }
}
