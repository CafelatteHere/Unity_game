using UnityEngine;

public class StoneMovement : MonoBehaviour
{
   
    [SerializeField] private Vector2 LaunchSpeed;
    public Enemy enemy;
    public Vector2 stoneDirection;

    private Rigidbody2D rb;
    private float destructionTime = 2f;
    
    void Start()
    {
        //Destroy(gameObject, 3f); - we can do it too, but not using it becase in separate function we can set up some effects too;
        //invoke - to call smth after some time;
        Invoke(nameof(DestroyStone), destructionTime);
    }

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
        GameObject collidedItem = collision.gameObject;

        Vector2 direction = new Vector2(Mathf.Sign(stoneDirection.x), 1);
        if (collision.gameObject.layer == LayerMask.NameToLayer("groundLayer"))
        {
            ///transfer to another layer
            gameObject.layer = LayerMask.NameToLayer("HitStone");
            
            return;          
        }
       
        var damageable = collision.gameObject.GetComponent<IDamageable>();

        if (damageable is not null) 
        {
            int points = 0;
            
            points = 10;
            if (collision.gameObject != collidedItem)
            {
                points += 10;
            } 
            
            int enemyDamage = 1;
            bool isKilled = false;
            damageable.TakeDamage(stoneDirection);
            if (collision.gameObject.GetComponent<Enemy>())
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.CalculateDamage(collision, enemyDamage, out points, out isKilled);
            }
            //GameController.UpdateScore(collision, points);
        }
        ///transfer to another layer;
        gameObject.layer = LayerMask.NameToLayer("HitStone");
    }
}
