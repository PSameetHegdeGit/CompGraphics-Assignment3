using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationScript : MonoBehaviour
{
    private NavMeshAgent agent;
    private string groundTag = "ground";

    Vector3 targetPosition;

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
                    Vector3 offset = Random.insideUnitCircle * 0.5f;
                    targetPosition = hit.point + offset;
                    agent.SetDestination(targetPosition);

                }

            }
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
}



