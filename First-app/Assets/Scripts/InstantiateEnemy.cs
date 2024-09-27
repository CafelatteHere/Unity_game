using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemy : MonoBehaviour
{
    [SerializeField] private Enemy[] enemiesPool;
    [SerializeField] private Transform[] spawnPoints;

    private float timeCounter=10;
    bool isGameOver;
    public List<Enemy> enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<Enemy>();
        Enemy[] enemiesAtScene = FindObjectsOfType<Enemy>();
        enemies.AddRange(enemiesAtScene);
      
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

    private void OnEnable()
    {
        GameController.GameEnd += GameStateCheck;
    }

    private void OnDisable()
    {
        GameController.GameEnd -= GameStateCheck; 
    }

    private void GameStateCheck ()
    {
        isGameOver = true;
    }

    void SpawnEnemy()
    {
        Quaternion spawnRotation = Quaternion.identity;

        System.Random random = new System.Random();
        if (!isGameOver && enemies.Count < 8)
        {
            Enemy randomEnemy = enemiesPool[Random.Range(0, enemiesPool.Length-1)];
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length-1)];
            Enemy enemy = Instantiate(randomEnemy, randomSpawnPoint.position, spawnRotation);
            enemy.enemyRank = random.Next(1, 3);
            enemy.enemyHealth = enemy.enemyRank * 15;
            enemy.speed = random.Next(-90, 90);
            enemy.gameObject.layer = LayerMask.NameToLayer("Enemy");
            if (enemy.speed == 0)
            {
                enemy.speed += 30;
            }
            else if (Mathf.Abs(enemy.speed) < 30)
            {
                float sign = Mathf.Sign(enemy.speed);
                enemy.speed += 30 * sign;

            }
            enemy.groundLayerMask = LayerMask.GetMask("groundLayer");

            if (enemy.enemyRank == 2)
            {
                enemy.groundCheckDistance = 0.2f;
            }
            enemies.Add(enemy);

           foreach(Enemy enemyObj in enemies)
            {
                Debug.Log(enemyObj);
            }
        }
    }
}
