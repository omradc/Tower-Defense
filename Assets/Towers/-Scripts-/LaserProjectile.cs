using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    [Header("PROJECTÝLE")]
    public float detectDistance = 0.5f;
    public float projectileSpeed = 70;
    public float projectilePower = 25;

    [Header("LASER")]
    public float laserDestroyTime = 1;
    Transform target;
    Vector3 laserDirection;

    void Start()
    {
        laserDirection = (target.position - transform.position).normalized;
    }

    void Update()
    {
        LaserOn();
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    void LaserOn()
    {
        transform.Translate(laserDirection * Time.deltaTime * projectileSpeed, Space.World);
        Destroy(gameObject, laserDestroyTime);
    }
}
