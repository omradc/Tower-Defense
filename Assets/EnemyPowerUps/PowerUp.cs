using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Vector3 direction;
    public float rotationalSpeed;
    

    void Update()
    {
        transform.Rotate(direction * Time.deltaTime * rotationalSpeed);
    }
}
