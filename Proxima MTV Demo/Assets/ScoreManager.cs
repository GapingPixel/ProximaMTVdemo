using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text ScoreText;
    public Text HighScoreText;

    [NonSerialized]public static int Score = 0;
    [NonSerialized]public static int HighScore = 0;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        ScoreText.text = "1P   " + Score.ToString();
        HighScoreText.text = "HI  " + HighScore.ToString();
    }

    // Update is called once per frame
    public void AddPoint(int addPoints)
    {
        Score+= addPoints;
        ScoreText.text ="1P   " + Score.ToString();
        if (HighScore < Score)
        {
            PlayerPrefs.SetInt("HighScore", Score);
        }
    }
}
