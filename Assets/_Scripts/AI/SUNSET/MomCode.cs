using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomCode : MonoBehaviour
{
    // Where is the kid
    private Transform playerTransform;

    // State Machine Related variables
    private Animator animator;
    bool chasing = false;
    bool waiting = false;
    private float distanceFromTarget;
    public bool inViewCone;

    // Where is she going and how fast?
    Vector2 direction;
    public float runSpeed = .05f;
    private int currentTarget;
    private Transform[] upstairsWaypoints = null;
    private Transform[] middleFloorWaypoints = null;
    private Transform[] basementWaypoints = null;
    private Transform[] waypoints = null;

    // When mom is added, this fires up
    private void Awake()
    {
        // Find the player initially
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Reference the State Machine (animator)
        animator = gameObject.GetComponent<Animator>();

        // Add the waypoints

        Transform point1 = GameObject.Find("Attic").transform;
        Transform point2 = GameObject.Find("ParentRoom").transform;
        Transform point3 = GameObject.Find("KidRoom").transform;
        Transform point4 = GameObject.Find("Kitchen").transform;
        Transform point5 = GameObject.Find("LivingRoom").transform;
        Transform point6 = GameObject.Find("Bathroom").transform;
        Transform point7 = GameObject.Find("Basement").transform;
        Transform point8 = GameObject.Find("UpperStairs").transform;
        Transform point9 = GameObject.Find("MiddleStairs").transform;
        Transform point10 = GameObject.Find("BasementStairs").transform;


        upstairsWaypoints = new Transform[3] {
            point2,
            point3,
            point8,
        };
        middleFloorWaypoints = new Transform[4] {
            point4,
            point5,
            point6,
            point9,
        };
        basementWaypoints = new Transform[2] {
            point7,
            point10
        };

        // waypoints = new Transform[10] {
        //     point1,
        // };
    }
    // Update is called once per frame
    void Update()
    {
        // If Chasing, go towards player
        if (chasing)
        {
            direction = playerTransform.position - transform.position;
            // rotateMom();
        }

        // Unless mom is waiting then move

        if (!waiting)
        {
            transform.Translate(runSpeed * direction * Time.deltaTime, Space.World);
        }

    }

    private void FixedUpdate()
    {
        // Give values to the state machine
        distanceFromTarget = Vector2.Distance(waypoints[currentTarget].position, transform.position);
        animator.SetFloat("distanceFromWaypoint", distanceFromTarget);
        animator.SetBool("playerInSight", inViewCone);
    }

    public void SetNextPoint()
    {
        // Pick random point
        // Not the same as the last one
        int nextPoint = -1;

        do
        {
            nextPoint = Random.Range(0, waypoints.Length - 1);
        }
        while (nextPoint == currentTarget);

        currentTarget = nextPoint;
        print("Mom is going to the " + waypoints[currentTarget].gameObject.tag);
        // What direction is next waypoint?
        direction = waypoints[currentTarget].position - transform.position;
        // rotateMom();
    }

    public void Chase()
    {
        // What direction is the kid?
        direction = playerTransform.position - transform.position;
        rotateMom();
    }

    public void StopChasing()
    {
        print("Mom is not chasing you");
        chasing = false;
    }

    private void rotateMom()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        direction = direction.normalized;
    }

    public void StartChasing()
    {
        print("Mom is chasing you");
        chasing = true;
    }

    public void ToggleWaiting()
    {
        print("Mom is waiting");
        waiting = !waiting;
    }

}
