using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color startColor;
    public Color highlightColor;
    public Color cantBuyColor;
    NodeUI nodeUI;
    GameObject turret;
    Renderer rend;
    BuildManager buildManager;
    PlayerStats playerStats;
    bool visibility;
    ButtonManager buttonManager;

    void Start()
    {
        nodeUI = NodeUI.Instance;
        rend = GetComponent<Renderer>();
        playerStats = PlayerStats.Instance;
        buildManager = BuildManager.Instance;
        buttonManager = ButtonManager.Instance;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        rend.material.color = highlightColor;

        if (playerStats.money < buildManager.turretCost)
            rend.material.color = cantBuyColor;

    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        // platformda taret varsa
        if (turret != null)
        {
           //buttonManager.choosedTurret = turret;
           // // Taret yüksetme ve satýþ arayüzü görünürüðü
           // nodeUI.transform.position = transform.position;
           // visibility = !visibility;
           // nodeUI.Visibility(visibility);
        }

        //yoksa
        else
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (playerStats.money >= buildManager.turretCost)
            {
                turret = buildManager.SetTurret();
                if (turret == null)
                    return;
                playerStats.money -= buildManager.turretCost;
                UI.Instance.moneyText.text = "Money: " + playerStats.money;
                Instantiate(turret, transform.position, transform.rotation);
            }
        }
    }

    //public void UpgradeTurret()
    //{
    //    if (playerStats.money >= buildManager.turretCost)
    //    {
    //        turret = buildManager.SetTurret();
    //        if (turret == null)
    //            return;
    //        playerStats.money -= buildManager.turretCost;
    //        UI.Instance.moneyText.text = "Money: " + playerStats.money;
    //        Instantiate(turret, transform.position, transform.rotation);
    //    }
    //}

}
