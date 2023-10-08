using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    #region Singelton
    public static UI Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        else
            Destroy(Instance);
    }
    #endregion

    private void Start()
    {
        moneyText.text = $"Money: {PlayerStats.Instance.startMoney}";
        liveText.text = $"Lives: {PlayerStats.Instance.playerHealth}";
        waveText.text = $"Wave: {1}";
    }

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI liveText;
    public TextMeshProUGUI waveText;



}
