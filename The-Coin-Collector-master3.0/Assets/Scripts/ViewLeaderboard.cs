
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewLeaderboard : MonoBehaviour
{

    public void LoadLeaderboard()
    {
        SceneManager.LoadScene("HighScoreScreen");
    }
}
