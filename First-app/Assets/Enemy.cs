using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float groundCheckDistance;
    public bool isHit;
    private Rigidbody2D rbEnemy;
    [SerializeField] private LayerMask groundLayerMask;
    private float width;
    private float height;
    private float bottomRight;
    private float bottomLeft;
    private Collider2D enemyCollider;


    void Awake()
    {
        //Rigidbody2D rbEnemy1 makes it to be a new var
        ///better to use box collider
        rbEnemy = GetComponent<Rigidbody2D>();
        width = GetComponent<Renderer>().bounds.size.x;
        height = GetComponent<Renderer>().bounds.size.y;

        enemyCollider = gameObject.GetComponent<Collider2D>();
        //rbEnemy.transform.position = startPoint;
    }

    private void Start()
    {
        isHit = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        bottomRight = transform.position.x + width / 2;
        bottomLeft = transform.position.x - width / 2;

        rbEnemy.velocity = new Vector2(speed, rbEnemy.velocity.y) * Time.deltaTime;
        if (checkGroundRight() == false)
        {
            speed = Mathf.Abs(speed) * -1;
        }

        else if (checkGroundLeft() == false)
        {
            speed = Mathf.Abs(speed);
        }
        else if (isHit == true)
        {
            rbEnemy.velocity = Vector2.zero;
            StartCoroutine(WaitAndAwake());
        }
                    Debug.Log("isHit: " + isHit);  

    }

    private bool checkGroundLeft()
    {
        Color color = Color.green;
        float duration = 0.7f;

        RaycastHit2D onGroundLeft = Physics2D.Raycast(new Vector3(bottomLeft, transform.position.y - groundCheckDistance, 0), Vector2.down, duration, groundLayerMask);

        if (onGroundLeft.collider != null)
        {
            color = Color.green;
        }
        else
        {
            color = Color.red;
        }


        Debug.DrawRay(new Vector3(bottomLeft, transform.position.y - groundCheckDistance, 0), Vector2.down * duration, color);
        // Debug.Log("left" + onGroundLeft.collider);

        return onGroundLeft.collider != null;
    }

    private bool checkGroundRight()
    {
        Color color = Color.green;
        float duration = 0.7f;

        RaycastHit2D onGroundRight = Physics2D.Raycast(new Vector3(bottomRight, transform.position.y - groundCheckDistance, 0), Vector2.down, duration, groundLayerMask);

        if (onGroundRight.collider != null)
        {
            color = Color.green;
        }
        else
        {
            color = Color.red;
        }

        Debug.DrawRay(new Vector3(bottomRight, transform.position.y - groundCheckDistance, 0), Vector2.down * duration, color);
        //Debug.Log("right" + onGroundRight.collider);

        return onGroundRight.collider != null;
    }

    //private void OnDrawGizmos()
    //{
    //    // Gizmos.DrawWireCube(transform.position - transform.up * groundCheckDistance, boxSize);
    //    Gizmos.DrawLine(new Vector3(bottomLeft, transform.position.y - groundCheckDistance, 0), new Vector3(bottomLeft, bottomHeight - groundCheckDistance, 0));
    //    Gizmos.DrawLine(new Vector3(bottomRight, transform.position.y - groundCheckDistance, 0), new Vector3(bottomRight, bottomHeight - groundCheckDistance, 0));
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = gameObject.GetComponent<IDamageable>();
        //IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable != null && collision.gameObject.GetComponent<StoneMovement>() != null)
        
        {
            Debug.Log("on collision is executed");
            isHit = true;
            damageable.TakeDamage(collision);
        }
    }

    IEnumerator WaitAndAwake()
    {
        yield return new WaitForSeconds(20f);
        Debug.Log("Awake!");
        isHit = false;
        rbEnemy.velocity = new Vector2(speed, rbEnemy.velocity.y);    
    }

}

