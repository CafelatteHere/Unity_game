using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Move : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbEnemy2;
    [SerializeField] private float speed;
    [SerializeField] private float timer;

    // Start is called before the first frame update
    void Awake()
    {
        rbEnemy2 = GetComponent<Rigidbody2D>();
        speed = 3;
        rbEnemy2.transform.position = new Vector2(-7.45f, -2.17f);
        timer = 0.0f;
        rbEnemy2.velocity = new Vector2(speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        if (timer > 5f && rbEnemy2.velocity[0] < 0)
        {
            rbEnemy2.velocity = new Vector2(speed, 0);
            timer = 0.0f;            
        }

        if (timer > 5f && rbEnemy2.velocity[0] > 0)
        {
            rbEnemy2.velocity = new Vector2(-speed, 0);
            timer = 0.0f;
        }
        //Vector2 point = currentPoint.position - transform.position;

        //if (currentPoint == LeftEdge.transform)
        //{
        //    rbEnemy2.velocity = new Vector2(speed, 0);
        //}

        //else
        //{
        //    rbEnemy2.velocity = new Vector2(-speed, 0);
        //}

        //if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == LeftEdge.transform)
        //{
        //    currentPoint = RightEdge.transform;
        //}

        //if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == RightEdge.transform)
        //{
        //    currentPoint = LeftEdge.transform;
        //}
        //move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //rbEnemy2.velocity = new Vector2(move.x * speed * Time.deltaTime, move.y * (speed * 2) * Time.deltaTime);
    }
}
