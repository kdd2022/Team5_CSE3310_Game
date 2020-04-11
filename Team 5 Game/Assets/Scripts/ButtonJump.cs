using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonJump : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D playerBody;
    private Transform playerPos;
    private Collider2D playerFeet;
    public float jumpHeight = 5.0f;
    public LayerMask platform;
    private float groundDist;
    
    // Update is called once per frame
    void Awake()
    {

        playerFeet = GameObject.FindWithTag("Player").GetComponent<Collider2D>();
        playerBody = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
        groundDist = playerFeet.bounds.extents.y;
    }
    
    public void OnButtonPress()
    {
        if(isGrounded())
        {
            playerBody.velocity = Vector2.up * jumpHeight;

        }
    }

   bool isGrounded()
    {
        return Physics2D.Raycast(playerPos.position, -Vector2.up, groundDist + 0.1f,platform);

    }


}
