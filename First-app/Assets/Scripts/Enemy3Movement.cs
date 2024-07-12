using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Movement : EnemyTakeDamage
{
    [SerializeField] private Vector2 hitSpeed; 
       
 

    void Awake()
    {
       // isHit = GetComponent<Enemy>().isHit;
    }
    // public  void startTakeDamage(Vector2 direction){
    //     TakeDamage(direction);
    // }

     public override void TakeDamage(Vector2 direction)
    {   
        Debug.Log("Enemy3Movement method works");
        rbEnemy.AddForce(hitSpeed * direction, ForceMode2D.Impulse);
        Debug.Log("Enemy3Movement added force?");
    }

    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
     {

    }
}