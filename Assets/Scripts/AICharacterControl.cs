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
    public int damageDistance = 4;
    private bool isStop = false;
    private bool trg = false;
    public int hp;
    private void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        character = FindObjectOfType<Player>();
    }
    private void FixedUpdate()
    {
        isStop = false;
        

        

       float distance = Vector3.Distance(character.transform.position, enemy.transform.position);
        if (trg)
       {
           agent.SetDestination(character.transform.position);
           GetComponent<Animator>().SetFloat("Forward", 1);
        }
        else
        {
            agent.isStopped = true;
            GetComponent<Animator>().SetFloat("Forward", 0);
        }
       if (distance < damageDistance && Input.GetKeyDown(KeyCode.Mouse0))
       {
           DamageTaken();
       }

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
        if (other.tag == "Player")
        {
            trg = false;
            agent.isStopped = true;

            
   
        
        }
        if(isStop)
            GetComponent<Animator>().SetFloat("Forward", 0);
    }
    private void DamageTaken(int damage = 1)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
