using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Movement : Enemy
{
    [SerializeField] private Vector2 knockBackSpeed; 
    

     public override void TakeDamage(Vector2 direction, float enemyDamageAmount)
     {   
        base.TakeDamage(direction, enemyDamageAmount);
        isThrownBack = true;
        rbEnemy.AddForce(knockBackSpeed * direction, ForceMode2D.Impulse);
     }
}