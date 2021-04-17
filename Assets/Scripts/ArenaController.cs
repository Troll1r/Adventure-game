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
    public int waveCount;
    public GameObject[] areas;
    bool isWave = false;
    bool spawn_;
    System.TimeSpan interval = new System.TimeSpan(0, 0, 2);

    [SerializeField] int enemyCount = 0;
    void Start()
    {
        enemyCount = 0;
    }
    /*IEnumerator WaveSpawn()
    {
        yield return new WaitForSeconds(2);
        Spawn();
    
    }*/

    void Update()
    {
        
        if ( alive == 0 && isWave==true)
        {
            Thread.Sleep(interval);
            Spawn();
        }

        if (enemyCount == 0)
        {
            walls[0].SetActive(false);
            walls[1].SetActive(false);
            walls[2].SetActive(false);
            walls[3].SetActive(false);
            waveCount++;
            //enemyCount = 0;
            isWave = false;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
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

        
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject e = GameObject.Instantiate(enemyPrefab, spawnPoints[i % 2].transform.position, Quaternion.identity);

            e.GetComponent<AICharacterControl>().arena = this;
        }

        Debug.Log("alive:" + alive);
        spawn_ = true;
    }

}
                                                