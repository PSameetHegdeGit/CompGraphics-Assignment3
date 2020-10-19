using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform Hand;

    void Update()
    {
        var diff = this.transform.position - Hand.position;
        diff.y = 0;
        if (Input.GetMouseButton(0) && diff.magnitude < 2)
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().freezeRotation = true;
            this.transform.position = Hand.position;
            this.transform.parent = GameObject.Find("Bip01 R Hand").transform;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = true;
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

}
