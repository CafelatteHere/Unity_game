using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropMovement : MonoBehaviour
{
    public static event Action<int> AddDamageToPlayer;

    SpawnObstacles spawnObstacles;

    void Start()
    {
        spawnObstacles = FindObjectOfType<SpawnObstacles>().GetComponent<SpawnObstacles>();
        Debug.Log("spawn script found? " + spawnObstacles);
        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            
        {
            int playerDamage = 1;
            AddDamageToPlayer?.Invoke(playerDamage);
        }

        if (collision.gameObject.tag != "ObstacleSpawnPlatform")
        {
            spawnObstacles.pooledDrops2.Release(gameObject);
            gameObject.SetActive(false);
           // spawnObstacles.pooledDrops.Enqueue(gameObject);
        }
    }


}
    
        

 