using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbEnemy2;
    [SerializeField] private float speed;
    [SerializeField] private float timer;

    // Start is called before the first frame update
    void Awake()
    {
        rbEnemy2 = GetComponent<Rigidbody2D>();
        speed = 3;
        rbEnemy2.transform.position = new Vector2(7.4f, -2.3f);
        timer = 0.0f;
        rbEnemy2.velocity = new Vector2(-speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        if (timer > 4.9f && rbEnemy2.velocity[0] < 0)
        {
            rbEnemy2.velocity = new Vector2(speed, 0);
            timer = 0.0f;
        }

        if (timer > 4.9f && rbEnemy2.velocity[0] > 0)
        {
            rbEnemy2.velocity = new Vector2(-speed, 0);
            timer = 0.0f;
        }
    }
}