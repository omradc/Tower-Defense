using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    #region Singelton
    public static NodeUI Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        else
            Destroy(Instance);

        canvas = transform.GetChild(0).gameObject;
    }
    #endregion
    GameObject canvas;
    void Start()
    {
        Visibility(false);
        
    }

    void Update()
    {

    }

    public void Visibility(bool visibility)
    {
        canvas.SetActive(visibility);
    }

}
