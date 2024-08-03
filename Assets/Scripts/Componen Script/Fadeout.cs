using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fadeout : MonoBehaviour
{
    [SerializeField]Animator animator;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            animator.SetBool("Start", false);
            animator.SetBool("End", true);
            StartCoroutine(scrfade());
        }
    }

    IEnumerator scrfade()
    {
        yield return new WaitForSeconds(1);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);

    }

}
