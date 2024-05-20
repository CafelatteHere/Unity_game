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
    private bool isHit; 

    // Start is called before the first frame update
    void Awake()
    {
        //Rigidbody2D rbEnemy1 makes it to be a new var
        ///better to use box collider
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

        rbEnemy.velocity = new Vector2(speed, rbEnemy.velocity.y);
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
            rbEnemy.velocity = new Vector2(0, rbEnemy.velocity.y);

            /// StartCoroutine(WaitAndAwake());
            /// isHit = false;
          
        }

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

    private void OnCollisionEnter2D (Collision2D collision)
    {
        //better to use tags instead of layers if (collision CompareTage("Stone"))
        Debug.Log(rbEnemy);
        Debug.Log(gameObject.layer);
        if (collision.gameObject.layer == 8 && gameObject.layer == 6)
        {
            StartCoroutine(HandleEnemyState());
            isHit = true;
            //Destroy(gameObject);
        }
        else if (collision.gameObject.layer == 8 && gameObject.layer == 7)
        {
            StartCoroutine(WaitAndAwake());
            isHit = true;
        }
        else if (collision.gameObject.layer == 8 && gameObject.layer == 14)
        {
            StartCoroutine(WaitAndAwake());
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

    public void TakeDamage(Collision2D collision)
    {
        Debug.Log(rbEnemy);
        Debug.Log(gameObject.layer);
        if (collision.gameObject.layer == 8)
        {
            StartCoroutine(WaitAndAwake());
            isHit = true;
        }
    }

  
    IEnumerator HandleEnemyState()
    {

        var timer = 3;
        while (timer > 0)
        {
            Debug.Log(timer);
            DeactivateEnemy();
            yield return new WaitForSecondsRealtime(1);
            ActivateEnemy();
            yield return new WaitForSecondsRealtime(1);
            timer--;
        }
    }
    public void ActivateEnemy()
    {
        Debug.Log("activating");
        Debug.Log(gameObject);
        gameObject.SetActive(true);
    }

    public void DeactivateEnemy()
    {
        Debug.Log("deactivating");
        gameObject.SetActive(false);
    }
}

