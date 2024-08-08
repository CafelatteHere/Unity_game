using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] public int currentHealth;
    [SerializeField] int maxHealth;
    public static event Action GameEnd;
    

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