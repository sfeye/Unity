using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerPrefab;
    private float spawnRange = 9.0f;
    private int enemyCount;
    private int waveNum = 1;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerPrefab, SpawnRandomLocation(), powerPrefab.transform.rotation);
        SpawnEnemyWave(waveNum);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0) {
            Instantiate(powerPrefab, SpawnRandomLocation(), powerPrefab.transform.rotation);
            waveNum++;
            SpawnEnemyWave(waveNum);
        }
    }

    void SpawnEnemyWave(int numEnemies){
        for(int i = 0; i < numEnemies; i++) {
            Instantiate(enemyPrefab, SpawnRandomLocation(), enemyPrefab.transform.rotation);
        }
    }

    Vector3 SpawnRandomLocation(){
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ= Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX,0,spawnPosZ);
        return randomPos;
    }
}
