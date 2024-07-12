using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : EnemyTakeDamage
{   
    
    
     void Awake()
    {

    }
        void Start()
    {

    }

//    public  void startTakeDamage(Vector2 direction){
//         TakeDamage(direction);
//     }

     public override void TakeDamage(Vector2 direction)
    {
        Debug.Log("enemy2");
    }
    
    void Update()
    {

    }

   
}
