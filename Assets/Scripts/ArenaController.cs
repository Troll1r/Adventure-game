using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaController : MonoBehaviour
{

    public List<Transform> spawnPoints;
    public GameObject enemyPrefab;
    public GameObject[] walls;
    public int alive;
    int zone;
    public GameObject[] areas;
    bool isWave = false;
    bool spawn_;

    [SerializeField] int WaveCount = 0;
    void Start()
    {

    }
    IEnumerator WaveSpawn()
    {
        yield return new WaitForSeconds(2);
        Spawn();

    }

    void Update()
    {
        if (alive >= 0 && isWave && spawn_)
        {
            Debug.Log(alive + " " + WaveCount);
            spawn_ = false;
            if (!spawn_)
                StartCoroutine(WaveSpawn());

        }

        if (WaveCount == 5)
        {
            walls[0].SetActive(false);
            walls[1].SetActive(false);
            walls[2].SetActive(false);
            walls[3].SetActive(false);
            zone++;
            WaveCount = 0;
            isWave = false;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isWave = true;
            Spawn();
            walls[0].SetActive(true);
            walls[1].SetActive(true);
            walls[2].SetActive(true);
            walls[3].SetActive(true);
            var bc = GetComponent<BoxCollider>();
            bc.enabled = false;
        }
    }
     
    public void Spawn()
    {
        int maxEnemies;
        maxEnemies = 1;//spawnPoints.Count * WaveCount * zone;

        for (int i = 0; i < maxEnemies; i++)
        {
            int abc = i;
            abc = abc % 2;
            if(abc == 0)
            {
                Instantiate(enemyPrefab, spawnPoints[0].transform.position, Quaternion.identity);
            }
            if(abc == 1)
            {
                Instantiate(enemyPrefab, spawnPoints[1].transform.position, Quaternion.identity);
            }
        }
        WaveCount++;
        alive = maxEnemies;
        Debug.Log(alive);
        spawn_ = true;
    }
    public void SetAlive(int _alive )
    {
        alive -= _alive;

        Debug.Log(alive);
    }
}
                                                