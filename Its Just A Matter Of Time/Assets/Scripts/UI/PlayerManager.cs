using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private Animator animator;
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public static bool isGamePaused;
    public GameObject gamePausedScreen;

    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        isGameOver = false;
        isGamePaused = false;
    }
    
    void Update()
    {
        if(isGameOver)
        {
            gameOverScreen.SetActive(true);
            HealthManager.health = 0;
            rb.bodyType = RigidbodyType2D.Static;
            animator.SetTrigger("isDead");
            Time.timeScale = 0;
            Debug.Log("Game Over");
        }

        if(Input.GetButtonDown("Cancel") && !isGameOver)
        {
            isGamePaused = !isGamePaused;
        }

        if(isGamePaused)
        {
            gamePausedScreen.SetActive(true);
            rb.bodyType = RigidbodyType2D.Static;
            Time.timeScale = 0;
            Debug.Log("Game Paused");
        }
        else
        {
            gamePausedScreen.SetActive(false);
            rb.bodyType = RigidbodyType2D.Dynamic;
            Time.timeScale = 1;
            Debug.Log("Game Unpaused");
        }
    }
    
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
