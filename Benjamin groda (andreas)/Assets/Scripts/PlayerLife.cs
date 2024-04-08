using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{
    public int goBack = 1;
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
            anim.SetTrigger("death");
        }
        else if (collision.gameObject.CompareTag("DeathZone")) 
        {
            anim.SetTrigger("death");
        }
        else if (collision.gameObject.CompareTag("Saw"))
        {
            anim.SetTrigger("death");
        }
    }

    private void Die()
    {
        DeathSound.Play();
        rb.bodyType = RigidbodyType2D.Static;
        IncompletedLevel();

    }

    void IncompletedLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - goBack);
    }


    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
