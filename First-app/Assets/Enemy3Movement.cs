using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Movement : MonoBehaviour, IDamageable
{
    [SerializeField] private Vector2 hitSpeed;    
    [SerializeField] private float speed;
    public bool isHit;
    private Vector2 direction;
    private Rigidbody2D rbEnemy;

    private StoneMovement stoneMovement;

    public void TakeDamage(Collision2D collision)
    {   
        stoneMovement = collision.gameObject.GetComponent<StoneMovement>();
        
        
        Debug.Log("collision at enemy3 script " + collision.gameObject.GetComponent<StoneMovement>());
        direction = stoneMovement.stoneDirection;
        Debug.Log("Direction obtained from stone: " + direction);
        //rbEnemy.velocity = new Vector2(0, 0);

       hitSpeed = new Vector2(3000, 3000); // Calculate the force to apply
        //Debug.Log("Applying force: " + appliedForce);
        
        rbEnemy.AddForce(hitSpeed, ForceMode2D.Impulse);
        
            //rbEnemy.AddForce(hitSpeed * -direction, ForceMode2D.Impulse);
         //   rbEnemy.AddForce(speed* -direction, ForceMode2D.Impulse);
           // StartCoroutine(WaitAndAwake());
        
    }

    
    // Start is called before the first frame update
    void Awake()
    {
        rbEnemy = GetComponent<Rigidbody2D>(); 
        isHit = GetComponent<Enemy>().isHit;
    }

    // Update is called once per frame
    void Update()
     {

    }
}