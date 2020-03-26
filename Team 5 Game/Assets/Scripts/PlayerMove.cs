using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    protected JoyStick_Move movementStick;
    // Start is called before the first frame update
    void Start()
    {
        movementStick = FindObjectOfType<JoyStick_Move>;
    }

    // Update is called once per frame
    void Update()
    {
        var rigidBody2D =
        
    }
}
