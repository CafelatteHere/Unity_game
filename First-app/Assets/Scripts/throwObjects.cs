using UnityEngine;

public class throwObjects : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private StoneMovement objectToThrow;


    [Header("Actions & Settings")]
    [SerializeField] private int totalThrows;
    private KeyCode throwKey = KeyCode.T;
    private CharacterMovements player;
    private Rigidbody2D rb;

    private void Awake()
    {
        //var characterMovements = FindAnyObjectByType<CharacterMovements>();
        //characterMovements.direction = CharacterMovements.direction;
        //because those two scripts are attchd to same GameObject Player
        player = GetComponent<CharacterMovements>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(throwKey) && totalThrows > 0)
        {
            Throw ();
        }

    }

    private void Throw()
    {
        StoneMovement stone = Instantiate(objectToThrow, spawnPoint.position, objectToThrow.transform.rotation);
        var direction =new Vector2(player.currentPlayerDirection, 1);
       
        stone.Launch(direction);
        totalThrows--;       
    }
}
