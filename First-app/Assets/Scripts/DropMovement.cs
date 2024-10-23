using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMovement : MonoBehaviour
{

    SpawnObstacles spawnObstacles;

    void Start()
    {
        spawnObstacles = FindObjectOfType<SpawnObstacles>();

    }

    
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("groundLayer"))
        {
           
            gameObject.SetActive(false);
            spawnObstacles.pooledDrops.Enqueue(gameObject); 
        }
    }
}
 