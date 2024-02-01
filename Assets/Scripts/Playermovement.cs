using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;

public class Playermovement : MonoBehaviour
{

    private Rigidbody2D rb;

    private Animator anim;

    private float dirX;

    private BoxCollider2D boxCol;

    private SpriteRenderer sprite;

    private float wallJumpCooldown; 
    private enum MovementState {idle,running,jumping,falling,double_jumping,wall_jummping}

    private MovementState state = MovementState.idle;

 

    [SerializeField] private int JumpForce = 7;
    [SerializeField] private int moveSpeed = 5;
    [SerializeField] private float jumpPower;
    [SerializeField] private int ExtraJumps = 1;
    [SerializeField] private int MaxJumps = 1;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private void Awake()
    {
        boxCol = GetComponent<BoxCollider2D>();
    }

    private void Jump()
    {
        if(isGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if (onWall() && !isGrounded())
        {
            if(dirX  == 0)
            {
                rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Math.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            
            wallJumpCooldown = 0;

        }
    }

    private void DoubleJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, JumpForce);
    }

    [Header("Audio")]
    [SerializeField] private AudioSource jumpSoundEffect;


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

    

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        
        }
        else if (Input.GetButtonDown("Jump") && ExtraJumps > 0)
        {
            ExtraJumps--;
            DoubleJump();
        }

        if(isGrounded())
        {
            ExtraJumps = MaxJumps;
        }

        if (wallJumpCooldown > 0.2f)
        {
            if (Input.GetKey(KeyCode.Space))
                Jump();

            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

            if (onWall() && !isGrounded())
            {
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;
            }
            else rb.gravityScale = 1;
        }
        else
            wallJumpCooldown += Time.deltaTime;
    }

    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if(dirX<0)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f && ExtraJumps == 0)
        {
            state = MovementState.double_jumping;
        }
        else if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }


        anim.SetInteger("State", (int)state);


    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0, Vector2.down, 0.1f, groundLayer, jumpableGround);
        return raycastHit.collider != null;
    }
    /*
     * 
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0,new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
    */
}
