using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : Enemy
{   
   public override void TakeDamage(Vector2 direction)
    {
        Debug.Log("enemy2");
    }
    
}
