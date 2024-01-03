using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public static bool isGamePaused;
    public GameObject gamePausedScreen;

    private void Awake()
    {
        isGameOver = false;
        isGamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
        {
            gameOverScreen.SetActive(true);
        }

        if(Input.GetButtonDown("Cancel") && !isGameOver)
        {
            isGamePaused = !isGamePaused;

        }

        if(isGamePaused)
        {
            gamePausedScreen.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Game Paused");
        }
        else
        {
            gamePausedScreen.SetActive(false);
            Time.timeScale = 1;
            Debug.Log("Game Unpaused");
        }
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
