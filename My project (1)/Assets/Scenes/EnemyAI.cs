using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
=======
public class EnemyAI : MonoBehaviour 
{
    public Animator anim; //refererar till animator
    public Transform target; //refererar till target som i detta fall �r Player
    public Transform homePos; //refererar till Enemy's hemposition, dit vi vill att den g� tillbaka till.
    public Transform homePos2; //refererar till Enemy's andra hemposition, dit vi vill att den ska patrullera mellan.
    public float speed; //refererar till hur snabbt enemy f�r g�
    public float maxRange; //refererar till enemy's max range, s� l�ngt som den f�r g�
    public float minRange; //referarer till enemy's minimum range, s� n�ra den f�r g�, s� den inte kan knuffa v�r player 
    public Transform latestHome; //beskriver sig sj�lv
    public Transform Location; //s�tt p� dens exakta position

    void Start()
    {
        anim = GetComponent<Animator>(); //h�mta animator
    }
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer(); //om player �r inom max range s� f�lj efter player, n�r du kommit tillr�ckligt n�ra "minRange" sluta f�lja
        }
        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoHome(); //om player l�mnar max range, sluta f�lja och g� till hempositionen
        }

        if (Location == homePos)
        {
            anim.SetFloat("MoveHorizontal", (homePos2.position.x - transform.position.x));
            anim.SetFloat("MoveVertical", (homePos2.position.y - transform.position.y));
            latestHome = homePos;
        }
        else if (Location == homePos2)
        {
            anim.SetFloat("MoveHorizontal", (homePos.position.x - transform.position.x));
            anim.SetFloat("MoveVertical", (homePos.position.y - transform.position.y));
            latestHome = homePos2;
        }
    }
    public void FollowPlayer()
    {
        anim.SetFloat("MoveHorizontal", (target.position.x - transform.position.x)); //enemy f�ljer efter x axeln
        anim.SetFloat("MoveVertical", (target.position.y - transform.position.y)); //enemy f�ljer efter y axeln
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime); //h�rma players r�relser
    }
    public void GoHome()
    {
        anim.SetFloat("MoveHorizontal", (latestHome.position.x - transform.position.x)); //enemy g�r hem efter x axeln
        anim.SetFloat("MoveVertical", (latestHome.position.y - transform.position.y)); //enemy g�r hem efter y axeln
        transform.position = Vector3.MoveTowards(transform.position, latestHome.position, speed * Time.deltaTime); //player h�rmar vilken position hem har
    }
}
>>>>>>> Stashed changes
