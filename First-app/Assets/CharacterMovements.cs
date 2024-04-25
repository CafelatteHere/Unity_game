using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 direction;
    //we cat get it publicly but set only privately only in this script
    public int currentPlayerDirection { get; private set; } = 1;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 120;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalDirection = Input.GetAxisRaw("Horizontal");
        float verticalDirection = Input.GetAxisRaw("Vertical");

        if (horizontalDirection > 0)
        {
            currentPlayerDirection = 1;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            currentPlayerDirection = -1;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        direction = new Vector2(horizontalDirection, verticalDirection);
    }

    private void FixedUpdate()
    {
        //TODO: make the character jump by one Up key press without need to press and hold the key
        rb.velocity = new Vector2(direction.x * speed * Time.deltaTime, direction.y * (speed * 2) * Time.deltaTime);
    }

}
