using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform playerPaddle;
    public Transform enemyPaddle;

    public BallController ballController;

    public int playerScore = 0;
    public int enemyScore = 0;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;

    public int winPoints = 3;

    public GameObject screenEndGame;

    public TextMeshProUGUI textEndGame;

    public float timeInEndGameScreen;

    void Start()
    {
        ResetGame();
    }
    public void ResetGame()
    {
        // Define as posições iniciais das raquetes
        playerPaddle.position = new Vector3(7f, 0f, 0f);
        enemyPaddle.position = new Vector3(-7f, 0f, 0f);

        ballController.ResetBall();


        playerScore = 0;
        enemyScore = 0;

        textPointsPlayer.text = playerScore.ToString();
        textPointsEnemy.text = playerScore.ToString();

        screenEndGame.SetActive(false);
    }

    public void ScorePlayer()
    {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();
        CheckWin();
    }

    public void ScoreEnemy()
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if (playerScore == winPoints || enemyScore == winPoints)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SaveController.Instance.GetName(playerScore > enemyScore);
        textEndGame.text = "Victory: " + winner;
        SaveController.Instance.SaveWinner(winner);

        Invoke("LoadMenu", timeInEndGameScreen);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
