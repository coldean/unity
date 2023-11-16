using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
    public bool isPlayer = false;
    Variables variables;

    private Slider hpBar;
    
    // Start is called before the first frame update
    void Start()
    {
        variables = GameObject.Find("ShareVariables").GetComponent<Variables>();
        if (isPlayer)
        {
            Debug.Log("Lives = " + variables.life);
            Debug.Log("Score = " + variables.score);
        }
        hpBar = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPlayer && !other.CompareTag("Bullet") && !other.CompareTag("Bomb"))
        {
            --variables.life;
            if (variables.life > 0)
                Debug.Log("Lives = " + variables.life);
            else if (variables.life == 0)
            {
                variables.gameOver = true;
                Debug.Log("Game Over!");
            }

        }
        if (isPlayer && other.CompareTag("Bomb") && !variables.gameOver)
        {
            DestroyWithTag("Animal1");
            DestroyWithTag("Animal2");
            DestroyWithTag("Animal3");

            variables.score += variables.currentAnimals;
            variables.currentAnimals = 0;
            Debug.Log("Score = " + variables.score);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Bullet") && !isPlayer && !variables.gameOver && !gameObject.CompareTag("Bomb"))
        {
            if (gameObject.CompareTag("Animal1"))
            {
                hpBar.value += 0.6f;
                Destroy(other.gameObject);
            }
            else if (gameObject.CompareTag("Animal2"))
            {
                hpBar.value += 0.34f;
                Destroy(other.gameObject);
            }
            else if (gameObject.CompareTag("Animal3"))
            {
                hpBar.value += 0.26f;
                Destroy(other.gameObject);
            }

            if (hpBar.value >= 1)
            {
                ++variables.score;
                Debug.Log("Score = " + variables.score);
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }

    }

    private void DestroyWithTag(string tag)
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }
}
