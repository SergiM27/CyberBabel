using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] spawners;
    public GameObject[] enemy;
    public int numberOfEnemies;
    public int enemiesKilled;
    public int currentFloor;
    private bool floorDone;

    // Start is called before the first frame update
    void Start()
    {
        floorDone = false;
        spawners = new GameObject[7];
        GetFloor();

        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        } 
    }

    private void GetFloor()
    {
        currentFloor = GameManager.currentFloor;
    }

    public void IncreaseWaveVoid()
    {
        if (enemiesKilled >= numberOfEnemies)
        {
            StartCoroutine("IncreaseWave");
        }
    }
    private void SpawnEnemy()
    {
        int r = Random.Range(0, enemy.Length - 1);
        int spawnerID = Random.Range(0, spawners.Length);
        Instantiate(enemy[r].gameObject, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
    }
    private void SpawnBoss()
    {
        Instantiate(enemy[3].gameObject, spawners[0].transform.position, spawners[0].transform.rotation);
    }

    IEnumerator StartWave()
    {
        Debug.Log(currentFloor);
        if (currentFloor == 10)
        {
            GameManager.currentWave = 0;
            numberOfEnemies = FindObjectOfType<FloorController>().NumberOfEnemiesThisFloorPerWave();
            enemiesKilled = 0;
            InvokeRepeating("IncreaseWaveVoid", 2f, 0.5f);
            for (int i = 0; i < numberOfEnemies; i++)
            {
                SpawnBoss();
            }
        }
        else
        {
            GameManager.currentWave = 0;
            numberOfEnemies = FindObjectOfType<FloorController>().NumberOfEnemiesThisFloorPerWave();
            enemiesKilled = 0;
            InvokeRepeating("IncreaseWaveVoid", 2f, 0.5f);

            for (int i = 0; i < numberOfEnemies; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    IEnumerator IncreaseWave()
    {
        if (floorDone == false)
        {
            GameManager.currentWave++;
            if (GameManager.currentWave >= GameManager.currentFloorNumberOfWaves)
            {
                AudioManager.instance.PlaySFX4("FloorDone");
                FindObjectOfType<Elevator>().NextFloor();
                floorDone = true;
            }
            else
            {
                numberOfEnemies = GameObject.FindObjectOfType<FloorController>().NumberOfEnemiesThisFloorPerWave();
                enemiesKilled = 0;
                yield return new WaitForSeconds(3f);
                AudioManager.instance.PlaySFX3("WaveDone");
                for (int i = 0; i < numberOfEnemies; i++)
                {
                    SpawnEnemy();
                    yield return new WaitForSeconds(0.5f);
                }
            }
        }
    }
}
