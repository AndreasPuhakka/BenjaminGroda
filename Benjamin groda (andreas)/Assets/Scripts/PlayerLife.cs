using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;
    [SerializeField] private AudioSource DeathSound;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {

            Die();
        }
        else if (collision.gameObject.CompareTag("DeathZone")) 
        {
            Die();
        }
        else if (collision.gameObject.CompareTag("Saw"))
        {
            Die();
        }
    }

    private void Die()
    {
        DeathSound.Play();
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
    }


    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
