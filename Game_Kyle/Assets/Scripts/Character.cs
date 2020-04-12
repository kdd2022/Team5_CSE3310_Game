using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Character : MonoBehaviour
{
    //used for movement speed and flipping character if he moves left or right
    private Rigidbody2D rb;
    private Vector3 localScale;
    private float dirX;
    private bool facingright = true;

    //jump height can be adjusted on the player object under character script
    [SerializeField]
    float jumpForce = 0;

    //character move speed can be adjusted under the left and right button in the canvas object
    private float moveSpeed = 1;

    //used for checking to see if player is on the ground to jump
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;

    //used for animation booleans
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        localScale = transform.localScale;

    }

    
    void Update()
    {
        //Sets the movement speed of the character based on the button that is being pressed
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        //Sets the onGround boolean
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);


        //This is used for flipping the sprite on the x-axis when it turns
        

        //If the jump button is pressed and the character is touching an object with the layer set to ground it will jump
        if (CrossPlatformInputManager.GetButtonDown("Jump") && onGround)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }

        //If the attack button is pressed the character will make the attack animation. If it is not pressed the animation will not trigger
        if (CrossPlatformInputManager.GetButtonDown("Attack"))
        {
            anim.SetBool("isAttack", true);
        }
        else
        {
            anim.SetBool("isAttack", false);
        }

        //if the character is moving in a vertical direction it will trigger the jump/falling animation
        if (rb.velocity.y != 0)
        {
            anim.SetBool("isJump", true);
        }
        else
        {
            anim.SetBool("isJump", false);
        }

        //if the character is moving in a horizontal direction the run animation will trigger
        if (dirX != 0)
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }

    //this will update the rigidbody's velocity based on the movement speed of dirX and rb.velocity.y
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }
    
    //this will check to see if the spite needs turn around
    private void LateUpdate()
    {
        //if the character is moving right it should be face right
        if (dirX > 0)
        {
            facingright = true;
        }
        //else the character is moving left
        else if(dirX < 0)
        {
            facingright = false;
        }

        //if facing right and localScale.x is negative(this means the sprite was facing left then it should flip
        //or vice versa
        if (((facingright) && (localScale.x < 0)) || ((!facingright) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        //set the transformlocalScale to the new reflected status
        transform.localScale = localScale;

    }
}
