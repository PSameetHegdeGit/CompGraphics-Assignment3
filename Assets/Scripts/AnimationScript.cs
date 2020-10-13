using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
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
        float x_vel = Input.GetAxis("Horizontal");
        float y_vel = Input.GetAxis("Vertical");

        anim.SetFloat("x_vel", x_vel);
        anim.SetFloat("y_vel", y_vel);
    }
}
