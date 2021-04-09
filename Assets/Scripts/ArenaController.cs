using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour
{

    public List<Transform> spawnPoints;
    public GameObject enemyPrefab;
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < spawnPoints.Count; i++)
            {
                Instantiate(enemyPrefab, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
                enemyPrefab.transform.parent = spawnPoints[i].transform;
                enemyPrefab.transform.position.x = spawnPoints[i].transform.position.x;
                enemyPrefab.transform.position.y = spawnPoints[i].transform.position.y;
                enemyPrefab.transform.rotation.z = spawnPoints[i].transform.rotation.z;


            }
        }
    }
}
