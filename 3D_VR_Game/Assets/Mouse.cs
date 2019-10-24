using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public float speedH2 = 2.0f;
    public float speedV2 = 2.0f;

    private float yaw1 = 0.0f;
    private float pitch2 = 0.0f;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        yaw1 += speedH2 * Input.GetAxis("Mouse X");
        pitch2 -= speedV2 * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch2, yaw1, 0.0f);

    }
}