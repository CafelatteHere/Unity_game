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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleSpawnDrops();
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
                    GameObject newDrop = Instantiate(drop, spawnPoint.position, spawnRotation);
                    var direction = new Vector2(0, -1);

                    dropRb = newDrop.GetComponent<Rigidbody2D>();
                    dropRb.AddForce(LaunchSpeed * direction, ForceMode2D.Impulse);
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
