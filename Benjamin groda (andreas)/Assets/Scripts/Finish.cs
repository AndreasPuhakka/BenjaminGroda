using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private int totalpoäng;

    private AudioSource finishSound;
    private bool levelCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        finishSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {

      

        if (collision.gameObject.name == "Player" && levelCompleted != true && points == totalpoäng)
        {
            anim.SetTrigger("finish");
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);

        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
