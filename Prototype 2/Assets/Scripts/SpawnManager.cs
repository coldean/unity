using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public GameObject bomb;

    private float spawnRangeX = 10.0f;
    private float spawnPosZ = 20.0f;
    private float spawnRangeZ = 15.0f;

    private float bombSpawnRangeX = 9.0f;
    private float bombSpawnRangeZ = 14.0f;

    private float startDelay = 2;   // 처음에 호출되기까지 걸리는 시간
    private float spawnInterval = 1.5f; // 그 후 호출까지 간격

    Variables variables;

    // Start is called before the first frame update
    void Start()
    {
        variables = GameObject.Find("ShareVariables").GetComponent<Variables>();
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
        InvokeRepeating("SpawnBomb", startDelay * 5, spawnInterval * 10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimal()
    {
        Vector3 spawnFrontPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int animalFrontIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalFrontIndex], spawnFrontPos, animalPrefabs[animalFrontIndex].transform.rotation);

        Vector3 spawnLeftPos = new Vector3(-25, 0, Random.Range(0, spawnRangeZ));
        int animalLeftIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalLeftIndex], spawnLeftPos, Quaternion.Euler(0, 90, 0));

        Vector3 spawnRightPos = new Vector3(25, 0, Random.Range(0, spawnRangeZ));
        int animalRightIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalRightIndex], spawnRightPos, Quaternion.Euler(0, -90, 0));

        variables.currentAnimals += 3;
    }

    void SpawnBomb()
    {
        Vector3 spawnBombPos = new Vector3(Random.Range(-bombSpawnRangeX, bombSpawnRangeX), 0, Random.Range(1, bombSpawnRangeZ));
        Instantiate(bomb, spawnBombPos, bomb.transform.rotation);
    }
}
