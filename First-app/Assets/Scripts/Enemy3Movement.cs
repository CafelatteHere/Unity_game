using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Movement : Enemy
{
    [SerializeField] private Vector2 hitSpeed; 
    

     public override void TakeDamage(Vector2 direction)
    {   
        base.TakeDamage(direction);
        Debug.Log("Enemy3Movement method works");
        isThrownBack = true;
        rbEnemy.AddForce(hitSpeed * direction, ForceMode2D.Impulse);
        Debug.Log("Enemy3Movement added force?" + hitSpeed * direction + "impulse " + ForceMode2D.Impulse);
    }

  
}