using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour, IDamageable
{   
    public bool isHit;
    private Rigidbody2D rbEnemy;
    
    
    public void TakeDamage(Collision2D collision)
    {
        Debug.Log("enemy2");
        // StartCoroutine(WaitAndAwake());
        // isHit = true;
    }

    //     IEnumerator WaitAndAwake()
    // {
    //     yield return new WaitForSeconds(10f);
    //     Debug.Log("Awake!");
    //     rbEnemy.velocity = new Vector2(speed, rbEnemy.velocity.y);
    //     isHit = false;
    // }
    // Start is called before the first frame update
    
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

   
}
