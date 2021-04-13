using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
public class AICharacterControl : MonoBehaviour
{
    public GameObject enemy;
    private NavMeshAgent agent;
    public int stopDistance = 10;
    public int damageDistance = 4;
    private bool trg = false;
    public int hp;
    public int damage = 0;
    public Animator animator;
    public List<Rigidbody> rgElements;
    public List<Collider> colliders;
    public int timer;
    ArenaController arena;
    public GameObject arenaController;
    private void Start()
    {
        arena = arenaController.GetComponent<ArenaController>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        float distance = Vector3.Distance(GameManager.Instance().player.transform.position, enemy.transform.position);
        if (trg)
        {
            agent.SetDestination(GameManager.Instance().player.transform.position);
            if (distance > stopDistance)
            {
                GetComponent<Animator>().SetFloat("Forward", 1);
            }
            else
            {
                GetComponent<Animator>().SetFloat("Forward", 0);
                GetComponent<Animator>().SetTrigger("Shot");

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
            EnablePhysics();
            Destroy(this.gameObject, 10);
            arena.SetAlive(1);
        }
        else
            DisablePhysics();
    }
    /*private void DamageGiven()
    {

    }*/

    public void EnablePhysics()
    {
        animator.enabled = false;
        for (int i = 0; i < rgElements.Count; i++)
            rgElements[i].isKinematic = false;
        for (int i = 0; i < rgElements.Count; i++)
            colliders[i].enabled = true;
        agent.isStopped = true;




    }
    public void DisablePhysics()
    {
        animator.enabled = true;
        for (int i = 0; i < rgElements.Count; i++)
            rgElements[i].isKinematic = true;
        for (int i = 0; i < rgElements.Count; i++)
            colliders[i].enabled = false;

    }
    public void Hit()
    {
        GameManager.Instance().player.playerHp -= 1;
    }
}
