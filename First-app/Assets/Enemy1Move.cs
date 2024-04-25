using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    //[SerializeField] private Rigidbody2D rbEnemy1;
    [SerializeField] private float speed = 3;
    [SerializeField] private float flipTime = 4.9f;
    [SerializeField] private Vector2 startPoint = new Vector2(7.4f, -2.3f);

    private Rigidbody2D rbEnemy1;
 
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Awake()
    {
        //Rigidbody2D rbEnemy1 makes it to be a new var 
        rbEnemy1 = GetComponent<Rigidbody2D>();
        Debug.Log(rbEnemy1);
        rbEnemy1.transform.position = startPoint;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        rbEnemy1.velocity = new Vector2(speed, rbEnemy1.velocity.y);

        if (timer > flipTime)
        {
            speed += -1;
            timer = 0;
        }

        //if (timer > flipTime && rbEnemy1.velocity.x <= 0)
        //{
        //    rbEnemy1.velocity = new Vector2(speed, rbEnemy1.velocity.y);
        //    timer = 0.0f;
        //}

        //if (timer > flipTime && rbEnemy1.velocity.x > 0)
        //{
        //    rbEnemy1.velocity = new Vector2(-speed, rbEnemy1.velocity.y);
        //    timer = 0.0f;
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("collision!");
            rbEnemy1.velocity = new Vector2(0, 0);
            StartCoroutine(WaitAndAwake());
            Debug.Log("awake!");
        }
    }

    IEnumerator WaitAndAwake()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Awake!");
    }
}