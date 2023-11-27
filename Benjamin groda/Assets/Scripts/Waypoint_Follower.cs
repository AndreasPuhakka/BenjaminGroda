using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_Follower : MonoBehaviour
{


    [SerializeField] private GameObject[] waypoints;

    private Transform waypointTransform;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;
    void Update()
    {
        waypointTransform = waypoints[currentWaypointIndex].transform;
        if (Vector2.Distance(waypointTransform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position  = Vector2.MoveTowards(transform.position, waypointTransform.position, Time.deltaTime * speed);
    }
}
