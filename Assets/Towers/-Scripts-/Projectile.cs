using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("PROJECTÝLE")]
    public float detectDistance = 0.5f;
    public float projectileSpeed = 70;
    public float projectilePower = 25;
    Vector3 direction;
    float distance;
    Transform target;

    [Header("BULLET")]
    [SerializeField] bool useBullet = false;

    [Header("MÝSSÝLE")]
    [SerializeField] bool useMissile = false;
    public float explosionRadius = 10;

    [Header("UNÝTY SETUP")]
    string nonBarrier = "NonBarrier(Clone)";
    string energyBarrier = "EnergyBarrier(Clone)";

    public void ChooseTarget(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        // hedefi olmayan memiler yok edilir
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        if (useBullet == true || useMissile == true)
            ProjectileLockOn();

        if (distance < detectDistance)
        {
            Hit();
        }
    }

    void Hit()
    {
        if (useMissile == true)
        {
            Explode();
        }
        if (useBullet == true && target.name == nonBarrier || target.name == energyBarrier)
        {
            Damage(target);
        }
        Destroy(gameObject);
    }


    // For Missile
    void Explode()
    {
        Collider[] damagedEnemys = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider obj in damagedEnemys)
        {
            if (obj.tag == "Enemy")
                Damage(obj.transform);
        }
    }
    private void OnDrawGizmos()
    {
        if (useMissile == true)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        }
    }

    void Damage(Transform _target)
    {
        //print("EnemyHealth: " + _target.gameObject.GetComponent<Enemy>().health);
        _target.gameObject.GetComponent<Enemy>().EnemyTakeDamage(projectilePower);
    }

    void ProjectileLockOn()
    {
        // Ulaþýlmasý istenen mesafe
        distance = Vector3.Distance(transform.position, target.position);

        direction = (target.position - transform.position).normalized;
        transform.Translate(direction * Time.deltaTime * projectileSpeed, Space.World);
        transform.LookAt(target);
    }
}
