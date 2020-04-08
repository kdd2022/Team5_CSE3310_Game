using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Collider2D playerCollider;
    private Collider2D playerGround;
    private Rigidbody2D playerBody;
    // Start is called before the first frame update
    void Awake()
    {
        playerGround = GetComponentInChildren<Collider2D>();
        playerCollider = GetComponent<Collider2D>();
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
