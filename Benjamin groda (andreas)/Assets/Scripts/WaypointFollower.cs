using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{

    [SerializeField] private GameObject[] waypoints;
    private Rigidbody2D rb;
    


    private Transform waypointTransform;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }




    void Update()
    {
        waypointTransform = waypoints[currentWaypointIndex].transform;

        if (Vector2.Distance(waypointTransform.position, transform.position) < .1f) {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypointTransform.position, Time.deltaTime * speed);

        

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HitPoint")
        {
            Debug.Log("HitPoint");
        }
    }
}
