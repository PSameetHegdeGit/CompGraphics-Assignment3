using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class LocationScript : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    Vector2 smoothDeltaPosition = Vector2.zero;
    Vector2 velocity = Vector2.zero;

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        // Don’t update position automatically
        agent.updatePosition = false;
    }

    void Update()
    {
        //What is a simulation position?
        Vector3 worldDeltaPosition = agent.nextPosition - transform.position;

        // Map 'worldDeltaPosition' to local space
        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);

        // Low-pass filter the deltaMove
        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        // Update velocity if time advances
        if (Time.deltaTime > 1e-5f)
            velocity = smoothDeltaPosition / Time.deltaTime;

        bool shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;

        // Update animation parameters
        //anim.SetBool("move", shouldMove);
        anim.SetFloat("x_vel", velocity.x);
        anim.SetFloat("y_vel", velocity.y);

		if(agent.isOnOffMeshLink == true)
		{
			anim.SetTrigger("Jump");
		}

    }

    void OnAnimatorMove()
    {
        // Update position to agent position
        transform.position = agent.nextPosition;
    }
}


//if (Input.GetKey(KeyCode.LeftShift))
//{
//    run = Mathf.Clamp01(run + 1 * Time.deltaTime);
//}
//else
//{
//    run = Mathf.Clamp01(run - 1 * Time.deltaTime);

//}


//if (Input.GetKeyDown(KeyCode.Space))
//{
//    anim.SetTrigger("Jump");
//}

//float x_vel = Input.GetAxis("Horizontal");
//float y_vel = Input.GetAxis("Vertical");





//anim.SetFloat("x_vel", x_vel);
//anim.SetFloat("y_vel", y_vel);

//anim.SetFloat("Run", run);
