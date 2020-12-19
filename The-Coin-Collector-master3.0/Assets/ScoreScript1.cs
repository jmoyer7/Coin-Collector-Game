using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript1 : MonoBehaviour
{
    public static int scoreTotal = 0;
    Text score;

    [SerializeField]
    private GameObject enemy;

    private bool spawnedEnemy = false;
    private bool changedSpeed = false;

    public int nextLevel = 20;
    private int nextLevelIncrease = 20;
    private int lastLevel = 5;



    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scoreTotal;

        /*
         if (scoreTotal == 2 && !changedSpeed)
         {
             ChangeSpeed();
         }
        */

        if (scoreTotal == nextLevel && !spawnedEnemy)
        {
            SpawnEnemy();
        }

        if (scoreTotal == lastLevel + 1)
        {
            spawnedEnemy = false;
        }

    }

    void SpawnEnemy()
    {
        bool enemySpawned = false;

        while (!enemySpawned)
        {
            Vector3 enemyPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(-2f, 4f), 0f);
            if ((enemyPosition - GameObject.FindGameObjectWithTag("Player").transform.position).magnitude < 3)
            {
                continue;
            }
            else
            {
                Instantiate(enemy, enemyPosition, Quaternion.identity);
                enemySpawned = true;
            }
        }

        spawnedEnemy = true;
        lastLevel = nextLevel;
        nextLevel += nextLevelIncrease;
    }

    public void SaveScore()
    {
        GameObject.FindGameObjectWithTag("Score").GetComponent<SaveScores>().score = scoreTotal;
        GameObject.FindGameObjectWithTag("Score").GetComponent<SaveScores>().LogScores();
    }

    void ChangeSpeed()
    {
        GameObject.Find("Coin Protector").GetComponent<Wander>().speed++;
        GameObject.Find("Coin Protector").GetComponent<Wander>().baseSpeed++;
        changedSpeed = true;
    }
}






