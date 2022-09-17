using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    private float spawnRange = 9.0f;
    // Start is called before the first frame update
    void Start()
    {


        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation) ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPostitionX = Random.Range(-spawnRange, spawnRange);
        float spawnPostitionY = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPositon = new Vector3(spawnPostitionX, 0, spawnPostitionY);

        return randomPositon;
    }
}
