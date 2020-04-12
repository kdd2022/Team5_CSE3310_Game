﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    float distance = 1;


    // Update is called once per frame
    void Update()
    {
        //Gets the player position for the player object
        Vector3 PlayerPOS = GameObject.Find("Player").transform.transform.position;

        //Sets the Main Camera to follow the player
        //can add or subract values from POS.x and POS.y to position it differently around character
        GameObject.Find("Main Camera").transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y + 1, PlayerPOS.z - distance);
    }
}
