using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
public class AICharacterControl : MonoBehaviour
{
    public GameObject enemy;
    private NavMeshAgent agent;
    public Player character;
    public int stopDistance = 2;
    private bool isStop;
    private bool trg = false;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        character = FindObjectOfType<Player>();
    }
    private void FixedUpdate()
    {
       float distance = Vector3.Distance(character.transform.position, enemy.transform.position);
       if (trg)
       {
       agent.SetDestination(character.transform.position);   
       }
       if (distance < stopDistance)
       {
           agent.isStopped = true;
       }
       if(distance > stopDistance)
       {
           agent.isStopped = false;
       }
        print(trg);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            trg = true;
            agent.isStopped = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        trg = false;
        agent.isStopped = true;
    }
}
