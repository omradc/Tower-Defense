    using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    #region Singelton
    public static BuildManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
            Destroy(gameObject);
    }
    #endregion

    [Header("Turret Costs")]
    public int standartTurretLvlCost;
    public int missileTurretLvlCost;
    public int laserTurretLvlCost;

    [HideInInspector] public int turretCost;
    GameObject turret;

    private void Start()
    {
    }
    public GameObject GetTurret(GameObject _turret)
    {
        return turret = _turret;
    }

    public GameObject SetTurret()
    {
        return turret;
    }

  
}
