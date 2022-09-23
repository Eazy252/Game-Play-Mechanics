using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber =2;


    // Start is called before the first frame update
    void Start()
    {
        GeneratePowerUp();
        SpawnEnemywave(waveNumber);
    }

     

    void SpawnEnemywave( int numberOfEnemiesToSpawn)
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++) 
        {

            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);

        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0) 
        {
            waveNumber++;
            SpawnEnemywave(waveNumber);
            GeneratePowerUp();

        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPostitionX = Random.Range(-spawnRange, spawnRange);
        float spawnPostitionY = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPositon = new Vector3(spawnPostitionX, 0, spawnPostitionY);

        return randomPositon;
    }
    void GeneratePowerUp()
    {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);

    }

}
