using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMovement : MonoBehaviour
{

    SpawnObstacles spawnObstacles;

    // Start is called before the first frame update
    void Start()
    {
        spawnObstacles = FindObjectOfType<SpawnObstacles>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision happened");
        Debug.Log(collision.gameObject);
        if (collision.gameObject.layer == LayerMask.NameToLayer("groundLayer"))
        {
            Debug.Log(gameObject);
           
            gameObject.SetActive(false);
            spawnObstacles.pooledDrops2.Enqueue(gameObject);
        }
    }
}
 