using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameObject block;
    
    // Start is called before the first frame update
    void Awake()
    {
        // Note: This is a temporary solution, this only addresses a single instance
        // of a "block." perhaps we can compile a tile palette and reference the palette.
        // or use a prefab for 
       // block = GameObject.FindGameObjectsWithTag("Platform(Solid)");
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
       // if(col.gameObject = block.getComponent<BoxCollider2D>)
      //  {

       // }
        
    }
}
