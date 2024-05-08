using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float flipTime = 4.9f;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float groundCheckDistance;

    private Rigidbody2D rbEnemy;
    private float timer = 0.0f;
    private bool isGrounded;
    [SerializeField] private LayerMask groundLayer=9;
    private float width;
    private float height;
    private float bottomRight;
    private float bottomLeft;
    private float bottomHeight;

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

        //Debug.Log("checkGroundLeft()" + checkGroundLeft());
        Debug.Log("checkGroundRight()" + checkGroundRight());
        rbEnemy.velocity = new Vector2(speed, rbEnemy.velocity.y);
        if (checkGroundRight() == false)
        {
            rbEnemy.velocity = new Vector2(-1, rbEnemy.velocity.y);
        }
        //rbEnemy.velocity = new Vector2(speed, rbEnemy.velocity.y);
        //if (checkGroundLeft()) {
        //    Debug.Log("checkGroundLeft()");
        //    rbEnemy.velocity = new Vector2(1, rbEnemy.velocity.y);
        //    Debug.Log(speed);
        //} else if (checkGroundRight() == false)
        //{
        //    Debug.Log("checkGroundRight() == false");
        //    rbEnemy.velocity = new Vector2(-1, rbEnemy.velocity.y);
        //    Debug.Log(speed);
        //}




        //timer = timer + Time.deltaTime;


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

    //private bool checkGroundLeft()
    //{
    //    RaycastHit2D onGroundLeft = Physics2D.Raycast(new Vector3(bottomLeft, transform.position.y - groundCheckDistance, 0), new Vector3(bottomLeft, bottomHeight - groundCheckDistance, 0), groundLayer);
    //    Color rayColor;
    //    rayColor = Color.green;
    //    Debug.Log("onGroundLeft.collider" + onGroundLeft.collider);
    //    if (onGroundLeft.collider != null)
    //    {
    //        Debug.Log("onGroundLeft.collider != null");
    //        rayColor = Color.green;
    //    } else
    //    {
    //        Debug.Log("onGroundLeft.collider = null");
    //        rayColor = Color.red;
    //    }

    //    return onGroundLeft.collider != null;
    
      
    //}

    private bool checkGroundRight()
    {
        Color color = Color.green;
        float duration = 0.3f;
        bool depthTest = true;
        int layerMask = groundLayer;
        RaycastHit2D onGroundRight = Physics2D.Raycast(new Vector3(bottomRight, transform.position.y - groundCheckDistance, 0), Vector2.down, duration, layerMask);
        Debug.DrawRay(new Vector3(bottomRight, transform.position.y - groundCheckDistance, 0), Vector2.down, color, duration, depthTest);
        Debug.Log(onGroundRight.collider);
        //Debug.Log(onGroundRight.collider.gameObject);
        return onGroundRight.collider != null;
    }

    private void OnDrawGizmos()
    {
        // draw the ray on line 64 here;
        // check the bottom line, add color to beams.
        // add left and right bottom point for raycasts;
        // Gizmos.DrawWireCube(transform.position - transform.up * groundCheckDistance, boxSize);
        Gizmos.DrawLine(new Vector3(bottomLeft, transform.position.y - groundCheckDistance, 0), new Vector3(bottomLeft, bottomHeight - groundCheckDistance, 0));
        Gizmos.DrawLine(new Vector3(bottomRight, transform.position.y - groundCheckDistance, 0), new Vector3(bottomRight, bottomHeight - groundCheckDistance, 0));
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

