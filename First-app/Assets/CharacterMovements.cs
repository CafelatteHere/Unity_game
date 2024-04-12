using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 direction;

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

        direction = new Vector2(horizontalDirection, verticalDirection);
    }

    private void FixedUpdate()
    {
        //TODO: make the character jump by one Up key press without need to press and hold the key
        rb.velocity = new Vector2(direction.x * speed * Time.deltaTime, direction.y * (speed * 2) * Time.deltaTime);
    }

    //    public void Move(Transform transform)
    //    {

    //       //if (Input.GetKeyDown(KeyCode.LeftArrow) && CharacterRigidBody.position.x >= -9.5)
    //       // {
    //       //     CharacterRigidBody.velocity = Vector2.left * 7;
    //       // } else if (Input.GetKeyDown(KeyCode.LeftArrow) && CharacterRigidBody.position.x >= -9.5)
    //       // {
    //       //     CharacterRigidBody.velocity = Vector2.zero;
    //       //     //CharacterRigidBody.position.x = -9.5;
    //       // }

    //       // if (Input.GetKeyDown(KeyCode.RightArrow) && CharacterRigidBody.position.x <= -10.5)
    //       // {
    //       //     CharacterRigidBody.velocity = Vector2.right * 7;
    //       // }
    //       // else if (Input.GetKeyDown(KeyCode.RightArrow) && CharacterRigidBody.position.x <= -10.5)
    //       // {
    //       //     CharacterRigidBody.velocity = Vector2.zero;
    //       // }

    //       // if (Input.GetKeyDown(KeyCode.Space))
    //       // {
    //       //     CharacterRigidBody.velocity = new Vector2(CharacterRigidBody.velocity.y);
    //       // }

    //    }


}
