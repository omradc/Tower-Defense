using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("ENEMY")]
    public float speed; 
    public float startHealth;
    public int enemyValue;
    public Image healthBar;
    int wayPointIndex;
    [HideInInspector] public float health;
    Transform target;
    Towers towers;
    PlayerStats playerStats;
    UI uý;
    public string laserTag = "LaserProjectile";
    string nonBarrier = "NonBarrier(Clone)";
    string physicalBarrier = "PhysicalBarrier(Clone)";

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        towers = Towers.Instance;
        playerStats = PlayerStats.Instance;
        uý = UI.Instance;
        target = WayPoints.point[wayPointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            SetNextPoint();
        }

        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);

        if (health <= 0)
        {
            playerStats.EarnMoney(enemyValue);
            uý.moneyText.text = "Money: " + playerStats.money;
            Dead();
        }
    }

    void SetNextPoint()
    {
        wayPointIndex++;
        if (wayPointIndex >= WayPoints.point.Length)
        {
            PathEnd();
            return;
        }

        target = WayPoints.point[wayPointIndex];
    }

    void Dead()
    {
        EnemySpawner.Instance.currentEnemyCount--;
        Destroy(gameObject);
        return;
    }

    void PathEnd()
    {
        // düþman yolun sonuna ulaþýrsa, oyuncu can kaybeder
        playerStats.playerHealth--;
        uý.liveText.text = "Lives: " + playerStats.playerHealth;
        Dead();
    }

    public void EnemyTakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.fillAmount = health / startHealth;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == laserTag)
        {
            if (transform.name == nonBarrier || transform.name == physicalBarrier)
            {
                EnemyTakeDamage(towers.laserPower);
            }

        }
    }
}
