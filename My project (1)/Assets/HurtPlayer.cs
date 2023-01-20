using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    private float waitToHurt = 2f;
    private bool isTouching;
    private HealthManager healthManager;
    public int damageToGive = 10;
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }
    void Update()
    {
        /*if (reloading)
        {
            waitToLoad -= Time.deltaTime;
            if (waitToLoad <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }*/
        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                healthManager.HurtPlayer(damageToGive);
                waitToHurt = 2f;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            //other.gameObject.SetActive(false);
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive);
            //reloading = true; 
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "player")
        {
            isTouching = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "player")
        {
            isTouching = false;
            waitToHurt = 2f;
        }
    }
}
