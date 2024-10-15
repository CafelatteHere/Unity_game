using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] GameObject drop;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Vector2 LaunchSpeed;
    [SerializeField] float startTimer = 4;
    [SerializeField] float stopTimer = 4;
    [SerializeField] float startTimerMax = 4;
    [SerializeField] float stopTimerMax = 4;
    [SerializeField] float oneDropsRowSpawnTimer = 0.5f;
    [SerializeField] float oneDropsRowSpawnTimerMax = 0.5f;

    private Rigidbody2D dropRb;
    private bool isPaused;
    public Queue<GameObject> pooledDrops = new Queue<GameObject>();
    private int amountToPool = 30;
 
    void Start()
    {
        AddToPool(drop);
    }

    private void AddToPool(GameObject objectToSpawn)
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject parentGameObject = GameObject.FindGameObjectWithTag("Drops");
            GameObject newDrop = Instantiate(objectToSpawn, parentGameObject.transform);
            newDrop.SetActive(false);
            pooledDrops.Enqueue(newDrop);
        }
    }

    // Update is called once per frame
    void Update()
    {
        stopTimer -= Time.deltaTime;
        if (stopTimer < 0)
        {
   
            startTimer -= Time.deltaTime;
            oneDropsRowSpawnTimer -= Time.deltaTime;
            if (oneDropsRowSpawnTimer < 0)
            {
                SpawnDrops();
                oneDropsRowSpawnTimer = oneDropsRowSpawnTimerMax;
                
            }
            
            if (startTimer < 0)
            {
                stopTimer = stopTimerMax;
                startTimer = startTimerMax;
            }
        }
       
    }

    public GameObject GetPooledDrop()
    {
       foreach (GameObject drop in pooledDrops)
        {
            if (!drop.activeInHierarchy)
            {
               GameObject newDrop = pooledDrops.Dequeue();
               return newDrop;
            }
        }

        return null;
    }

   
  private void SpawnDrops()
    {
        foreach (Transform spawnPoint in spawnPoints) {
                    Quaternion spawnRotation = Quaternion.identity;
                //Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];
                // GameObject newDrop = Instantiate(drop, spawnPoint.position, spawnRotation);

                GameObject newDrop = GetPooledDrop();

                if (newDrop != null)
                {
                    newDrop.SetActive(true);
                    newDrop.transform.position = spawnPoint.position;
                    var direction = new Vector2(0, -1);

                    dropRb = newDrop.GetComponent<Rigidbody2D>();
                    dropRb.AddForce(LaunchSpeed * direction, ForceMode2D.Impulse);
                }
                  else
            {
                Debug.Log("not enough drops, making new ones!");
                newDrop = Instantiate(drop);
                newDrop.SetActive(false);
                pooledDrops.Enqueue(newDrop);
            }
                }        
    }

}
