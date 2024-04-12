using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Move : MonoBehaviour
{

    private Rigidbody2D rbEnemy2;
    float speed = 50;

    public GameObject LeftEdge;
    public GameObject RightEdge;
    private Transform currentPoint;


    Vector2 move;
    // Start is called before the first frame update
    void Start()
    {
        rbEnemy2 = GetComponent<Rigidbody2D>();
        currentPoint = LeftEdge.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;

        if (currentPoint == LeftEdge.transform)
        {
            rbEnemy2.velocity = new Vector2(speed, 0);
        }

        else
        {
            rbEnemy2.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == LeftEdge.transform)
        {
            currentPoint = RightEdge.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == RightEdge.transform)
        {
            currentPoint = LeftEdge.transform;
        }
        //move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //rbEnemy2.velocity = new Vector2(move.x * speed * Time.deltaTime, move.y * (speed * 2) * Time.deltaTime);
    }
}
