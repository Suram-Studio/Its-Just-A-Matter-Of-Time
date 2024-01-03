using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Hazard"))
        {
            LifeManager.health--;
            Debug.Log("Is Hurt");
            if(LifeManager.health <= 0)
            {
                PlayerManager.isGameOver = true;
                gameObject.SetActive(false);
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
}
