using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MomEnemy : MonoBehaviour
{
    public PlayerMovement playerObject;
    NavMeshAgent agent;
    [SerializeField] float decisionDelay = 3f;
    [SerializeField] Transform objectToChase;
    [SerializeField] Transform[] waypoints;
    [SerializeField] MomStates currentState;
    int currentWaypoint = 0;
    public bool inViewCone;



    private bool m_FacingRight = true;
    private bool isMoving = false;

    public Animator anim;

    enum MomStates
    {
        Patrolling,
        Chasing
    }

    void Start()
    {
        GameObject g = GameObject.FindGameObjectWithTag("Player");
        playerObject = g.GetComponent<PlayerMovement>();

        anim = GetComponent<Animator>();
        isMoving = false;
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("SetDestination", 1.5f, decisionDelay);
        if (currentState == MomStates.Patrolling) agent.SetDestination(waypoints[currentWaypoint].position);
    }
    void SetDestination()
    {
        if (currentState == MomStates.Chasing) agent.SetDestination(objectToChase.position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !playerObject.crouch)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void Update()
    {
        if (!inViewCone)
        {
            currentState = MomStates.Patrolling;
            print("Mom is " + currentState);
        }
        else
        {
            currentState = MomStates.Chasing;
            print("Mom is " + currentState);
        }
        if (currentState == MomStates.Patrolling)
        {
            if (Vector2.Distance(transform.position, waypoints[currentWaypoint].position) < 0.6f)
            {
                // Pick random point
                // Not the same as the last one
                int nextPoint = -1;

                do
                {
                    nextPoint = Random.Range(0, waypoints.Length - 1);
                }
                while (nextPoint == currentWaypoint);
                currentWaypoint = nextPoint;

                print("Mom is going to the " + waypoints[currentWaypoint].gameObject.name);
                isMoving = true;
                //  currentWaypoint++;
                //  if (currentWaypoint == waypoints.Length)
                //  {
                //      currentWaypoint = 0;
                //  }
            }
            agent.SetDestination(waypoints[currentWaypoint].position);

            if (isMoving == true)
            {
                anim.Play("Run");
            }
            // if (transform.position == targetPoint)
            // {
            //     isMoving = false;
            //     anim.Play("Idle");
            // }

        }
    }
}