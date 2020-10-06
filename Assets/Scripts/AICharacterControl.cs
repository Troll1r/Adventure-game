using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        private NavMeshAgent agent;
        public ThirdPersonCharacter character;

        private GameObject target;
        
        public int rays = 8;
        public int rayDistance = 30;
        public int stopDistance = 2;
        public float angle = 40;
        public Vector3 offset;

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updateRotation = false;
            agent.updatePosition = true;
        }
        GameObject GetRaycast(Vector3 dir)
        {
            RaycastHit hit = new RaycastHit();
            Vector3 pos = transform.position + offset;
            if (Physics.Raycast(pos, dir, out hit, rayDistance))
            {
                if (hit.collider.GetComponent<PlayerController>())
                {
                    Debug.DrawLine(pos, hit.point, Color.green);
                    return hit.collider.gameObject;
                }
                else
                {
                    Debug.DrawLine(pos, hit.point, Color.blue);
                }
            }
            else
            {
                Debug.DrawRay(pos, dir * rayDistance, Color.red);
            }
            return null;
        }
        GameObject RayToScan()
        {
            GameObject result = null;
            float j = 0;
            for (int i = 0; i < rays; i++)
            {
                var x = Mathf.Sin(j);
                var y = Mathf.Cos(j);
                j += angle * Mathf.Deg2Rad / rays;
                
                Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));
                if (x!=0) 
                    dir = transform.TransformDirection(new Vector3(-x, 0, y));

                if (result = GetRaycast(dir)) return result;
            }
            return result;
        }
        private void FixedUpdate()
        {
            if (target = RayToScan())
            {
                if (Vector3.Distance(transform.position, target.transform.position) < stopDistance)
                {
                    // stop
                    agent.isStopped = true;
                }
                else
                {
                    agent.isStopped = false;
                    agent.SetDestination(target.transform.position);
                }
            }
            else
            {
                agent.isStopped = true;
                // лучше задать рандомную точку и патрулирование
            }

            Vector3 dir = agent.isStopped ? Vector3.zero : agent.desiredVelocity;
            character.Move(dir, false, false);
        }        
    }
}
