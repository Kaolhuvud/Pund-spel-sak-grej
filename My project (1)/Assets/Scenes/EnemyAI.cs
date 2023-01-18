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
    public Transform target; //refererar till target som i detta fall är Player
    public Transform homePos; //refererar till Enemy's hemposition, dit vi vill att den gå tillbaka till.
    public Transform homePos2; //refererar till Enemy's andra hemposition, dit vi vill att den ska patrullera mellan.
    public float speed; //refererar till hur snabbt enemy får gå
    public float maxRange; //refererar till enemy's max range, så långt som den får gå
    public float minRange; //referarer till enemy's minimum range, så nära den får gå, så den inte kan knuffa vår player 
    public Transform latestHome; //beskriver sig själv
    public Transform Location; //sätt på dens exakta position

    void Start()
    {
        anim = GetComponent<Animator>(); //hämta animator
    }
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer(); //om player är inom max range så följ efter player, när du kommit tillräckligt nära "minRange" sluta följa
        }
        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoHome(); //om player lämnar max range, sluta följa och gå till hempositionen
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
        anim.SetFloat("MoveHorizontal", (target.position.x - transform.position.x)); //enemy följer efter x axeln
        anim.SetFloat("MoveVertical", (target.position.y - transform.position.y)); //enemy följer efter y axeln
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime); //härma players rörelser
    }
    public void GoHome()
    {
        anim.SetFloat("MoveHorizontal", (latestHome.position.x - transform.position.x)); //enemy går hem efter x axeln
        anim.SetFloat("MoveVertical", (latestHome.position.y - transform.position.y)); //enemy går hem efter y axeln
        transform.position = Vector3.MoveTowards(transform.position, latestHome.position, speed * Time.deltaTime); //player härmar vilken position hem har
    }
}
>>>>>>> Stashed changes
