using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwObjects : MonoBehaviour
{

    //[SerializeField] private Rigidbody2D rb;
    [Header("Objects")]
    [SerializeField] private Transform character;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject objectToThrow;


    [Header("Actions & Settings")]
    [SerializeField] private int totalThrows;
    [SerializeField] private float throwForce;
    ////[SerializeField] private int throwUpwardForce;
    [SerializeField] private float timer;

    private Rigidbody2D characterRb;
    private KeyCode throwKey = KeyCode.T;
    private List<GameObject> thrownObjects;

    private void Awake()
    {
        throwForce = 10f;
    }
    // Start is called before the first frame update
    void Start()
    {
       Rigidbody2D characterRb = character.GetComponent<Rigidbody2D>();
        Debug.Log(character);
        Debug.Log(characterRb);
       timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(throwKey) && totalThrows > 0)
        {
            Throw ();
        }
        for (int i = 0; i < thrownObjects.Count; i++)
        {
            if (thrownObjects.Count > 0)
            {
                var currentPosition = thrownObjects[i].transform.position;
                if (timer >= 5f && thrownObjects[i].transform.position == currentPosition)
                    Destroy(thrownObjects[i]);
                timer = 0.0f;
            }
        }

    }

    private void Throw()
    {
        GameObject obj = Instantiate(objectToThrow, spawnPoint.position, objectToThrow.transform.rotation);
        Rigidbody2D objRb = obj.GetComponent<Rigidbody2D>();

        //if (characterRb.velocity.x >= 0)
        //{
        //    objRb.AddForce((Vector2.up + Vector2.right) * throwForce, ForceMode2D.Impulse);
        //}
        //else if (characterRb.velocity.x < 0)
        //{
        //    objRb.AddForce((Vector2.up + Vector2.left) * throwForce, ForceMode2D.Impulse);
        //}
        objRb.AddForce((Vector2.up + (2 * Vector2.right)) * throwForce, ForceMode2D.Impulse);
        Debug.Log(Vector2.right);
        
        totalThrows--;
        timer = timer + Time.deltaTime;
        thrownObjects.Add(obj);
        Debug.Log(thrownObjects);
        if (timer > 5f)
        {
            Destroy(thrownObjects[-1]);
        }
    }

 
}
