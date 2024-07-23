using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : Enemy
{   
   public override void TakeDamage(Vector2 direction)
    {
        base.TakeDamage(direction);
        Debug.Log("enemy2");
    }
    
}
