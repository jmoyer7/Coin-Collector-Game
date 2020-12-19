using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScores : MonoBehaviour
{

    public int firstScore;
    public int secondScore;
    public int thirdScore;
    public int fourthScore;
    public int fifthScore;
    // Start is called before the first frame update
    void Start()
    {
        //Get previous high scores and compare them to the new one. 
        firstScore = PlayerPrefs.GetInt("FirstScore");
        secondScore = PlayerPrefs.GetInt("SecondScore");
        thirdScore = PlayerPrefs.GetInt("ThirdScore");
        fourthScore = PlayerPrefs.GetInt("FourthScore");
        fifthScore = PlayerPrefs.GetInt("FifthScore");
    }


    public int score = 0;
    // Update is called once per frame
    void Update()
    {


    }

    public void LogScores()
    {

        //If score is greater than a previous score, save it
        if (score > firstScore)
        {
            PlayerPrefs.SetInt("FirstScore", score);
            PlayerPrefs.SetInt("SecondScore", firstScore);
            PlayerPrefs.SetInt("ThirdScore", secondScore);
            PlayerPrefs.SetInt("FourthScore", thirdScore);
            PlayerPrefs.SetInt("FifthScore", fourthScore);
        }
        //If the score is greater than the second score, save it as the second score. All lower scores go down a notch.
        else if (score > secondScore)
        {
            PlayerPrefs.SetInt("SecondScore", score);
            PlayerPrefs.SetInt("ThirdScore", secondScore);
            PlayerPrefs.SetInt("FourthScore", thirdScore);
            PlayerPrefs.SetInt("FifthScore", fourthScore);
        }
        else if (score > thirdScore)
        {
            PlayerPrefs.SetInt("ThirdScore", score);
            PlayerPrefs.SetInt("FourthScore", thirdScore);
            PlayerPrefs.SetInt("FifthScore", fourthScore);
        }
        else if (score > fourthScore)
        {

        }
        else if (score > fifthScore)
        {

        }
        PlayerPrefs.SetInt("FirstScore", score);

        PlayerPrefs.Save();
    }
}

