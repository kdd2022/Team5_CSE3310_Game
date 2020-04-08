using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonJump : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D player;
    private Collider2D collider;
    public float jumpHeight = 5.0f;
    
    // Update is called once per frame
    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }
    
    public void OnButtonPress()
    {
        player.velocity = Vector2.up * jumpHeight;
    }

}
