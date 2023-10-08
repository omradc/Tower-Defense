using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Singlton
    public static PlayerStats Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        else
            Destroy(Instance);
    }
    #endregion

    public int playerHealth = 3;
    [HideInInspector] public int money;
    public int startMoney;
    bool once;
    private void Start()
    {
        money = startMoney;
        once = true;
    }
    void Update()
    {
        GameEnd();   
    }
    public void GameEnd()
    {
        if (playerHealth <= 0 && once)
        {
            Time.timeScale = 0;
            GamePanels.Instance.gameOverMenu.SetActive(true);
            GamePanels.Instance.gameOverRoundText.text = $"{EnemySpawner.Instance.waveIndex}";
            once = false;
        }
    }
    public void EarnMoney(int value)
    {
        money += value;
    }
}
