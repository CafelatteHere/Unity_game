using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] int maxHealth;

    public float score;
    public int enemiesKilled;
    public int currentHealth;

    public static event Action GameEnd;
    public static event Action<int> LiveCountDecrease;
    public static event Action<float> ScoreCountIncrease;

    public static GameController Instance { get; private set; }

    private void Awake()
    {
       if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
       else
        {
            Destroy(gameObject);
            Debug.Log("One instance of GameController already exists. Destroying another one");
            
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
        score = 0;
    }

    private void OnEnable()
    {
        Enemy.LiveCountDecrease += DecreaseLive;
        Enemy.AddPoints += calculatePoints;
        
    }

    private void OnDisable()
    {
        Enemy.LiveCountDecrease -= DecreaseLive;
        Enemy.AddPoints -= calculatePoints;
    }

    public void DecreaseLive(int damage)
    {
        if ((currentHealth - damage) <= 0)
        {
            currentHealth = 0;
            GameEnd?.Invoke();
            Debug.Log("invoked game end");
        }
        else
        {
            currentHealth -= damage;
        }
    }

    public void calculatePoints(float points, bool enemyIsKilled, float enemyRank)
    {
        points += (enemyRank * 0.5f);
        score += points;
        
        if (enemyIsKilled)
        {
            enemiesKilled += 1;
        }
        ScoreCountIncrease?.Invoke(score);
    }

}