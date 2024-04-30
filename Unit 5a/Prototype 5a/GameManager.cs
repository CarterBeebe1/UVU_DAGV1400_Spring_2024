using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Variables
    public List <GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive;
    private int score;
    private float spawnRate = 1.0f;
    public GameObject titleScreen;

    // Function that spawns a random gameobject while the game is still active
    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    // Function that adds to score and displays the score value on screen
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // Function to display game over text and restart button when the game is over
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    // Function to restart the game
    public void RestartGame()
    {

        // Restart the game by reloading the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Function to start the game
    public void StartGame(int difficulty)
    {
        // Set isGameActive to true and set score to zero
        isGameActive = true;
        score = 0;

        //set spawn rate according to difficulty
        spawnRate /= difficulty;

        // Start coroutine for spawning an object and update score
        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        // Hide the title screen
        titleScreen.gameObject.SetActive(false);
    }
}
