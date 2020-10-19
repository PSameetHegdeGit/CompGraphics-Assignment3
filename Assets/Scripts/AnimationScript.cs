using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class AnimationScript : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;

    private string groundTag = "ground";

    Vector3 targetPosition;

    bool one_click = false;
    float timer_for_double_click;

    float delay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetMouseButtonUp(0))
        {

            if (!one_click) // first click no previous clicks
            {
                one_click = true;
                timer_for_double_click = Time.time; // save the current time

                                                
                Ray clickedPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;


                anim.SetFloat("Run", 0.0f);

                if (Physics.Raycast(clickedPoint, out hit))
                {
                    var selection = hit.transform;

                    if (selection.CompareTag(groundTag))
                    {
                        Vector3 offset = Random.insideUnitCircle * 0.5f;
                        targetPosition = hit.point + offset;
                        agent.SetDestination(targetPosition);

                    }

                }
            }
            else
            {
                one_click = false;
                anim.SetFloat("Run", 1.0f);
            }
            
        }
		/*
		if(agent.isOnOffMeshLink == true)
		{
			LocationScript.anim.SetTrigger("Jump");
		}
		*/

        if (one_click)
        {
            // if the time now is delay seconds more than when the first click started. 
            if ((Time.time - timer_for_double_click) > delay)
                one_click = false;

        }


        StartCoroutine("haltAgents");
    }



    void haltAgents()
    {

        if (targetPosition != null)
        {

            if (Vector3.Distance(targetPosition, agent.transform.position) <= 3f)
            {
                agent.velocity = Vector3.zero;

            }

        }

    }
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("smallObstacle")) //character hits small obstacle
        {
			anim.SetTrigger("Jump");
			print("hello123123");
        }
	}

}



