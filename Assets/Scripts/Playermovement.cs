<<<<<<< HEAD
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRend;
    private BoxCollider2D boxCol;
    private SpriteRenderer sprite;


    [Header("Ground collision")]
    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private int extraJumps = 1;
    [SerializeField] private int maxJumps = 1;

    private enum MovementState { idle, running, jumping, falling, double_jumping, wall_jumping }
    private MovementState state = MovementState.idle;

    [Header("Audio")]
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource doubleJumpSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        Move();

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
        else if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            extraJumps--;
            DoubleJump();
        }

        UpdateAnimationState();


        if (IsGrounded())
        {
            extraJumps = maxJumps;
        }

    }
    private void Awake()
    {
        boxCol = GetComponent<BoxCollider2D>();
    }
    private void Move()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (dirX > 0)
        {
            spriteRend.flipX = false;
        }
        else if (dirX < 0)
        {
            spriteRend.flipX = true;
        }

    }

    private void Jump()
    {
        jumpSoundEffect.Play();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void DoubleJump()
    {
        doubleJumpSoundEffect.Play();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }


    private void UpdateAnimationState()
    {

        if (dirX > 0f)
        {
            state = MovementState.running;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
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

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}














/*using System;
>>>>>>> 094450453a04ca42233c74c06479f91a08f5077f
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRend;
    private BoxCollider2D boxCol;
    private float walljumpCooldown;
    public float wallJumpForce = 10f;
    public float wallJumpHorizontalForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    


<<<<<<< HEAD
=======
    private void Jump()
    {
        if(isGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
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
>>>>>>> 094450453a04ca42233c74c06479f91a08f5077f

    [Header("Ground collision")]
    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private int extraJumps = 1;
    [SerializeField] private int maxJumps = 1;

    private enum MovementState { idle, running, jumping, falling, double_jumping, wall_jumping, attack, roll }
    private MovementState state = MovementState.idle;

    [Header("Audio")]
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource doubleJumpSoundEffect;
    [SerializeField] private AudioSource deathSoundEffect;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD

        anim.SetFloat("AirSpeedY", rb.velocity.y);
=======
       
>>>>>>> 094450453a04ca42233c74c06479f91a08f5077f
        dirX = Input.GetAxisRaw("Horizontal");
        Move();
        if (isGrounded()){
            anim.SetBool("Grounded", true);
        }
        else
        {
            anim.SetBool("Grounded", false);
        }
     


        if (Input.GetButtonDown("Jump") && isGrounded())
        {

            
            Jump();

        }
        else if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            extraJumps--;
            DoubleJump();
        }

        UpdateAnimationState();


        if (isGrounded())
        {
            extraJumps = maxJumps;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Roll();
        }

        if(Wall())
        {
            anim.SetTrigger("WallSlide");
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (dirX > 0)
        {
            spriteRend.flipX = false;
        }
        else if (dirX < 0)
        {
            spriteRend.flipX = true;
        }

    }

    private void Jump()
    {
        anim.SetTrigger("Jump");
        jumpSoundEffect.Play();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    

    private void DoubleJump()
    {
        doubleJumpSoundEffect.Play();
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }


    private void UpdateAnimationState()
    {

        if (dirX > 0f)
        {
            state = MovementState.running;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
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


        anim.SetInteger("AnimState", (int)state);
    }

    private bool isGrounded()
    {
<<<<<<< HEAD
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;

    }
    private bool Wall()
=======
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
        return raycastHit.collider != null;
    } 
    
    private bool onWall()
>>>>>>> 094450453a04ca42233c74c06479f91a08f5077f
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
<<<<<<< HEAD
 
    private void Block()
    {
        anim.SetTrigger("Block");
    }

   
    
    

    private void Roll()
    {
        anim.SetTrigger("Rollin");
  
    }
    private void WallJump()
    {
        if (transform.localScale.x > 0) 
        {
            rb.velocity = new Vector2(-wallJumpHorizontalForce, jumpForce);
        }
        else
        {
            rb.velocity = new Vector2(wallJumpHorizontalForce, jumpForce);
        }
       

        }
    }


    
=======
}
*/
>>>>>>> 094450453a04ca42233c74c06479f91a08f5077f
