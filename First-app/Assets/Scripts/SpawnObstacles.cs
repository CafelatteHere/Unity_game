using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    [SerializeField] GameObject drop;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Vector2 LaunchSpeed;
    [SerializeField] int stopTimer;

    private Rigidbody2D dropRb;
    private bool isPaused;
    public List<GameObject> pooledDrops = new List<GameObject>();
    public Queue<GameObject> pooledDrops2 = new Queue<GameObject>();
    private int amountToPool = 70;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject newDrop = Instantiate(drop);
            newDrop.SetActive(false);
            pooledDrops2.Enqueue(newDrop);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleSpawnDrops();
    }

    public GameObject GetPooledDrop()
    {
       foreach (GameObject drop in pooledDrops2)
        {
            if (!drop.activeInHierarchy)
            {
               GameObject newDrop = pooledDrops2.Dequeue();
               return newDrop;
            }
        }

        return null;
    }

    void HandleSpawnDrops()
    {
       if (stopTimer > 0)
        {
            stopTimer -= 1;
            //SpawnDrops();
        }

       else if (stopTimer == 0 )
        {

            isPaused = true;
        }
        StartCoroutine(SpawnDrops());

    }

    IEnumerator SpawnDrops()
    {
        if (!isPaused)
        {
        foreach (Transform spawnPoint in spawnPoints) {
                    Quaternion spawnRotation = Quaternion.identity;
                //Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length - 1)];
                // GameObject newDrop = Instantiate(drop, spawnPoint.position, spawnRotation);

                GameObject newDrop = GetPooledDrop();
                Debug.Log("check point 1");

                if (newDrop != null)
                {
                    Debug.Log("check point 2");
                    newDrop.SetActive(true);
                    newDrop.transform.position = spawnPoint.position;
                    var direction = new Vector2(0, -1);

                    dropRb = newDrop.GetComponent<Rigidbody2D>();
                    dropRb.AddForce(LaunchSpeed * direction, ForceMode2D.Impulse);
                }
                    
                }
                yield return new WaitForSecondsRealtime(7f);
        }
        else
        {
            yield return new WaitForSecondsRealtime(4f);
            stopTimer = 20;
            isPaused = false;
        }
    }

}
