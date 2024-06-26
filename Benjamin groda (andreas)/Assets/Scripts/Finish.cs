using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Finish : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private int totalpošng;

    private AudioSource finishSound;
    private bool levelCompleted = false;

    [SerializeField] private ItemCollector Item;


    // Start is called before the first frame update
    void Start()
    {
        finishSound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {

      

        if (collision.gameObject.name == "Player" && levelCompleted != true && Item.points >= totalpošng)
        {
            anim.SetTrigger("finish");
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;

        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
 