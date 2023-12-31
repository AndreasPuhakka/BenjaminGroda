using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife: MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;

    [Header("Audio")]
    [SerializeField] private AudioSource deathSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            Die();
        }
        else if (collision.gameObject.CompareTag("Saw"))
        {
            Die();
        }
    }

    private void Die(){
            anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        deathSoundEffect.Play();    
            
        }
    private void RestartLevel() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
    // Update is called once per frame
}
