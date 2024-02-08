using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompRockHead : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Transform startPosTransform;

    [SerializeField] private float speed = 2f;
    private const string PlayerTag = "Player";
    private const string GroundTag = "Ground";

    private Animator anim;

    private bool isMoving = false; // Flag to check if the object is moving towards StartPos

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            MoveTowardsStartPos();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == PlayerTag)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            // Add any other logic you need when colliding with the player
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GroundTag)
        {
            // Start moving towards StartPos when touching the ground
            isMoving = true;

            

            rb.bodyType = RigidbodyType2D.Static;

            anim.SetTrigger("Tophit");

            Debug.Log(isMoving);
        }
    }

    private void MoveTowardsStartPos()
    {
        // Check if startPosTransform is null
        if (startPosTransform == null)
        {
            Debug.LogWarning("startPosTransform is not set. Cannot move towards start position.");
            return;
        }

        // Move towards the StartPos
        transform.position = Vector2.MoveTowards(transform.position, startPosTransform.position, speed * Time.deltaTime);

        // Check if the object has reached the StartPos
        if (Vector2.Distance(transform.position, startPosTransform.position) < 0.01f)
        {
            // Stop moving when reached the StartPos
            isMoving = false;
            // Optionally, you can add additional logic here when the object reaches the StartPos
        }
    }
}
