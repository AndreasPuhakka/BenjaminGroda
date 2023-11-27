using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class itemcollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI melonsText;
    private int points = 0;
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Melon"))
        {
            points ++;
            Debug.Log(points);
            melonsText.text = "Melons: " + points;
            Destroy(collision.gameObject);
        }
    }
}
