using UnityEngine;

public class throwObjects : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private StoneMovement objectToThrow;


    [Header("Actions & Settings")]
    [SerializeField] private int totalThrows;
    private KeyCode throwKey = KeyCode.T;
    private KeyCode throwKey = KeyCode.Keypad5;
    private CharacterMovements player;
    bool isGameOver;

    private void Awake()
    {
        //var characterMovements = FindAnyObjectByType<CharacterMovements>();
        //characterMovements.direction = CharacterMovements.direction;
        //because those two scripts are attchd to same GameObject Player
        player = GetComponent<CharacterMovements>();
    }


    void Update()
    {
        if (Input.GetKeyDown(throwKey) && totalThrows > 0)
        {
            Throw(objectToThrow); ;
        }

        if (Input.GetKeyDown(throwKey2) && totalThrows > 0)
        {
            Throw();
        }

    }
    private void OnEnable()
    {
        GameController.GameEnd += GameStateCheck;
    }

    private void OnDisable()
    {
        GameController.GameEnd -= GameStateCheck;
    }

    private void GameStateCheck()
    {
        isGameOver = true;
    }

    private void Throw<T>(T obj) where T: UnityEngine.Object, IThrowable
    {
        if (!isGameOver)
        {
            obj = Instantiate(obj, spawnPoint.position, objectToThrow.transform.rotation);
            var direction = new Vector2(player.currentPlayerDirection, 1);

            obj.Launch(direction);
            totalThrows--;
        }
       
    }
}
