using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Move : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbEnemy2;
    [SerializeField] private float speed;

    //TODO: to make it going by timer, not by edge points
    [SerializeField] private GameObject LeftEdge;
    [SerializeField] private GameObject RightEdge;
    private Transform currentPoint;


    private Vector2 move;
    // Start is called before the first frame update
    void Awake()
    {
        rbEnemy2 = GetComponent<Rigidbody2D>();
        speed = 5;
        rbEnemy2.transform.position = LeftEdge.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (rbEnemy2.transform.position.x < LeftEdge.transform.position.x)
        {
            rbEnemy2.velocity = new Vector2(speed, 0); 
        }

        if (rbEnemy2.transform.position.x > RightEdge.transform.position.x)
        {
            rbEnemy2.velocity = new Vector2(-speed, 0);
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
