using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //all of these values can be adjusted in an enemy object with this script
    
    [SerializeField]
    public float aggroRange = 0;
    [SerializeField]
    public float stopRange = 0;
    [SerializeField]
    public float moveSpeed = 0;
    [SerializeField]
    public float health = 0;


    //to select the player you need to drag the player object into the field
    //this will be used so the enemy can check their distance to the player
    [SerializeField]
    Transform player;
    
    //this next object is the hitbox of the players weapon. to set this you need to drag the AttackBox object under player 
    //into this field under an enemy with this script
    [SerializeField]
    public GameObject hitbox;

    //This will be used to determine how much damage the player does
    private myDamage damageScript;
    
    //set rigidbody so the enemy can move
    Rigidbody2D rb2d;

    //This will be used to set the color of the enemy to red when health is low
    private SpriteRenderer bar;
    //Thisd will be used to set animation booleans
    private Animator anim;

    
    void Start()
    {
        //set all of the components we need to their variables
        bar = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        damageScript = hitbox.GetComponent<myDamage>();
    }


    void Update()
    { 
        //This will determine between the enemy and the player
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        //if player is within the aggro range but also not close enough to attack then 
        //walk animation needs to be set to true and the chaseplayer function will be called
        //to set the enemy movement variables
        if ((distToPlayer < aggroRange) && (distToPlayer > stopRange))
        {
            anim.SetBool("Attack", false);
            anim.SetBool("canWalk", true);
            ChasePlayer();
        }
        //if the enemy is close enough to the player the enemy will stop moving and walk animation
        //then the enemy will start the attack animation
        else if (distToPlayer <= stopRange)
        {
            rb2d.velocity = new Vector2(0, 0);
            anim.SetBool("canWalk", false);
            anim.SetBool("Attack", true);
        }
        //else the character is not within range for the enemy to do anything so it will set both attack and walk animations to false
        //which should trigger the idle animation the start again
        else 
        {
            rb2d.velocity = new Vector2(0, 0);
            anim.SetBool("canWalk", false);
            anim.SetBool("Attack", false);
        }


        //this will set the character of the sprite to red if it is less than or equal to 20
        if (health <= 20)
        {
            bar.color = Color.red;
        }

        //if the enemy health drops to 0 or below then it will be destroyed
        if (health <= 0)
        {
            Destroy(gameObject);
        }


    }

    //This function will determine if the enemy has been hit by an attack
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == hitbox.tag)
        {
            health -= damageScript.realDamage;
        }
    }

    //This is fucntion that will set the movement speed of the enemy if the player is within range 
    void ChasePlayer()
    {
        //if the player is to the right of the enemy then movement should be positive
        //and the sprite should be flipped to face the right
        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        //Else the player is to the left so the enemy movement should be negative
        //and the sprite should be flipped to face the left
        else
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }

   

}



