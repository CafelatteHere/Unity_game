using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] public int currentHealth;
    [SerializeField] int maxHealth;
    //  [SerializeField] int damage;
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