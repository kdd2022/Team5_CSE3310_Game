using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{

    private Rigidbody2D body;
    public float speed;
    private FixedJoystick moveStick;
    private Collider2D playerCollide;


    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        moveStick = GameObject.FindWithTag("MoveStick").GetComponent<FixedJoystick>();
       
    }
    void Update()
    {

        body.velocity = new Vector2(moveStick.Horizontal * speed, body.velocity.y);
        
    }
}

