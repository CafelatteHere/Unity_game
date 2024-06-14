using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour, IDamageable
{   
    public bool isHit;
    private Rigidbody2D rbEnemy;
    
    
     void Awake()
    {
        rbEnemy = GetComponent<Rigidbody2D>(); 

    }
        void Start()
    {

    }

   public void TakeDamage(Vector2 direction)
    {
        Debug.Log("enemy2");
    }
    
    void Update()
    {

    }

   
}
