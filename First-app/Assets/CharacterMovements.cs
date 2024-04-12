using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed = 120;
    Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        //Move(transform);
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(move.x * speed * Time.deltaTime, move.y * (speed * 2) * Time.deltaTime);
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
