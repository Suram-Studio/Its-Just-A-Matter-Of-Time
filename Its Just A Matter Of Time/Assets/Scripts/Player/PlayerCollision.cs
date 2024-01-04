using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Hazard"))
        {
            HealthManager.health--;
            Debug.Log("Is Hurt");
            if(HealthManager.health <= 0)
            {
                PlayerManager.isGameOver = true;
                animator.SetTrigger("isDead");
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
    }

    private IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(8, 9);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(2);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
