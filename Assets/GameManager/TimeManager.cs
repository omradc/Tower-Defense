using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    #region Singelton
    public static TimeManager Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        else
            Destroy(Instance);
    }
    #endregion 

    int timeValue;
    public int realTimeValue;

    public TextMeshProUGUI timeText;
    void Start()
    {
        timeValue = 2;
        realTimeValue = 1;
    }


    void Update()
    {

    }
    public void TimeChanger()
    {
        switch (timeValue)
        {
            case 1:
                Time.timeScale = 1;
                timeText.text = $"1x";
                timeValue = 2;
                realTimeValue = 1;
                break;
            case 2:
                Time.timeScale = 2;
                timeText.text = $"2x";
                timeValue = 4;
                realTimeValue = 2;
                break;
            case 4:
                Time.timeScale = 4;
                timeText.text = $"4x";
                timeValue = 1;
                realTimeValue = 4;
                break;
        }
    }
}
