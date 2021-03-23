using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
public class AICharacterControl : MonoBehaviour
{
    [SerializeField] GameObject player;
    public GameObject enemy;
    private NavMeshAgent agent;
    public Player character;
    public int stopDistance = 2;
    public int damageDistance = 4;
    private bool trg = false;
    public int hp;
    private float timeLeft;
    public int playerHp = Player.hp;
    public int damage;
    public int timer;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        character = FindObjectOfType<Player>();
        timeLeft = timer;
    }
    private void FixedUpdate()
    {
        print(playerHp);
        float distance = Vector3.Distance(character.transform.position, enemy.transform.position);
        if (trg)
        {
            agent.SetDestination(character.transform.position);
            if (distance > stopDistance)
            {
                GetComponent<Animator>().SetFloat("Forward", 1);
            }
            else
            {
                timeLeft -= Time.deltaTime;
                GetComponent<Animator>().SetFloat("Forward", 0);
                if (timeLeft <= 0)
                {
                    timeLeft = timer;
                    GetComponent<Animator>().SetTrigger("Shot");
                    DamageGiven();
                }

            }
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
    }
    private void DamageTaken(int damage = 1)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void DamageGiven()
    {
        playerHp -= damage;
        if(playerHp <= 0)
        {
            Destroy(player);
        }
    }
}
