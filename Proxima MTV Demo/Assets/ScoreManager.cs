using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public  Text ScoreText;
    public Text HighScoreText;
    public Text GameOverText;
    
    public GameObject [ ] GameOverObjs;
    public GameObject ScoreTextObj;
    public GameObject HighScoreTextObj;
    

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

    void Update()
    {
        if (GameManager.GameOverScreen)
        {
            ScoreTextObj.transform.position = new Vector3(transform.position.x,121.8f,transform.position.z);
            ScoreText.text = "Score Reach: " + Score.ToString();
            HighScoreTextObj.transform.position = new Vector3(transform.position.x+4000,transform.position.y,transform.position.z);
            GameOverText.text = "Game Over";
            if (GameManager.LevelCompleted)
            {
                GameOverText.text = "Level Finish!";
            }
        }
        
    }

    // Update is called once per frame
    public void AddPoint(int addPoints)
    {
        if (GameManager.GameOverScreen)
        {
            return;
        }
        Score+= addPoints;
        ScoreText.text ="1P   " + Score.ToString();
        if (HighScore < Score)
        {
            PlayerPrefs.SetInt("HighScore", Score);
        }
    }
}
