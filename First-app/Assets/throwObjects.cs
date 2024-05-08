using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwObjects : MonoBehaviour
{

    //[SerializeField] private Rigidbody2D rb;
    [Header("Objects")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private StoneMovement objectToThrow;


    [Header("Actions & Settings")]
    [SerializeField] private int totalThrows;
    private KeyCode throwKey = KeyCode.T;
    private CharacterMovements player;
    private StoneMovement stone;

    //private var direction; - to check direction of character.

    private void Awake()
    {
        //var characterMovements = FindAnyObjectByType<CharacterMovements>();
        //characterMovements.direction = CharacterMovements.direction;
        //because those two scripts are attchd to same GameObject Player
        player = GetComponent<CharacterMovements>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(throwKey) && totalThrows > 0)
        {
            Throw ();
        }

    }

    private void Throw()
    {

        StoneMovement obj = Instantiate(objectToThrow, spawnPoint.position, objectToThrow.transform.rotation);
        // Rigidbody2D objRb = obj.GetComponent<Rigidbody2D>();
        var direction =new Vector2(player.currentPlayerDirection, 0);
        Debug.Log("currentPlayerDirection= " + player.currentPlayerDirection);
        stone.Launch(direction);
        totalThrows--;
        
    }

        //read horiz inpu and vertical from oter file
        //if (characterRb.velocity.x >= 0)
        //{
        //    objRb.AddForce((Vector2.up + Vector2.right) * throwForce, ForceMode2D.Impulse);
        //}
        //else if (characterRb.velocity.x < 0)
        //{
        //    objRb.AddForce((Vector2.up + Vector2.left) * throwForce, ForceMode2D.Impulse);
        //}
       // objRb.AddForce((Vector2.up + (3 * Vector2.right)) * throwForce, ForceMode2D.Impulse);
      
 
}
