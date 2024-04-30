using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    // Variables
    private Button button;
    private GameManager gameManager;

    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        // Get button component and GameManager component
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // Check if button is clicked
        button.onClick.AddListener(SetDifficulty);
    }

    // Trigger StartGame function in gameManager with a parameter for difficulty
    void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}
