using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Move : MonoBehaviour
{
    //TODO Make enemies not to collide with each other
    [SerializeField] private Rigidbody2D rbEnemy1;
    [SerializeField] private float speed;
    [SerializeField] private float timer;

    // Start is called before the first frame update
    void Awake()
    {
        rbEnemy1 = GetComponent<Rigidbody2D>();
        speed = 3;
        rbEnemy1.transform.position = new Vector2(7.4f, -2.3f);
        timer = 0.0f;
        rbEnemy1.velocity = new Vector2(-speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        if (timer > 4.9f && rbEnemy1.velocity[0] < 0)
        {
            rbEnemy1.velocity = new Vector2(speed, 0);
            timer = 0.0f;
        }

        if (timer > 4.9f && rbEnemy1.velocity[0] > 0)
        {
            rbEnemy1.velocity = new Vector2(-speed, 0);
            timer = 0.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Debug.Log("collision!");
            rbEnemy1.velocity = new Vector2(0, 0);
            Debug.Log("awake!");
        }
    }

    IEnumerator WaitAndAwake()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Awake!");
    }
}