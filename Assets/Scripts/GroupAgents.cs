using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GroupAgents : MonoBehaviour
{

    private NavMeshAgent[] agents;

    // Start is called before the first frame update
    void Start()
    {
        agents = new NavMeshAgent[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            agents[i] = transform.GetChild(i).GetComponent<NavMeshAgent>();
        }


        simulationMove();


    }

    // Update is called once per frame
    void Update()
    {
        print(transform.childCount);

        //print(agents.Length);

        //StartCoroutine("simulation");

    }


    void simulationMove()
    {
        int i = 1;
        foreach (NavMeshAgent agent in agents)
        {
            if(i <= 3)
            {
              
                Vector3 offset = Random.insideUnitCircle * 1.5f;
                Vector3 targetPosition = new Vector3(-35, 0, -27) + offset;
                agent.SetDestination(targetPosition);
            }
            else if (i <= 6)
            {
                Vector3 offset = Random.insideUnitCircle * 0.5f;
                Vector3 targetPosition = new Vector3(-4.5f, 1, -26.5f) + offset;
                agent.SetDestination(targetPosition);
            }
            else if (i <= 10)
            {
                Vector3 offset = Random.insideUnitCircle * 0.5f;
                Vector3 targetPosition = new Vector3(-38.5f, 1, 7.5f) + offset;
                agent.SetDestination(targetPosition);
            }

            ++i;
            print(i);
        }
    }
}
