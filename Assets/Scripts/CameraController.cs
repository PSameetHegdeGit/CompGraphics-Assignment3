using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CameraController : MonoBehaviour
{


    Vector3 offset;

    const int orthographicSizeMin = 1;
    const int orthographicSizeMax = 6;

    void Start()
    {
        //offset = player.transform.position - transform.position;
    }

    void Update()
    {

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            transform.Translate(0, 0, scroll * 5, Space.Self);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            transform.Translate(0, 0, scroll * 5, Space.Self);
        }

        if (!Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftCommand))
        {
            var movement = Camera.main.transform.right * Input.GetAxis("Horizontal");
            var verticalMovement = Input.GetAxis("Vertical");
            var temp = Camera.main.transform.forward;
            temp.y = 0;
            movement += temp.normalized * verticalMovement;
            transform.position += movement;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        }


        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.LeftCommand))
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Rotate(-1.0f, 0.0f, 0.0f);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0.0f, -1.0f, 0.0f);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(1.0f, 0.0f, 0.0f);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0.0f, 1.0f, 0.0f);
            }

        }
    }


}