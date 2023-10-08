using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float cameraSpeed = 0.15f;
    public float forward = 6;
    public float back = -30;
    public float up = 35;
    public float down = 10;
    public float left = -5;
    public float right = 5;

    float horizontal;
    float vertical;
    void Start()
    {

    }

    void Update()
    {
        // kamera sýnýrlarý
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, left, right);
        pos.z = Mathf.Clamp(pos.z, back, forward);
        pos.y = Mathf.Clamp(pos.y, down, up);
        transform.position = pos;

        // yatay hareket
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(1, 0, 0) * horizontal * cameraSpeed, Space.World);
        transform.Translate(new Vector3(0, 0, 1) * vertical * cameraSpeed, Space.World);

        // dikey hareket
        if (Input.GetKey(KeyCode.Q))
            transform.Translate(new Vector3(0, -1, 0) * cameraSpeed, Space.World);

        if (Input.GetKey(KeyCode.E))
            transform.Translate(new Vector3(0, 1, 0) * cameraSpeed, Space.World);

    }
}
