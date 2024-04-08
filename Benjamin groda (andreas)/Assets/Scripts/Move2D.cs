using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    private enum MovementState { idle, running, jumping, falling, double_jumping, wall_jumping }
    private MovementState state = MovementState.idle;
    private Rigidbody2D rb;
    [SerializeField] private TextMeshProUGUI jumps;
    private SpriteRenderer sprite;
    private Animator anim;
    [SerializeField] private int jumpForce = 5;
    private float dirX;
    [SerializeField]
    private int movmentSpeed = 5;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private int extraJumps = 1;
    [SerializeField] private int maxJumps = 1;
    private BoxCollider2D boxCol;
    


    [SerializeField] private AudioSource DubbleJumpSoundEffect;
    [SerializeField] private AudioSource JumpSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        UpdateAnimationState();
        rb.velocity = new Vector2(dirX * movmentSpeed, rb.velocity.y);

        if (Input.GetKey("w") && isGrounded())
        {
            Jump();

        }
        else if (Input.GetKeyDown("w") && extraJumps > 0)
        {
            extraJumps--;

            DoubleJump();
            // state = MovementState.double_jumping;
        }
       

        if (isGrounded())
        {
            extraJumps = maxJumps;

        }
    }

    void UpdateAnimationState()
    {
        if (dirX > 0)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > .1f && extraJumps == 0)
        {
            state = MovementState.double_jumping;
        }
        else if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }



    private void Jump()
    {
        JumpSoundEffect.Play();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        // state = MovementState.jumping;
    }

    private void DoubleJump()
    {
        DubbleJumpSoundEffect.Play();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

    }

    private bool isGrounded()
    {
        //Debug.Log("Grounded");
        return Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}


