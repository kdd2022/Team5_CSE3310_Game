using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    private bool isJumping = false;
    private bool isFalling = false;
    private float angle;
    

    // Update is called once per frame
    

    /* 
     * Current Bugs:
     * - Holding into the ground will make sprite jump up and down rapidly, causing in some cases height gain
     * - Quick strokes of the touchpad will causes a large increase of speed, compared to the consistent speed of holding down
     * - Running into objects constantly while attempting to jump will propel the player into the air
    */
 
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //If mouse button one is clicked (or when a screen is touched)
        {
            // The starting point will be the position of that click, in accordance to the camera's current location
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));

        }
        if (Input.GetMouseButton(0)) // If mouse button changed, or status of touch change, run this 
        {
            // A movement has accorded, so touchStart is true. And the next place the mouse/fingers occurs is point B
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            angle = Vector2.SignedAngle(pointA, pointB);
            // Calculate the angle between the start and end point

            // Allow jumping for any angle above 30, so we don't have very short jumps
            if(Mathf.Abs(angle)<0)
            { // Until I figure out jumping horizontal moves are only allowed
                pointB.y = pointA.y;
                // Set the y value constant to initial point, to prevent height elevation
            }
            else
            {
                isJumping = true;
            }
        }
        else
        {
            touchStart = false;
        }

    }
    private void FixedUpdate()
    {
        // If the movement stick has been moved, find the distance between playr's starting and ending place
        Collider2D playerCollide = GetComponent<Collider2D>();

        // If player is not colliding with any platforms, then they are falling
        if (playerCollide.IsTouchingLayers(LayerMask.GetMask("Platforms")) == false)
        {
            isFalling = true;
           // isJumping = false;
        }
        else
        {
            isFalling = false;
        }

        if (touchStart)
        {
            Vector2 offset = pointB - pointA;
            // Distance between the start and end location
            Vector2 direction;
            if(offset.y<0)
            {
                /* TO DO:
                 * Condition to check if the platform below the player is passable, and
                 * allow player to fall down it if so, otherwise don't allow player to drop
                 */
                offset.y = 0;
            }

            if (isFalling)
            {
                offset = new Vector2(offset.x, 0);
                // If the player is falling, only allow the x value to variate.
                direction = Vector2.ClampMagnitude(offset, speed / 3);
            }
            // Broken jump implementation
          /*  else if (isJumping)
             {
                direction = Vector2.ClampMagnitude(offset, jumpHeight);
              }*/
            else
            {
                direction = Vector2.ClampMagnitude(offset, speed);
            }
            moveCharacter(direction);
            // Default function in Unity to move the player

           
        }

    }
    void moveCharacter(Vector2 direction)
    {
        Transform playerMove = gameObject.GetComponent<Transform>();
        playerMove.Translate(direction * speed * Time.deltaTime);
    }
}
