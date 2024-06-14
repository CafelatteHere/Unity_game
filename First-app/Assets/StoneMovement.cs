using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMovement : MonoBehaviour
{
   
    [SerializeField] private Vector2 LaunchSpeed;
    public Enemy enemy;
    public Vector2 stoneDirection;

    private Rigidbody2D rb;
    private float destructionTime = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 3f); - we can do it too, but not using it becase in separate function we can set up some effects too;
        //invoke - to call smth after some time;
        Invoke(nameof(DestroyStone), destructionTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 0.5f);
    }

    public void Launch(Vector2 direction)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(LaunchSpeed * direction, ForceMode2D.Impulse);
        stoneDirection = direction;
    }

    private void DestroyStone()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        Vector2 direction = new Vector2(Mathf.Sign(stoneDirection.x), 1);
        if (collision.gameObject.layer == LayerMask.NameToLayer("groundLayer"))
        {
            ///transfer to another layer
            gameObject.layer = LayerMask.NameToLayer("HitStone");
            
            return;          
        }
        var damageable = collision.gameObject.GetComponent<IDamageable>();
        enemy.isHit = true;
        damageable.TakeDamage(stoneDirection);
        ///transfer to another layer;
        gameObject.layer = LayerMask.NameToLayer("HitStone");
    }
}
