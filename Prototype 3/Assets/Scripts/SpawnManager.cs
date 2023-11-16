using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePreFab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);

    private float startDelay = 5;
    private float repeatRate = 2;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            int randIndex = Random.Range(0, obstaclePreFab.Length);
            Instantiate(obstaclePreFab[randIndex], spawnPos, obstaclePreFab[randIndex].transform.rotation);
        }
    }
}
