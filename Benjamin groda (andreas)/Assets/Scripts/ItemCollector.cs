using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{

    private int points = 0;
    [SerializeField] private TextMeshProUGUI äppleText;
    [SerializeField] private AudioSource äppelsound;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Äpple"))
        {
            äppelsound.Play();
            points += 1;
            Destroy(collision.gameObject);
            äppleText.text = "Äppel: " + points;
        }

    }




}
