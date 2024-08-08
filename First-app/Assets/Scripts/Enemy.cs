using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyIntEvent : UnityEvent<int>
{
}

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] public float speed;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private int damage;
    [SerializeField] private LayerMask groundLayerMask;

    protected bool isHit;
    protected bool isThrownBack;
    protected float bottomLeft;
    protected float bottomRight;

    private bool canMove;
    private bool isGameOver;
    private float width;
    
    public Rigidbody2D rbEnemy;
    public static event Action<int> LiveCountDecrease;


    void Awake()
    {
        //Rigidbody2D rbEnemy1 makes it to be a new var
        ///better to use box collider
        rbEnemy = GetComponent<Rigidbody2D>();
        width = GetComponent<Renderer>().bounds.size.x;
       //rbEnemy.transform.position = startPoint;
    }

    protected virtual void Start()
    {
        isHit = false;
        canMove = true;
        rbEnemy.velocity = new Vector2(speed, rbEnemy.velocity.y)* Time.deltaTime;
    }

    void FixedUpdate()
    {
        bottomRight = transform.position.x + width / 2;
        bottomLeft = transform.position.x - width / 2;

        if (isHit) {
            isHit = false;
            canMove = false;
            if (!isThrownBack) {
                rbEnemy.velocity = Vector2.zero;
            }
            
            StartCoroutine(WaitAndAwake());
        } 
        else if (canMove && !isGameOver) {
            //ßrbEnemy.velocity = new Vector2(speed, rbEnemy.velocity.y) * Time.deltaTime;
            if (checkGroundRight(bottomRight) == false)
            {
                speed = Mathf.Abs(speed) * -1;
            }

            else if (checkGroundLeft(bottomLeft) ==  false)
            {
                speed = Mathf.Abs(speed);
            }
            rbEnemy.velocity = new Vector2(speed, rbEnemy.velocity.y) * Time.deltaTime;
        }
    }

// can use only "abstract" (absolutly nothing inside the abstract function) or "virtual" (some code can be inside) for the function that is allowed to be overwritten
// if trying to make protected this function (public in interface), the is an error "cannot change access modifiers when overriding 'protected' inherited member 'Enemy.TakeDamage(Vector2)'"

    public virtual void TakeDamage(Vector2 direction) 
    {
        isHit = true;
    }

    private bool checkGroundLeft(float bottomLeft)
    {
        return checkGround(bottomLeft);
    }

    private bool checkGroundRight(float bottomRight)
    {
        return checkGround(bottomRight);
    }
    private bool checkGround(float bottomPoint)
    {
        Color color = Color.green;
        float rayLength = 1.3f;

        RaycastHit2D onGround = Physics2D.Raycast(new Vector3(bottomPoint, transform.position.y - groundCheckDistance, 0), Vector2.down, rayLength, groundLayerMask);
        if (onGround.collider == null)
        {
            color = Color.red;
        }


        Debug.DrawRay(new Vector3(bottomPoint, transform.position.y - groundCheckDistance, 0), Vector2.down * rayLength, color);
        return onGround.collider != null;
    }

     void OnCollisionEnter2D(Collision2D collision)
     {
         if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
          {      
            LiveCountDecrease?.Invoke(damage);
         }
     }

    private void OnEnable()
    {
        GameController.GameEnd += OnGameOver;
    }

    private void OnDisable()
    {
        GameController.GameEnd -= OnGameOver;
    }

    private void OnGameOver()
    {
        canMove = false;
        isGameOver = true;
        Debug.Log(isGameOver + "game over");
    }

    IEnumerator WaitAndAwake()
    {
        yield return new WaitForSeconds(5f);
       // rbEnemy.velocity = Vector2.zero;
        Debug.Log("Awake!");
        isHit = false;
        rbEnemy.velocity = new Vector2(speed, rbEnemy.velocity.y);    
        canMove = true;
    }
}

