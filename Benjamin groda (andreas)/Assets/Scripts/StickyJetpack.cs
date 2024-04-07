using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyJetpack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jetpack"))
        {
            collision.gameObject.transform.SetParent(transform);
            transform.localPosition = new Vector2(-1, -1);
        }
    }

    
}
