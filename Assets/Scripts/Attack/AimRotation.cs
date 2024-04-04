using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer weaponRenderer;
    [SerializeField] private Transform weaponPivot;
    private CharacterActionController _characterActionController;

    private void Awake()
    {
        _characterActionController = GetComponent<CharacterActionController>();
    }

    void Start()
    {
        _characterActionController.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 newDirection)
    {
        RotateWeapon(newDirection);
    }

    private void RotateWeapon(Vector2 direction)
    {
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        weaponRenderer.flipY = Mathf.Abs(rotz) > 90f;
        weaponPivot.rotation = Quaternion.Euler(0, 0, rotz);

    }
}
