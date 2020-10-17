using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationScript : MonoBehaviour
{
    private NavMeshAgent agent;
    private string groundTag = "ground";

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            Ray clickedPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(clickedPoint, out hit))
            {
                var selection = hit.transform;

                if (selection.CompareTag(groundTag))
                {
                    agent.SetDestination(hit.point);

                }

            }
        }


    }
}
