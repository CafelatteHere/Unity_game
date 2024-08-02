using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesText;
    CharacterStates gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<CharacterStates>();
        Debug.Log(gameController);

        livesText.text = "Lives: " + gameController.livesCount;
        Debug.Log(livesText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLivesCountText(){
        livesText.text = "Lives: " + gameController.livesCount;
    }
}
