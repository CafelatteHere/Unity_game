using UnityEngine;


public class CharacterMovements : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] float jumpTime;
    [SerializeField] float jumpTimeCounter;
    [SerializeField] float horizontalDirection;

    private bool isFacingRight;
    private bool isGrounded;
    private bool isJumping;
    private bool isAlive;

    //we cat get it publicly but set only privately only in this script
    public int currentPlayerDirection { get; private set; } = 1;
    public LayerMask groundLayerMask;
   

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isAlive = true;
    }

    void Update()
    {
        if (isAlive)
        {
            horizontalDirection = Input.GetAxis("Horizontal");
        }
        else
        {
            horizontalDirection = 0;
        }
        
      
        ShouldIFlip(horizontalDirection);
        rb.velocity = new Vector2(horizontalDirection * speed, rb.velocity.y); 
        
      
         if (isGrounded  && (Input.GetKeyDown(KeyCode.Space) )) 
        {
            rb.velocity = new Vector2 (horizontalDirection, jumpPower);
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping && (jumpTimeCounter > 0)) {
            rb.velocity = new Vector2 (horizontalDirection, jumpPower);
            jumpTimeCounter = jumpTimeCounter  - Time.deltaTime;     
        } 

        if (Input.GetKeyUp(KeyCode.Space)) {
            isJumping = false;
        }
        
    }

    void ShouldIFlip(float horizontalDirection) {

        if (horizontalDirection > 0 && currentPlayerDirection < 0)
        {
            Flip();
        }
        else
        {
            if (rb.velocity.x == 0 && isFacingRight == true)
            {
                
                currentPlayerDirection = 1;
            } 
            else if (horizontalDirection < 0 && currentPlayerDirection > 0)
            {
                Flip();
            }
            else if  (rb.velocity.x == 0 && isFacingRight == false)
            {
               currentPlayerDirection = -1;                
            }
        }
    }

    void Flip () {
        transform.Rotate(0f, 180f, 0f);
        currentPlayerDirection *= - 1;
        isFacingRight = !isFacingRight;
    }
void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.layer == LayerMask.NameToLayer("groundLayer"))
        {
        isGrounded = true;
        isJumping = false;
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
        isAlive = false;
        speed = 0;
        jumpPower = 0;
    }

void OnCollisionExit2D(Collision2D collision) {
    if (collision.gameObject.layer == LayerMask.NameToLayer("groundLayer"))
        {
        isGrounded = false;
        }
    }
}
