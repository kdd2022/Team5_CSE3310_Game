using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPotion : MonoBehaviour
{   
    public GameObject player;   //for detecting collision
    public Character mycharacter; //for updating character hp
    public int healAmount; //potion heal amount
    
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == player.tag)
        {

            mycharacter.playerHP += healAmount;

            if(mycharacter.playerHP > mycharacter.playerMaxHP)
            {

                mycharacter.playerHP = mycharacter.playerMaxHP;

            }
            Destroy(gameObject);
        }
    }
}
