using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour
{
    #region Singelton
    public static Towers Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        if (Instance != null)
            Destroy(Instance);
    }
    #endregion

    public float laserPower;
}
