using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour, IDamageable
{
    public Rigidbody2D rbEnemy;
    void Awake() 
    {
        rbEnemy = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void TakeDamage(Vector2 direction) {
        Debug.Log("Base Enemy class, take damage");
    }
}
