using UnityEngine;
using UnityEngine.UI;
using System.Collections;     

public class GameManager : MonoBehaviour
{
    private int score = 0;
    public Text scoreText;      // Drag your UI Text here in Inspector
    public Text messageText;    // Drag your UI Text here for Win/Game Over messages

    public int coinsToWin = 10;

    void Start()
    {
        scoreText.text = "Score: 0";
        messageText.text = "";
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;

        if (score >= coinsToWin)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        StartCoroutine(ShowMessageAndPause("You Win!"));
    }

    public void GameOver()
    {
        StartCoroutine(ShowMessageAndPause("Game Over"));
    }

    private IEnumerator ShowMessageAndPause(string message)
    {
        messageText.text = message;
        yield return null;      // wait one frame so UI updates
        Time.timeScale = 0;     // then pause the game
    }
}

