using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SacrificeCollector : MonoBehaviour
{
    public float deaded = 0f;
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
        if (collision.tag == "Next Level")
        {
            deaded = Random.Range(1, Sacrifices + 1);
            if (deaded == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                Sacrifices = Sacrifices - 1;
            }
            Debug.Log(deaded);
        }
    }
}