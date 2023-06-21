using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI timeSurvivedText;
    public TextMeshProUGUI enemyShipsDestroyedText;
    public TextMeshProUGUI rocksDestroyedText;

    public Button restart;
    public Button quit;

    private bool isRestarting = false;

    private void Start()
    {
        // Note that unchecking, disabling gameOverCanvas in the inspector will make it unable to be activated from script.

        // set inactive
        gameObject.SetActive(false);
    }

    public void UpdateScoreAndActivateButtons()
    {
        // Access the game statistic variables and display them on the screen
        timeSurvivedText.text = "Time Survived: " + GameManager.timeSurvived.ToString() + " seconds";
        rocksDestroyedText.text = "Rocks Destroyed: " + GameManager.rocksDestroyed.ToString();
        enemyShipsDestroyedText.text = "Enemy Ships Destroyed: " + GameManager.enemyShipsDestroyed.ToString();

        // Assign functions to the onClick events of the buttons
        restart.onClick.AddListener(RestartGameButton);
        quit.onClick.AddListener(QuitGameButton);
    }

    public void RestartGameButton()
    {
        if (!isRestarting)
        {
            // Set the flag to indicate that the game is restarting
            isRestarting = true;

            // Reset the game statistics, make necessary arrangements
            GameManager.RestartGame();

            // Reset the flag after a delay to allow for a smooth transition
            StartCoroutine(ResetRestartFlag());

            // Set current object to inactive
            gameObject.SetActive(false);
        }
    }

    public void QuitGameButton()
    {
        // Quit the game
        Application.Quit();
    }

    private IEnumerator ResetRestartFlag()
    {
        // Wait for a short delay before resetting the restart flag
        yield return new WaitForSeconds(0.5f);

        // Reset the restart flag
        isRestarting = false;
    }

}
