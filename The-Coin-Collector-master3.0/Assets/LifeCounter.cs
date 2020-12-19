

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{
    public Image[] lives;
    public int remainingLives = 3;
    public GameObject Player;



    public void LoseLife()
    {
        lives[remainingLives].enabled = false;

        remainingLives--;

        if (remainingLives == -1)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript1>().SaveScore();
            SceneManager.LoadScene("HighScoreScreen");
        }

    }

    public void AddLife()
    {
        if (remainingLives + 1 < lives.Length)
        {
            lives[remainingLives + 1].enabled = true;
            remainingLives++;
        }
    }

    private void Update()
    {
        Destroy(Player);
    }
}
