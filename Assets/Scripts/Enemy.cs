using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int range;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit);
        Debug.DrawRay(ray.origin, ray.direction * range, Color.blue);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Enemy"))
                Debug.Log("Попадаю во врага!!!");
            else
                Debug.Log("Путь к врагу преграждает объект: " + hit.collider.name);
            Debug.DrawLine(ray.origin, hit.point, Color.red);
        }
    }
}
