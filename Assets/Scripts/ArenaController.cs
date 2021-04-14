using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;


public class ArenaController : MonoBehaviour
{

    public List<Transform> spawnPoints;
    public GameObject enemyPrefab;
    public GameObject[] walls;
    public int alive;
    public int zone;
    public GameObject[] areas;
    bool isWave = false;
    bool spawn_;
    System.TimeSpan interval = new System.TimeSpan(0, 0, 2);

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
        if (alive == 0 && isWave)
        {
            Debug.Log(alive + " 123");
            Thread.Sleep(interval);
            Spawn();
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
            alive = 0;
            isWave = true;
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
        maxEnemies = spawnPoints.Count * WaveCount * zone;

        alive = maxEnemies;
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
        Debug.Log(alive);
        spawn_ = true;
    }
    public void SetAlive(int _alive )
    {
        Debug.Log(alive +"  123321");
        alive--;
        Debug.Log("= " + alive);
        
    }
}
                                                