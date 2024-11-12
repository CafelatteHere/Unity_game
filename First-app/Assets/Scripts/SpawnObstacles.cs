using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] GameObject drop;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Vector2 LaunchSpeed;
    private float startTimer;
    private float stopTimer;
    [SerializeField] float startTimerMax = 4;
    [SerializeField] float stopTimerMax = 4;
    [SerializeField] float oneDropsRowSpawnTimer = 0.5f;
    [SerializeField] float oneDropsRowSpawnTimerMax = 0.5f;

    private Rigidbody2D dropRb;
    private bool isPaused;
    private int amountToPool = 30;
    public ObjectPool<GameObject> pooledDrops2;


void Start()
{
        GameObject parentGameObject = GameObject.FindGameObjectWithTag("Drops");
        pooledDrops2 = new ObjectPool<GameObject>(

        () => {
          //  return Instantiate(drop);
            GameObject dropInstance = Instantiate(drop, parentGameObject.transform);
          
            Debug.Log("Instantiated drop instance: " + dropInstance);
         
            dropInstance.SetActive(false);
            return dropInstance;
        },
        drop => drop.SetActive(true),
        drop => drop.SetActive(false),
        drop => Destroy(drop),
        false, 30, 30);
      
        for (int i = 0; i < 30; i++)
        {
            pooledDrops2.Get();
        }
        Debug.Log("Total objects created after initialization: " + pooledDrops2.CountAll);
    }

private void SpawnDrops()
{
    foreach (Transform spawnPoint in spawnPoints)
    {
        if (pooledDrops2.CountInactive > 0)
        {
            GameObject newDrop = pooledDrops2.Get();
                Debug.Log("Retrieved from pool: " + newDrop.name);
                newDrop.transform.position = spawnPoint.position;

            Rigidbody2D dropRb = newDrop.GetComponent<Rigidbody2D>();
            Vector2 direction = new Vector2(0, -1);
            dropRb.AddForce(LaunchSpeed * direction, ForceMode2D.Impulse);
        }
    }
}


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



        // () => {
        //     GameObject parentGameObject = GameObject.FindGameObjectWithTag("Drops");
        //     GameObject dropInstance = Instantiate(drop, parentGameObject.transform);
        //     drop.gameObject.SetActive(false);
        //    Debug.Log("hello");
        //    return  drop;
        // },
        ////onGet
        // SpawnDrops,
        // //onRelease
        // drop => drop.gameObject.SetActive(false),
        // // onDestroy
        // drop => Destroy(drop.gameObject),
        // //collectionCheck, defaultCapacity, maxSize
        // true, 7, 100
        //);

        //pooledDrops2.Get();
        //}

        //private GameObject CreateObstacle(GameObject objectToSpawn)
        //{
        //    GameObject parentGameObject = GameObject.FindGameObjectWithTag("Drops");
        //    Debug.Log(parentGameObject);
        //    GameObject newDrop = Instantiate(objectToSpawn, parentGameObject.transform);
        //    Debug.Log(newDrop);
        //    newDrop.SetActive(false);
        //    return newDrop;
        //}

        //private GameObject AddToPool(GameObject objectToSpawn)
        //{
        //    for (int i = 0; i < amountToPool; i++)
        //    {
        //        //GameObject parentGameObject = GameObject.FindGameObjectWithTag("Drops");
        //        //GameObject newDrop = Instantiate(objectToSpawn, parentGameObject.transform);
        //        //newDrop.SetActive(false);
        //        pooledDrops2.Release(newDrop);
        //    }
        //}

        // Update is called once per frame

        //private void SpawnDrops(GameObject newDrop)
        //{
        //    foreach (Transform spawnPoint in spawnPoints)
        //    {
        //        // pooledDrops2.Get();
        //        Quaternion spawnRotation = Quaternion.identity;
        //        newDrop.SetActive(true);

        //        newDrop.transform.position = spawnPoint.position;
        //        var direction = new Vector2(0, -1);
        //        dropRb = newDrop.GetComponent<Rigidbody2D>();
        //        dropRb.AddForce(LaunchSpeed * direction, ForceMode2D.Impulse);
        //    }

    }
    //public GameObject GetPooledDrop()
    //{
    //   foreach (GameObject drop in pooledDrops)
    //    {
    //        if (!drop.activeInHierarchy)
    //        {
    //           GameObject newDrop = pooledDrops.Dequeue();
    //           return newDrop;
    //        }
    //    }

    //    return null;
    //}



}
