using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPotion : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == player.tag)
        {
            Destroy(gameObject);
        }
    }
}
