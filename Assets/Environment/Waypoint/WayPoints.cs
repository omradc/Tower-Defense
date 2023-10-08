using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static Transform[] point;
    void Start()
    {
        point = new Transform[transform.childCount];
        for (int i = 0; i < point.Length; i++)
        {
            point[i] = transform.GetChild(i);
        }
    }
}
