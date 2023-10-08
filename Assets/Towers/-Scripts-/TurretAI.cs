using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class TurretAI : MonoBehaviour
{
    [Header("DEFAULT SETUP")]
    public List<GameObject> enemys;
    public GameObject firstEnemy;
    Transform turretHead;
    float time;

    [Header("UNÝTY SETUP")]
    public string enemyTag = "Enemy";

    [Header("TURRET")]
    public float range = 15;
    public float rotateSpeed = 10;
    public float targetRefresh = 0.2f;
    public float fireRate = 1;
    public GameObject projectilePoint;

    [Header("BULLET")]
    public bool useBullet = false;
    public GameObject bulletPrefab;

    [Header("LASER")]
    public bool useLaser = false;
    public GameObject laserPrefab;
    public LineRenderer laserBeam;
    public GameObject laserEndPoint;

    [Header("MÝSSÝLE")]
    public bool useMissile = false;
    public GameObject missilePrefab;

    #region Bolt
    //[Header("BOLT")]
    //public bool useBolt = false;
    //public LineRenderer bolt;
    //public float timeToDamage = 0.1f;
    //public float boltPower;
    //public int splashRange = 2;
    //public int splashNumber = 3;
    //public GameObject secondEnemy;
    //public GameObject thirdEnemy;
    //public List<GameObject> enemys2;
    //public List<GameObject> enemys3;
    #endregion



    void Start()
    {
        turretHead = transform.GetChild(1);
        InvokeRepeating("UpdateTarget", 0, targetRefresh);
    }
    void Update()
    {
        if (firstEnemy == null)
        {
            if (useLaser == true)
                laserBeam.enabled = false;
            #region Bolt
            //if (useBolt == true)
            //    bolt.enabled = false;
            #endregion

            return;
        }

        LockOn();

        if (useBullet == true)
        {
            FireBullet();
        }

        if (useLaser == true)
        {
            FireLaser();
        }

        if (useMissile == true)
        {
            FireMissile();
        }

        #region Bolt
        //if (useBolt == true)
        //{
        //    FireBolt();
        //}
        #endregion

    }

    void LockOn()
    {
        Vector3 direction = (firstEnemy.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 look = Quaternion.Lerp(turretHead.rotation, lookRotation, Time.deltaTime * rotateSpeed).eulerAngles;
        turretHead.rotation = Quaternion.Euler(0, look.y, 0);
    }
    void UpdateTarget()
    {
        // düþmanlar diziye atanýr
        enemys = GameObject.FindGameObjectsWithTag(enemyTag).ToList<GameObject>();

        #region Bolt
        //// Yýldýrým kulesi için sekme hedefleri
        //if (splashNumber > 1)
        //{
        //    enemys2 = GameObject.FindGameObjectsWithTag(enemyTag).ToList<GameObject>();
        //}
        //if (splashNumber > 2)
        //{
        //    enemys3 = GameObject.FindGameObjectsWithTag(enemyTag).ToList<GameObject>();
        //}

        #endregion

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemys)
        {
            // kuleden düþmana olan mesafe
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;

                #region Bolt
                //// bulunan ilk düþman 2. v 3. diziden çýkarýlr
                //enemys2.Remove(enemy);
                //enemys3.Remove(enemy);
                #endregion
            }
        }
        if (nearestEnemy != null && shortestDistance < range)
        {
            firstEnemy = nearestEnemy;

        }
        else
            firstEnemy = null;

        #region Yýldýrým kulesi hedefleri
        //if (splashNumber > 1)
        //{
        //    foreach (GameObject enemy in enemys2)
        //    {
        //        // bulunan ilk düþmandan 2. düþmana olan mesafe
        //        float secondEnemyDistance = Vector3.Distance(firstEnemy.transform.position, enemy.transform.position);

        //        if (secondEnemyDistance < shortestDistance)
        //        {
        //            shortestDistance = secondEnemyDistance;
        //            nearestEnemy = enemy;


        //            //2. düþman 3. diziden çýkarýlýr
        //            enemys3.Remove(enemy);
        //            print("ok");
        //        }
        //    }
        //    if (nearestEnemy != null && shortestDistance < splashRange)
        //    {
        //        secondEnemy = nearestEnemy;
        //    }

        //    if (distanceToEnemy > splashRange)
        //    {
        //        secondEnemy = null;
        //        return;
        //    }


        //    if (splashNumber > 2)
        //    {
        //        foreach (GameObject enemy in enemys3)
        //        {
        //            float secondEnemyDistance = Vector3.Distance(secondEnemy.transform.position, enemy.transform.position);

        //            if (secondEnemyDistance < shortestDistance)
        //            {
        //                shortestDistance = secondEnemyDistance;
        //                nearestEnemy = enemy;
        //            }
        //        }
        //        if (nearestEnemy != null && shortestDistance < splashRange)
        //        {
        //            thirdEnemy = nearestEnemy;
        //        }

        //        if (distanceToEnemy > splashRange)
        //        {
        //            thirdEnemy = null;
        //        }

        //    }

        //}
        #endregion
    }
    #region Yýldýrým  kulesi hedefe sýçrama ve hasar verme
    //void FireBolt()
    //{

    //    if (Time.time > time)
    //    {
    //        time = Time.time + fireRate;
    //        bolt.enabled = !bolt.enabled;
    //        StartCoroutine("BoltDamage");
    //    }
    //    bolt.SetPosition(0, projectilePoint.transform.position);
    //    bolt.SetPosition(1, firstEnemy.transform.position);

    //    // 2. ve 3. düþman boþ ise 1. düþmana git
    //    if (secondEnemy == null && thirdEnemy == null)
    //    {
    //        bolt.SetPosition(2, firstEnemy.transform.position);
    //        bolt.SetPosition(3, firstEnemy.transform.position);
    //    }

    //    // 2. düþman boþ deðilse 2. ye git, 3. düþman boþ ise 2. ye git
    //    if (secondEnemy != null)
    //    {
    //        bolt.SetPosition(2, secondEnemy.transform.position);
    //        if (thirdEnemy == null)
    //        {
    //            bolt.SetPosition(3, secondEnemy.transform.position);
    //        }
    //    }

    //    // 3. düþman boþ deðilse 3. ye git
    //    if (thirdEnemy != null)
    //    {
    //        bolt.SetPosition(3, thirdEnemy.transform.position);
    //    }
    //}

    //IEnumerator BoltDamage()
    //{
    //    yield return new WaitForSeconds(timeToDamage);
    //    if (firstEnemy != null)
    //    {
    //        if (firstEnemy.name == nonBarrier || firstEnemy.name == physicalBarrier)
    //            firstEnemy.GetComponent<Enemy>().health -= boltPower;
    //    }

    //    if (secondEnemy != null)
    //    {
    //        if (firstEnemy.name == nonBarrier || firstEnemy.name == physicalBarrier)
    //            secondEnemy.GetComponent<Enemy>().health -= boltPower;
    //    }

    //    if (thirdEnemy != null)
    //    {
    //        if (firstEnemy.name == nonBarrier || firstEnemy.name == physicalBarrier)
    //            thirdEnemy.GetComponent<Enemy>().health -= boltPower;
    //    }
    //}
    #endregion  

    void FireBullet()
    {
        if (Time.time > time)
        {
            time = Time.time + fireRate;

            GameObject obj = Instantiate(bulletPrefab, projectilePoint.transform.position, projectilePoint.transform.rotation);
            obj.GetComponent<Projectile>().ChooseTarget(firstEnemy.transform);
        }

    }

    void FireLaser()
    {
        laserBeam.enabled = true;
        laserBeam.SetPosition(0, projectilePoint.transform.position);
        laserBeam.SetPosition(1, laserEndPoint.transform.position);

        if (Time.time > time)
        {
            time = Time.time + fireRate;
            GameObject obj = Instantiate(laserPrefab, projectilePoint.transform.position, projectilePoint.transform.rotation);
            obj.GetComponent<LaserProjectile>().SetTarget(firstEnemy.transform);
        }
    }

    void FireMissile()
    {
        if (Time.time > time)
        {
            time = Time.time + fireRate;
            GameObject obj = Instantiate(missilePrefab, projectilePoint.transform.position, projectilePoint.transform.rotation);
            obj.GetComponent<Projectile>().ChooseTarget(firstEnemy.transform);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
