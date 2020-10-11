using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonLogic : MonoBehaviour
{

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        control();

    }

    public void control()
    {


        var direction = transform.forward;
        var x_vel = Input.GetAxis("Horizontal");
        var y_vel = Input.GetAxis("Vertical");

        print(x_vel);
        print(y_vel);

        anim.SetFloat("XVelocity", x_vel);
        anim.SetFloat("YVelocity", y_vel);
    }


}
