using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    //[SerializeField] private Rigidbody2D rbEnemy1;
    [SerializeField] private float speed;
    [SerializeField] private float flipTime = 4.9f;
    //TODO change startPoint for Enemy2;
    [SerializeField] private Vector2 startPoint = new Vector2(7.4f, -2.3f);
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float groundCheckDistance;

    private Rigidbody2D rbEnemy;
    private float timer = 0.0f;
    private bool isGrounded;
    private LayerMask groundLayer;

    // Start is called before the first frame update
    void Awake()
    {
        //Rigidbody2D rbEnemy1 makes it to be a new var 
        rbEnemy = GetComponent<Rigidbody2D>();
        Debug.Log(rbEnemy);
        rbEnemy.transform.position = startPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkGround() == null) {
            speed += -1;
        } 
        //timer = timer + Time.deltaTime;
        rbEnemy.velocity = new Vector2(speed, rbEnemy.velocity.y);
        
        //isGrounded = checkGround();
        //if (isGrounded == false)
        //{
        //    speed *= -1;
        //}
        //if (timer > flipTime)
        //{
        //    speed += -1;
        //    timer = 0;
        //}

        //if (timer > flipTime && rbEnemy.velocity.x <= 0)
        //{
        //    rbEnemy.velocity = new Vector2(speed, rbEnemy.velocity.y);
        //    timer = 0.0f;
        //}

        //if (timer > flipTime && rbEnemy.velocity.x > 0)
        //{
        //    rbEnemy.velocity = new Vector2(-speed, rbEnemy.velocity.y);
        //    timer = 0.0f;
        //}
    }

    private bool checkGround()
    {
        RaycastHit2D onGround1 = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        RaycastHit2D onGround2 = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        
        //if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        if (onGround1 == false || onGround2 == false)
        {
            Debug.Log("hitting ground");
           return onGround1.collider != null;
            
            

        } else
        {
            return onGround1.collider == null;
        }
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * groundCheckDistance, boxSize);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("collision!");
            rbEnemy.velocity = new Vector2(0, 0);
            StartCoroutine(WaitAndAwake());
            Debug.Log("awake!");
        }
    }

    IEnumerator WaitAndAwake()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Awake!");
    }
}