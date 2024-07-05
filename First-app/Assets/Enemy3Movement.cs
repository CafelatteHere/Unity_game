using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Movement : MonoBehaviour, IDamageable
{
    [SerializeField] private Vector2 hitSpeed;    
    [SerializeField] private float speed;
 
    private Rigidbody2D rbEnemy;

    void Awake()
    {
        rbEnemy = GetComponent<Rigidbody2D>(); 
       // isHit = GetComponent<Enemy>().isHit;
    }

    public void TakeDamage(Vector2 direction)
    {   
        rbEnemy.AddForce(hitSpeed * direction, ForceMode2D.Impulse);
    }

    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
     {

    }
}