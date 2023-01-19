using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour //Måste ha samma namn som scriptet
{
    public Transform target; //refererar till target som i detta fall är Player
    public Transform homePos; //refererar till Enemy's hemposition, dit vi vill att den gå tillbaka till. 
    public Transform homePos2;
    public float speed; //refererar till hur snabbt enemy får gå
    public float maxRange; //refererar till enemy's max range, så långt som den får gå
    public float minRange; //referarer till enemy's minimum range, så nära den får gå, så den inte kan knuffa vår player 
    public Transform lastHome;
    public Transform nextHome;

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextHome.position, speed * Time.deltaTime);
        
        if (transform.position == homePos.position)
        {
            lastHome = homePos;
            nextHome = homePos2;
        }
        else if (transform.position == homePos2.position)
        {
            lastHome = homePos2;
            nextHome = homePos;
        }
        else if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }
    }
    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}