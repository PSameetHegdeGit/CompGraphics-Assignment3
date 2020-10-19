using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    private Animator anim;
    private float run = 0;

    public Transform target;

    public float timescale;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        print("update");

        float x_vel = Input.GetAxis("Horizontal");
        float y_vel = Input.GetAxis("Vertical");

  

        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = Mathf.Clamp01(run + 1 * Time.deltaTime);
        }
        else
        {
            run = Mathf.Clamp01(run - 1 * Time.deltaTime);

        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }
    


        anim.SetFloat("x_vel", x_vel);
        anim.SetFloat("y_vel", y_vel);
        anim.SetFloat("Run", run);

    }

    void OnAnimatorIK()
    {
        var diff = transform.position - target.position;
        diff.y = 0;

        if (diff.magnitude < 50)
        {
            anim.SetLookAtWeight(1);
            anim.SetLookAtPosition(target.position);
        }
        else
        {
            anim.SetLookAtWeight(0);
        }
    }
}
