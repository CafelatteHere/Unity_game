using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float groundCheckDistance;

    private Rigidbody2D rbEnemy;
    [SerializeField] private LayerMask groundLayerMask;
    private float width;
    private float height;
    private float bottomRight;
    private float bottomLeft;
    private float bottomHeight;
    private bool isHit;

    // Start is called before the first frame update
    void Awake()
    {
        //Rigidbody2D rbEnemy1 makes it to be a new var 
        rbEnemy = GetComponent<Rigidbody2D>();
        width = GetComponent<Renderer>().bounds.size.x;
        height = GetComponent<Renderer>().bounds.size.y;
        //rbEnemy.transform.position = startPoint;
    }

    // Update is called once per frame
    void Update()
    {
        bottomRight = transform.position.x + width / 2;
        bottomLeft = transform.position.x - width / 2;
        bottomHeight = transform.position.y - height / 2;

        rbEnemy.velocity = new Vector2(speed, rbEnemy.velocity.y);
        if (checkGroundRight() == false)
        {
            speed = Mathf.Abs(speed) * -1;
            //rbEnemy.velocity = new Vector2(-1, rbEnemy.velocity.y);
        } else if (checkGroundLeft() == false)
        {
            speed = Mathf.Abs(speed);
            ///rbEnemy.velocity = new Vector2(1, rbEnemy.velocity.y);
            ///OnTriggerEnter2D(Collider2D collision)
        } else if (isHit == true)
        {
            rbEnemy.velocity = new Vector2(0, rbEnemy.velocity.y);

            /// StartCoroutine(WaitAndAwake());
            /// isHit = false;
            Debug.Log("10f");
          
        }

    }

    private bool checkGroundLeft()
    {
        Color color = Color.green;
        float duration = 0.7f;

        RaycastHit2D onGroundLeft = Physics2D.Raycast(new Vector3(bottomLeft, transform.position.y - groundCheckDistance, 0), Vector2.down, duration, groundLayerMask);

        if (onGroundLeft.collider != null)
        {
            Debug.Log("onGroundLeft.collider != null");
            color = Color.green;
        }
        else
        {
            Debug.Log("onGroundLeft.collider = null");
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
            Debug.Log("onGroundLeft.collider != null");
            color = Color.green;
        }
        else
        {
            Debug.Log("onGroundLeft.collider = null");
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

        private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision!");
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("collision on layer 8!");
            rbEnemy.velocity = new Vector2(0, 0);
            Debug.Log("velocity: " + rbEnemy.velocity);
            StartCoroutine(WaitAndAwake());
            rbEnemy.velocity = new Vector2(speed, rbEnemy.velocity.y);
            isHit = true;
        }
    }

    IEnumerator WaitAndAwake()
    {
        yield return new WaitForSeconds(30f);
        Debug.Log("Awake!");
        rbEnemy.velocity = new Vector2(speed, rbEnemy.velocity.y);
        isHit = false;
    }
}

