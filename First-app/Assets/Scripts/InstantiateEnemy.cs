using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy : MonoBehaviour
{
    [SerializeField] private Enemy newEnemy1;
    [SerializeField] private Enemy newEnemy2;
    [SerializeField] private Enemy newEnemy3;
    [SerializeField] private Transform enemySpawnPoint1;
    [SerializeField] private Transform enemySpawnPoint2;
    [SerializeField] private Transform enemySpawnPoint3;
    private float timeCounter=10;
    private List<Enemy> enemiesPool;
    private List<Transform> spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();
        enemiesPool = new List<Enemy> { newEnemy1, newEnemy2, newEnemy3 };
        spawnPoints = new List<Transform> { enemySpawnPoint1, enemySpawnPoint2, enemySpawnPoint3};
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter -= Time.deltaTime;
        //some time count
        // and enemy random position.
        if (timeCounter <= 0)
        {
            SpawnEnemy(); 
            timeCounter = 10;
        }
    }

    void SpawnEnemy()
    {
        Quaternion spawnRotation = Quaternion.identity;

        System.Random random = new System.Random();
        Enemy enemy = Instantiate(enemiesPool[random.Next(0, 2)], spawnPoints[random.Next(0, 2)].position, spawnRotation);
        enemy.enemyRank = random.Next(0, 2);
        enemy.enemyHealth = 3;
        enemy.speed = random.Next(-90, 90);
        
        if (enemy == newEnemy2) {
            enemy.groundCheckDistance = 0.2f;
        }


        //StoneMovement stone = Instantiate(objectToThrow, spawnPoint.position, objectToThrow.transform.rotation);
        //var direction = new Vector2(player.currentPlayerDirection, 1);

        //stone.Launch(direction);
        //totalThrows--;
    }
}
