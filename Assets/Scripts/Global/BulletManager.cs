using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem _impactParticleSystem;
    [SerializeField] private GameObject testObj;

    public static BulletManager instance;

    private void Awake()
    {
        if(instance == null)
        instance = this; 
    }
}
