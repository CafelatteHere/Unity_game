using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] float jumpTime;
    [SerializeField] float jumpTimeCounter;
    [SerializeField] float horizontalDirection;
      //we cat get it publicly but set only privately only in this script

    private bool isFacingRight;
    private bool isGrounded;
    private bool isJumping;
    private float  verticalDirection;
    
    public int currentPlayerDirection { get; private set; } = 1;
    public LayerMask groundLayerMask;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalDirection = Input.GetAxis("Horizontal");
        //verticalDirection = Input.GetAxisRaw("Vertical");

        ShouldIFlip(horizontalDirection);
        //QQ2 why rb.velocity.y * gives immediate jump?
        rb.velocity = new Vector2(horizontalDirection * speed, rb.velocity.y); 
        
        //TODO: make the character jump by one Up key press without need to press and hold the key
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
            //QQ1 why order matters? Why is isFacingRight = true; not working?
            Flip();
            // isFacingRight = true;
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
            //    Flip();   
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
    if (collision.gameObject.layer == LayerMask.NameToLayer("groundLayer")) {
        isGrounded = true;
        isJumping = false;
    }
}

void OnCollisionExit2D(Collision2D collision) {
    if (collision.gameObject.layer == LayerMask.NameToLayer("groundLayer")) {
        isGrounded = false;
    }
}
  

}
