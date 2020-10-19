using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = (player.transform.position - transform.position) /2;
 
    }

    // Update is called once per frame
    void Update()
    {
       float y = Input.GetAxis("Horizontal");
       float displacement = player.transform.eulerAngles.y;
       Quaternion rotation = Quaternion.Euler(0, displacement, 0);
       transform.position = player.transform.position - (rotation * offset);
       transform.LookAt(player.transform);
    }
}
