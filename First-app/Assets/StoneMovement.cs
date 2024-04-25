using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Vector2 LaunchSpeed = new Vector2(200, 200);
    private float destructionTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Destroy(gameObject, 3f); - we can do it too, but not using it becase in separate function we can set up some effects too;
        //invoke - to call smth after some time;
        Invoke(nameof(DestroyStone), destructionTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch(Vector2 direction)
    {
        rb.AddForce(LaunchSpeed, ForceMode2D.Impulse);
    }

    private void DestroyStone()
    {
        Destroy(gameObject);
    }
}
