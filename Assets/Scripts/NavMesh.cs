using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets;
using UnityStandardAssets.Characters.ThirdPerson;


public class NavMesh : MonoBehaviour
{
	bool chk;
	public Transform target;
	NavMeshAgent agent;
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
	}
	void Update()
	{
		chk = GetComponent<AICharacterControl>().check;
		if (chk)
        {
			agent.SetDestination(target.position);
		}
	}
}
