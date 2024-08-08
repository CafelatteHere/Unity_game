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
    protected bool isHit;
    protected bool isThrownBack;
    public Rigidbody2D rbEnemy;
    [SerializeField] private LayerMask groundLayerMask;
    private float width;
    private float height;
    private float bottomRight;
    protected float bottomLeft;
    private Collider2D enemyCollider;
    GameController gameController;
    public static event Action<int> LiveCountDecrease;

    private bool canMove;
    private bool isGameOver;


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

    protected virtual void Start()
    {
        isHit = false;
        canMove = true;
        rbEnemy.velocity = new Vector2(speed, rbEnemy.velocity.y)* Time.deltaTime;
        gameController = FindObjectOfType<GameController>();
   
    }
    // Update is called once per frame
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
            if (checkGroundRight() == false)
            {
                speed = Mathf.Abs(speed) * -1;
            }

            else if (checkGroundLeft() ==  false)
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

    private bool checkGroundLeft()
    {
        Color color = Color.green;
        float rayLength = 1.3f;

        RaycastHit2D onGroundLeft = Physics2D.Raycast(new Vector3(bottomLeft, transform.position.y - groundCheckDistance, 0), Vector2.down, rayLength, groundLayerMask);
        if (onGroundLeft.collider != null)
        {
            color = Color.green;
        }
        else
        {
            color = Color.red;
        }


        Debug.DrawRay(new Vector3(bottomLeft, transform.position.y - groundCheckDistance, 0), Vector2.down * rayLength, color);
        return onGroundLeft.collider != null;
    }

    private bool checkGroundRight()
    {
        Color color = Color.green;
        float rayLength = 1.3f;

        RaycastHit2D onGroundRight = Physics2D.Raycast(new Vector3(bottomRight, transform.position.y - groundCheckDistance, 0), Vector2.down, rayLength, groundLayerMask);

        if (onGroundRight.collider != null)
        {
            color = Color.green;
        }
        else
        {
            color = Color.red;
        }

        Debug.DrawRay(new Vector3(bottomRight, transform.position.y - groundCheckDistance, 0), Vector2.down * rayLength, color);

        return onGroundRight.collider != null;
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
        Debug.Log("Started waiting!");
        yield return new WaitForSeconds(5f);
       // rbEnemy.velocity = Vector2.zero;
        Debug.Log("Awake!");
        isHit = false;
        rbEnemy.velocity = new Vector2(speed, rbEnemy.velocity.y);    
        canMove = true;
    }

}

