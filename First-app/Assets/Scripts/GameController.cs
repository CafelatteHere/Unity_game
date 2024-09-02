using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] public int currentHealth;
    [SerializeField] int maxHealth;
    public static event Action GameEnd;
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
    }

    private void OnEnable()
    {
        Enemy.LiveCountDecrease += DecreaseLive;
    }

    private void OnDisable()
    {
        Enemy.LiveCountDecrease -= DecreaseLive;
    }

    public void DecreaseLive(int damage)
    {
        Debug.Log("health is: " + currentHealth);
        if ((currentHealth - damage) <= 0)
        {
            currentHealth = 0;
            GameEnd?.Invoke();

        }
        else
        {
            currentHealth -= damage;
        }
    }
    
}