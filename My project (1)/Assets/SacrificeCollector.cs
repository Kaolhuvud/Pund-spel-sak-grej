using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SacrificeCollector : MonoBehaviour
{
    private int Sacrifices = 0;
    [SerializeField] private Text SacrificeText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sacrifice"))
        {
            Destroy(collision.gameObject);
            Sacrifices++;
            SacrificeText.text = "Sacrifices Saved: " + Sacrifices;
        }
    }
}
