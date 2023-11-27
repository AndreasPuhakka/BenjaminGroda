using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

{
    private Rigidbody2D rb;

    private Animator anim;

    private enum MovementState { idle, running, jumping, falling, duble_jumping, wall_jumping}
    private MovementState state = MovementState.idle;

    private float dirX; 
    private SpriteRenderer sprite;

    [SerializeField] private int jumpForce = 5;
    [SerializeField] private int moveSpeed = 5;
    [SerializeField] private int extraJumps = 1;
    [SerializeField] private int maxJumps = 1;
    [SerializeField] private LayerMask jumpableGround;
    private BoxCollider2D boxCol;

    [Header("Audio")]
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource doubbelJumpSoundEffect;
   

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

        rb.velocity = new Vector2 (dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded()) {
            Jump();
        }
        else if(Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            extraJumps--;
            DoubleJump();
        }
        UpdateAnimationState();
        
        if (isGrounded())
        {
            extraJumps = maxJumps;
        }
       
    }

    void UpdateAnimationState()
    {
        if(dirX > 0f){
           state = MovementState.running;
            sprite.flipX = false;
        }
        else if(dirX < 0f)
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
            state = MovementState.duble_jumping;
        }

        else if (rb.velocity.y > .1f) {
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
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpSoundEffect.Play();
    }

    private void DoubleJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        doubbelJumpSoundEffect.Play();
    }
    private bool isGrounded() {
        return Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
