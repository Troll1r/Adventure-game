using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }            
        public ThirdPersonCharacter character { get; private set; } 
        public Transform target;
        public string targetTag = "Player";
        public int rays = 8;
        public int distance = 33;
        public float angle = 40;
        public Vector3 offset;
        public Transform tar;
        private NavMeshAgent Nana;
        public bool check = false;
        public Collider cld;
        private bool isMove = true;
        private void Start()
        {
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            
	        agent.updateRotation = false;
	        agent.updatePosition = true;
            tar = GameObject.FindGameObjectWithTag(targetTag).transform;
            Nana = GetComponent<NavMeshAgent>();
        }
        bool GetRaycast(Vector3 dir)
        {
            bool result = false;
            RaycastHit hit = new RaycastHit();
            Vector3 pos = transform.position + offset;
            if (Physics.Raycast(pos, dir, out hit, distance))
            {
                if (hit.transform == target)
                {
                    result = true;
                    Debug.DrawLine(pos, hit.point, Color.green);
                }
                else
                {
                    Debug.DrawLine(pos, hit.point, Color.blue);
                }
            }
            else
            {
                Debug.DrawRay(pos, dir * distance, Color.red);
            }
            return result;
        }
        public bool RayToScan()
        {
            bool result = false;
            bool a = false;
            bool b = false;
            float j = 0;
            for (int i = 0; i < rays; i++)
            {
                var x = Mathf.Sin(j);
                var y = Mathf.Cos(j);
                j += angle * Mathf.Deg2Rad / rays;
                Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));
                if (GetRaycast(dir)) a = true;
                if (x != 0)
                {
                    dir = transform.TransformDirection(new Vector3(-x, 0, y));
                    if (GetRaycast(dir)) b = true;  
                }
            }
            if (a || b) result = true;
            return result;
        }
        private void Update()
        {
            if (Vector3.Distance(transform.position, target.position) < distance)
            {
                    {
                        if (RayToScan())
                        {
                            Nana.enabled = true;
                            if (agent.remainingDistance > agent.stoppingDistance)
                                character.Move(agent.desiredVelocity, false, false);
                            check = true;
                        
                        }
                        else
                        {
                            character.Move(Vector3.zero, false, false);
                            check = false;
                        }
                    }                   
            }
        }
        public void SetTarget(Transform target)
        {
            this.target = target;
        }
        public void OnTriggerEnter(Collider MyTrigger)
        {
            if(isMove)
            {
                Nana.isStopped = false;
                isMove = false;
            }
            else
                Nana.isStopped = true;
        }
        public void OnTriggerExit(Collider other)
        {
            Nana.isStopped = false;
        }
    }
}
