using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    GameObject lvl1;
    GameObject lvl2;
    GameObject lvl3;
    public int lvl;


    private void Awake()
    {
        lvl1 = transform.GetChild(0).gameObject;
        lvl2 = transform.GetChild(1).gameObject;
        lvl3 = transform.GetChild(2).gameObject;
    }
    void Start()
    {
        lvl1.SetActive(true);
        lvl = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (lvl==2)
        {
            lvl1.SetActive(false);
            lvl2.SetActive(true);
        }

        if (lvl==3)
        {
            lvl1.SetActive(false);
            lvl2.SetActive(false);
            lvl3.SetActive(true);
        }

    }

    public void LvlUp()
    {
        
    }
}
