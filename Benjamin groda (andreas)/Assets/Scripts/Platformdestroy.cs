using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformdestroy : MonoBehaviour
{
    [SerializeField] private AudioSource platformsound;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        

    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("PlatformDestroy"))
        {
            platformsound.Play();
            Destroy(collision.gameObject);
            

        }

    }


}
