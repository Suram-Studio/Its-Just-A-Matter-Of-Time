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
            isDead();
            gameOverScreen.SetActive(true);
            HealthManager.health = 0;
            Debug.Log("Game Over");
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
    
    public void isDead()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("isDead");
    }
    
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
