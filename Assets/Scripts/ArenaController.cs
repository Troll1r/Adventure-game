using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour
{

    public List<Transform> spawnPoints;
    public GameObject enemyPrefab;

    [SerializeField] int WaveCount;
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
            }
            WaveCount--;
        }
    }
}
