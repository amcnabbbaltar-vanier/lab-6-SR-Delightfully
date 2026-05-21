using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    private bool isPaused = false;

    [SerializeField] private GameObject quitMenuPanel;
    private bool isQuitting = false;
    void Update()
    {
        // Checking if player presses esc key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    /*
     * Method used to pause the gameplay
     */
    public void PauseGame()
    {
        // Showing the pause menu UI
        pauseMenuPanel.SetActive(true);

        // Freezing the gameplay
        Time.timeScale = 0f;

        // Pausinng the audio
        isPaused = true;
    }

    /*
     * Resuming paused gameplay
     */
    public void ResumeGame()
    {
        // Hiding pause menu UI
        pauseMenuPanel.SetActive(false);

        // resuming game time
        Time.timeScale = 1f;

        // resuming audio
        isPaused = false;
    }

    /*
     * Quitting the game
     */
    public void QuitGame()
    {
        Application.Quit();
    }

    /*
     * Returning to main menu
     */
    public void ReturnToMainMenu()
    {
        NotQuittingGame();
        ResumeGame();

        SceneManager.LoadScene("MainMenu");
    }

    /*
     * Method used to decide quitting technique
     */
    public void QuittingGame()
    {
        // Showing the pause menu UI
        quitMenuPanel.SetActive(true);

        // Pausing the audio
        isQuitting = true;
    }

    /*
     * Method used to go back from deciding quitting technique panel
     */
    public void NotQuittingGame()
    {
        // Hiding pause menu UI
        quitMenuPanel.SetActive(false);

        // resuming audio
        isQuitting = false;
    }
}
