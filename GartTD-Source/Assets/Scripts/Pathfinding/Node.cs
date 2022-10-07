using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemies;

public class Node : MonoBehaviour
{
    public Transform nextNode; //Definitely change this to be automatic or stored from a node spawner that holds an array of node transforms

    void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Detected");
        if (other.gameObject.layer == 6) 
        {
            Debug.Log("Redirected");
            other.gameObject.GetComponent<EnemyBase>().StartPathfinding(nextNode);
        }
    }
}
