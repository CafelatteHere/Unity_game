using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    bool isGameOver;


   

    void Start()
    {
       // gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        
        livesText.text = "Health: " + GameController.Instance.currentHealth;
        scoreText.text = "Score: 0" + GameController.Instance.score;
    }


    private void OnEnable()
    {
        Enemy.LiveCountDecrease += UpdateLivesCountText;
        GameController.GameEnd += OnGameOver;
        GameController.ScoreCountIncrease += OnScoreUpdate;
    }

    private void OnDisable()
    {
        Enemy.LiveCountDecrease -= UpdateLivesCountText;
        GameController.GameEnd -= OnGameOver;
        GameController.ScoreCountIncrease -= OnScoreUpdate;
    }

    public void OnGameOver()
    {
        isGameOver = true;
        livesText.text = "Game over!\n Health: " + GameController.Instance.currentHealth;
    }

    public void UpdateLivesCountText(int damage){
        if (!isGameOver)
        {
            livesText.text = "Health: " + GameController.Instance.currentHealth;
        } 
    }

    public void OnScoreUpdate(float score)
    {
        scoreText.text = "Score: " + score;
    }
} 
