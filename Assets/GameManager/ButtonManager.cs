using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    #region Singelton
    public static ButtonManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        else
            Destroy(Instance);
    }
    #endregion


    [Header("Turrets")]
    public GameObject standartTurret;
    public GameObject laserTurret;
    public GameObject missleTurret;

    BuildManager buildManager;
    NodeUI nodeUI;
    [HideInInspector] public GameObject choosedTurret;
    private void Start()
    {
        buildManager = BuildManager.Instance;
        nodeUI = NodeUI.Instance;
    }
    public void StandartTurret()
    {
        buildManager.GetTurret(standartTurret);
        buildManager.turretCost = buildManager.standartTurretLvlCost;
        //nodeUI.Visibility(false);
    }
    public void MissileTurret()
    {
        buildManager.GetTurret(missleTurret);
        buildManager.turretCost = buildManager.missileTurretLvlCost;
        //nodeUI.Visibility(false);
    }
    public void LaserTurret()
    {
        buildManager.GetTurret(laserTurret);
        buildManager.turretCost = buildManager.laserTurretLvlCost;
        //nodeUI.Visibility(false);
    }

    public void Upgrede()
    {
     
    }
    public void Sell()
    {

    }
}
