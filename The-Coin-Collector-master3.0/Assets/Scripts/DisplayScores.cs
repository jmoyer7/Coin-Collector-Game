
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayScores : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Text FirstScoreText = GameObject.FindGameObjectWithTag("score1").GetComponent<Text>();
        Text SecondScoreText = GameObject.FindGameObjectWithTag("score2").GetComponent<Text>();
        Text ThirdScoreText = GameObject.FindGameObjectWithTag("score3").GetComponent<Text>();
        Text FourthScoreText = GameObject.FindGameObjectWithTag("score4").GetComponent<Text>();
        Text FifthScoreText = GameObject.FindGameObjectWithTag("score5").GetComponent<Text>();


        int firstScore = PlayerPrefs.GetInt("FirstScore");
        int secondScore = PlayerPrefs.GetInt("SecondScore");
        int thirdScore = PlayerPrefs.GetInt("ThirdScore");
        int fourthScore = PlayerPrefs.GetInt("FourthScore");
        int fifthScore = PlayerPrefs.GetInt("FifthScore");

        //Display High Scores

        FirstScoreText.text = firstScore.ToString();


        SecondScoreText.text = secondScore.ToString();

        ThirdScoreText.text = thirdScore.ToString();

        FourthScoreText.text = fourthScore.ToString();

        FifthScoreText.text = fifthScore.ToString();

    }





    // Update is called once per frame
    void Update()
    {

        //Exit when player hits ESC
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("StartMenu");
        }
    }

}
