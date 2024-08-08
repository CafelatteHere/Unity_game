using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesText;
    GameController gameController;
    bool isGameOver;

    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>(); 
        livesText.text = "Health: " + gameController.currentHealth;
    }


    private void OnEnable()
    {
        Enemy.LiveCountDecrease += UpdateLivesCountText;
        GameController.GameEnd += OnGameOver;
    }

    private void OnDisable()
    {
        Enemy.LiveCountDecrease -= UpdateLivesCountText;
        GameController.GameEnd -= OnGameOver;
    }

    public void OnGameOver()
    {
        isGameOver = true;
        livesText.text = "Game over!\n Health: " + gameController.currentHealth;
    }

    public void UpdateLivesCountText(int damage){
        if (!isGameOver)
        {
            livesText.text = "Health: " + gameController.currentHealth;
            Debug.Log("UpdateLivesCountText updated the text");
        } 
    }
}
