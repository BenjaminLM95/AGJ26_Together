using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    private List<Transform> waypoints;
    private Vector3 targetPosition;
    [SerializeField] private float moveSpeed;
    private int waypointIndex;
    [SerializeField] private bool waitsOnPoint;
    [SerializeField] private float waitTime;

    void Awake()
    {
        waypoints = new List<Transform>();
        GetListOfWaypoints();

    }
    // Update is called once per frame
    void Update()
    {
        HandleWaypoint();
    }

    private float waitTimer;

    private void HandleWaypoint()
    {
        if (waypoints == null) return;

        //Moves toawrd the target position
        transform.position = Vector3.MoveTowards(transform.position,targetPosition,moveSpeed * Time.deltaTime);


        if (Vector3.Distance(transform.position, targetPosition) < .05f)
        {
            if (!waitsOnPoint)
            {
                GetNextPosition();
                return;
            }

            waitTimer += Time.deltaTime;

            if (waitTimer >= waitTime)
            {
                waitTimer = 0f;
                GetNextPosition();
            }
        }
        else
        {
            waitTimer = 0f;
        }
    }

    private void GetNextPosition()
    {
        waypointIndex = (waypointIndex + 1) % waypoints.Count;
        targetPosition = waypoints[waypointIndex].position;
    }

    void GetListOfWaypoints()
    {
        
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Waypoint"))
            {
                waypoints.Add(child);
            }
        }

        foreach (Transform child in waypoints)
        {
            child.SetParent(null);
        }

        if (waypoints.Count > 0)
        {
            targetPosition = waypoints[0].position;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            DontDestroyOnLoad(collision.gameObject); 
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            if (!child.CompareTag("Waypoint")) continue;

            Gizmos.DrawCube(child.position, Vector3.one);

            int nextIndex = (i + 1) % transform.childCount;
            Transform nextChild = transform.GetChild(nextIndex);

            if (nextChild.CompareTag("Waypoint"))
            {
                Gizmos.DrawLine(child.position, nextChild.position);
            }
        }
    }
}
